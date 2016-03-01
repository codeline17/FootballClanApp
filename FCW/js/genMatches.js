﻿window.onload = function () {
    $("tr").click(expandMatch);
};

function genMatchRows(matches, id) {

    //Table Tag
    var mainTag = document.createElement("table");
    mainTag.id = id;
    mainTag.className = "table table-hover";

    //Header
    var head = [{ Title: "Match", Text: "Match" }, { Title: "League", Text: "League" }, { Title: "Fill", Text: "Fill" },
                { Title: "Time", Text: "Time" }, { Title: "Score", Text: "Score" }, { Title: "Points", Text: "Points" }];
    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    for (var i = 0; i < head.length; i++) {
        var hElement = document.createElement("th");
        var hSpan = document.createElement("span");
        hSpan.setAttribute("data-toggle", "tooltip");
        hSpan.setAttribute("data-placement", "top");
        hSpan.title = head[i].Title;
        hSpan.innerText = head[i].Text;
        hElement.append(hSpan);
        hRow.append(hElement);
    }
    tHead.append(hRow);

    //Body
    var tBody = document.createElement("tbody");
    for (var j = 0; j < matches.length; j++) {
        tBody.append(genSingleMatchRow(matches[j]));
    }

    mainTag.append(tHead);
    mainTag.append(tBody);

    return mainTag;
}

function genSingleMatchRow(match) {
    var tr = cEl("tr").wr(match).listener("click", expandMatch);
    //MatchName
    tr.append(cEl("td").tEl(match.HomeTeam.Name + "-" + match.AwayTeam.Name));
    //League
    tr.append(cEl("td").tEl(match.League.Name));
    //Fill
    var s = 0;
    for (var i = 0; i < match.Games.length; i++) {
        for (var j = 0; j < match.Games[i].Outcomes.length; j++) {
            if (match.Games[i].Outcomes[j].Selected) {
                s++;
            }
        }
    }
    tr.append(cEl("td").tEl(s + "/4"));
    //Time
    tr.append(cEl("td").tEl(match.ShortTime));
    //Score
    tr.append(cEl("td").tEl(match.HomeGoals + "-" + match.AwayGoals));
    //Points
    tr.append(cEl("td").tEl(match.PointsWon));

    return tr;
}

function expandMatch(e) {
    if ($(".mDetails").length > 0) {
        $(".mDetails").parent().parent().remove();
    }

    if ($(this).next(".mDetails").length > 0) {
        $(this).next().parent().parent().remove();
    } else {
        var el = e.target.parentElement;

        var sealed = e.target.parentElement.wrapper.Sealed;
        var panel = createMatchPanel(e.target.parentElement.wrapper).attr("class", "mDetails");
        panel.className += sealed ? " mSealed" : "";

        var d = new Date();
        var expand = cEl("tr").append(cEl("td").attr("colspan", 6).append(panel));

        if (el.nextSibling) {
            el.parentNode.insertBefore(expand, el.nextSibling);
        } else {
            el.parentNode.appendChild(expand);
        }

        /*$(".btn-group > .btn").click(function() {
            $(this).addClass("active").siblings().removeClass("active");
        });*/
    }
}

