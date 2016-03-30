function genLiveScore(dt) {
    var mainC = document.getElementById("mainContainer");
    mainC.innerHTML = "";
    mainC.append(cEl("h3").attr("id","LivescoreTitle").tEl("Livescore on " + dt));
    addFilterHead();
    getLiveScoreDetails(dt);
}

function genLiveScoreTable(e) {
    var exGrid = document.getElementById("livescore-table");
    if (exGrid) {
        exGrid.parentNode.removeChild(exGrid);
    }
    var mainTag = document.createElement("table");
    mainTag.id = "livescore-table";
    mainTag.className = "table table-hover";

    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "League").tEl("League")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Start Time").tEl("Start Time")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Match").tEl("Match")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Time of the match").tEl("Time/Status")));
    //hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Score").tEl("Score")));
    tHead.appendChild(hRow);

    //body
    var tBody = document.createElement("tbody");

    for (var j = 0; j < e.length; j++) {
        var mSpan = cEl("span");
        mSpan.append(
            getRCElement(e[j].HomeRed)
        ).append(
            getYCElement(e[j].HomeYellow)
        ).tEl(e[j].HomeTeam.Name).append(getGElement(e[j].HomeGoals)).tEl("-").append(getGElement(e[j].AwayGoals)).tEl(e[j].AwayTeam.Name)
            .append(
            getYCElement(e[j].AwayYellow)
            ).append(
                getRCElement(e[j].AwayRed)
            );

        var row = cEl("tr").append(cEl("td").tEl(e[j].League.Name)).append(cEl("td").tEl(e[j].ShortTime))
            //.append(cEl("td").tEl(e[j].HomeTeam.Name + "-" + e[j].AwayTeam.Name))
            .append(cEl("td").append(mSpan)).append(cEl("td").tEl(e[j].Minute))
            //.append(cEl("td").tEl(e[j].HomeGoals + "-" + e[j].AwayGoals));
        tBody.append(row);
    }
    mainTag.appendChild(tHead);
    mainTag.appendChild(tBody);

    return mainTag;
}

function getLiveScoreDetails(dt) {
    $.post("Actions/Fixture.aspx", { type: "GLS", date: dt },
        function (e) {
            e = JSON.parse(e);
            var lblHead = document.getElementById("LivescoreTitle");
            lblHead.innerText = "Livescore on " + dt;
            var mainC = document.getElementById("mainContainer");
            var rFluid = document.createElement("div");
            rFluid.id = "tblContainer";
            var tbl = genLiveScoreTable(e);
            rFluid.appendChild(tbl);
            mainC.appendChild(rFluid);
        });
}

function getYCElement(n) {
    var yc = cEl("span");
    if (n > 0) {
        yc.attr("class", "label label-warning card").tEl(n);
    }
    return yc;
}

function getRCElement(n) {
    var rc = cEl("span");
    if (n > 0) {
        rc.attr("class", "label label-important card").tEl(n);
    }
    return rc;
}

function getGElement(n) {
    var rc = cEl("span").attr("class", "label label-default card").tEl(n);
    return rc;
}