function createMatchPanel(e) {
    var panel = cEl("div").attr("class", "row-fluid");
    var sealed = e.Sealed;
    var addClass;
    var i = 0;
    var rubRF = e.Games[0];
    var rubLPG = e.Games[1];
    var rubTG = e.Games[2];
    var rubCS = e.Games[3];

    //------------------------RF---------------------
    var rf = cEl("div").attr("class", "span12").append(cEl("h4").attr("class", "text-center").tEl("Match Result"));
    var rfDetails = cEl("div").attr("class", "btn-group btn-group-justified").attr("role", "group");
    for (i = 0; i < rubRF.Outcomes.length; i++) {
        addClass = rubRF.Outcomes[i].Selected ? " active" : "";
        var rubRFel = cEl("a").attr("class", "btn btn-default" + addClass).attr("role", "button")
            .tEl(rubRF.Outcomes[i].Name.replace("[Home]", e.HomeTeam.Name).replace("[Draw]", "Draw").replace("[Away]", e.AwayTeam.Name));
        if (!sealed) {
            rubRFel.listener("click", sendPredictions).wr({ attrs: e.ID + "|" + rubRF.Slug + "|" + rubRF.Outcomes[i].Name });
        }
        rfDetails.append(rubRFel);

    }
    var rfrow = cEl("div").attr("class", "row-fluid").append(rf).append(rfDetails);

    //------------------------LPG---------------------
    var lpg = cEl("div").attr("class", "row-fluid").append(cEl("h4").attr("class", "text-center").tEl("Goals Scored"));
    var lpgDetails = cEl("div").attr("class", "btn-group btn-group-justified").attr("role", "group");
    for (i = 0; i < rubLPG.Outcomes.length; i++) {
        addClass = rubLPG.Outcomes[i].Selected ? " active" : "";
        var lpgel = cEl("a").attr("class", "btn btn-default" + addClass).attr("role", "button")
            .tEl(rubLPG.Outcomes[i].Name.replace("Under", "2 or less").replace("Over", "3 or more"));
        if (!sealed) {
            lpgel.wr({ attrs: e.ID + "|" + rubLPG.Slug + "|" + rubLPG.Outcomes[i].Name }).listener("click", sendPredictions);
        }
        lpgDetails.append(lpgel);
    }
    var lpgrow = cEl("div").attr("class", "span4").append(lpg).append(lpgDetails);
    if (rubLPG.Sealed) {
        //<span data-toggle="tooltip" data-placement="top" title="" data-original-title="Match">Match</span>
    }
    lpg.attr("data-toggle", "tooltip").attr("data-placement", "top").attr("data-original-title", "LPG");

    //------------------------TG---------------------
    var tg = cEl("div").attr("class", "row-fluid").append(cEl("h4").attr("class", "text-center").tEl("Total Goals"));
    var tgDetails = cEl("select").attr("class", "TG");
    if (!sealed) {
        tgDetails.listener("change", sendPredictions);
    }
    else {
        tgDetails.setAttribute("disabled", "disabled");
    }
    for (i = 0; i < rubTG.Outcomes.length; i++) {
        var tgEl = cEl("option").tEl(rubTG.Outcomes[i].Name);
        tgEl.selected = rubTG.Outcomes[i].Selected;
        if (!sealed) {
            tgEl.wr({ attrs: e.ID + "|" + rubTG.Slug + "|" + rubTG.Outcomes[i].Name });
        }
        tgDetails.append(tgEl);
    }
    var tgrow = cEl("div").attr("class", "span4").append(tg).append(tgDetails);

    //------------------------CS---------------------
    var cs = cEl("div").attr("class", "row-fluid").append(cEl("h4").attr("class", "text-center").tEl("Correct Score"));
    var csDetails = cEl("select").attr("class", "CS");
    if (!sealed) {
        csDetails.listener("change", sendPredictions);
    }
    else {
        csDetails.setAttribute("disabled", "disabled");
    }
    for (i = 0; i < rubCS.Outcomes.length; i++) {
        var csEl = cEl("option").tEl(rubCS.Outcomes[i].Name);
        csEl.selected = rubCS.Outcomes[i].Selected;
        if (!sealed) {
            csEl.wr({ attrs: e.ID + "|" + rubCS.Slug + "|" + rubCS.Outcomes[i].Name });
        }
        csDetails.append(csEl);
    }
    var csrow = cEl("div").attr("class", "span4").append(cs).append(csDetails);

    //------------------------RT---------------------
    var rtrow = cEl("div").attr("class", "row-fluid").append(lpgrow).append(tgrow).append(csrow);

    panel.append(rfrow).append(cEl("hr")).append(rtrow);

    return panel;
}


function sendPredictions(e) {
    var prd = "";

    switch (e.type) {
        case "click":
            prd = e.target.wrapper.attrs;
            break;
        case "change":
            prd = e.target.options[e.target.selectedIndex].wrapper.attrs;
            break;
    }

    if (prd.length < 0)
        return;

    var sibs = e.target.parentNode.childNodes;
    for (var i = 0; i < sibs.length; i++) {
        sibs[i].className = sibs[i].className.replace(" active","");
    }
    e.target.className += " active";

    $.post("Actions/Fixture.aspx", { type: "SNDPD", pds: prd });

    getMatches("n");
}