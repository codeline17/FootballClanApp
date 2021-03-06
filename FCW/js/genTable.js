﻿function genTable(id, matches, state) {

    var head = getHead(matches[0], state);

    //tags
    var mainTag = document.createElement("table");
    mainTag.id = id;
    mainTag.className = "table table-hover";
    
    //header
    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    for (var i = 0; i < head.length; i++) {
        var hElement = document.createElement("th");
        var hSpan = document.createElement("span");
        hSpan.setAttribute("data-toggle", "tooltip");
        hSpan.setAttribute("data-placement", "top");
        hSpan.title = head[i].Title;
        hSpan.innerText = head[i].Text;
        hElement.appendChild(hSpan);
        hRow.appendChild(hElement);
    }
    tHead.appendChild(hRow);
    
    //body
    var tBody = document.createElement("tbody");
    for (var j = 0; j < matches.length; j++) {
        tBody.appendChild(getMatchRow(matches[j], state));
    }

    mainTag.appendChild(tHead);
    mainTag.appendChild(tBody);

    return mainTag;
}


function getHead(sMatch, state) {
    var r = new Array();

    var el = { Title: "Match", Text: "Match" }
    r.push(el);
    el = { Title: "Time", Text: "Time" };
    r.push(el);
    el = { Title: "League", Text: "League" };
    r.push(el);

    for (var i = 0; i < sMatch.Games.length; i++) {
        el = { Title: sMatch.Games[i].Name, Text: sMatch.Games[i].Slug }
        r.push(el);
    }

    if (state === false) {
        el = { Title: "Points Won", Text: "Pts" };
        r.push(el);
    }

    return r;
}

function getMatchRow(match, state) {
    var tr = document.createElement("tr");
    tr.id = "rid" + match.ID;
    var td = document.createElement("td");
    var span = document.createElement("span");
    
    /**fixed**/
    //Match Name
    span.setAttribute("data-toggle", "tooltip");
    span.setAttribute("data-placement", "top");
    span.setAttribute("title", match.HomeTeam.Name + "-" + match.AwayTeam.Name);
    span.innerText = getFixtureName(match);
    td.appendChild(span);
    tr.appendChild(td);
    //Match Time
    td = document.createElement("td");
    span = document.createElement("span");
    span.setAttribute("data-toggle", "tooltip");
    span.setAttribute("data-placement", "top");
    span.setAttribute("title", match.ShortTime);
    span.innerText = match.ShortTime;
    td.appendChild(span);
    tr.appendChild(td);
    //Match League
    td = document.createElement("td");
    span = document.createElement("span");
    span.setAttribute("data-toggle", "tooltip");
    span.setAttribute("data-placement", "top");
    span.setAttribute("title", match.League.Name);
    span.innerText = match.League.Name.substring(0, 8);
    td.appendChild(span);
    tr.appendChild(td);
    /*********/
    
    for (var i = 0; i < match.Games.length; i++) {
        tr.appendChild(getGameCell(match.ID, match.HomeTeam.Name, match.AwayTeam.Name, match.Sealed, match.Games[i], state));
        tr.className = (match.Sealed ? "greyed" : "");
        tr.className = tr.className + " " + match.Pack.toLowerCase();
    }

    //Points Won
    if (state === false) {
        td = document.createElement("td");
        span = document.createElement("span");
        span.setAttribute("data-toggle", "tooltip");
        span.setAttribute("data-placement", "top");
        span.setAttribute("title", match.PointsWon);
        span.innerText = match.PointsWon;
        td.appendChild(span);
        tr.appendChild(td);
    }

    return tr;
}

function getGameCell(matchId, home, away, sealed, game, state) {
    var event = !sealed && state;
    var td = document.createElement("td");
    if (game.Repeater === "a") {
        for (var i = 0; i < game.Outcomes.length; i++) {
            var odd = document.createElement("a");
            var nId = makeid();
            odd.className = (sealed ? "odd greyed" : "odd");
            odd.className += (game.Outcomes[i].Selected ? " closed" : "");
            odd.setAttribute("data-toogle", "tooltip");
            odd.setAttribute("data-placement", "top");
            odd.setAttribute("data-group", game.Slug);
            odd.setAttribute("data-odd", matchId + "|" + game.Slug + "|" + game.Outcomes[i].Name);
            odd.setAttribute("title", game.Outcomes[i].Name.replace("[Home]", home).replace("[Away]", away).replace("[Draw]", "Draw").replace(" ", ""));
            odd.innerText = game.Outcomes[i].Name.replace("[Home]", home).replace("[Away]", away).replace("[Draw]", "Draw").replace(" ", "").substring(0, 12);
            odd.id = nId;
            if (event)
                odd.addEventListener("click", setPrediction, false);
            td.appendChild(odd);
        }
    }
    else if (game.Repeater === "option") {
        var odd = document.createElement("select");
        for (var k = 0; k < game.Outcomes.length; k++) {
            var innerOdd = document.createElement("option");
            var nId = makeid();
            innerOdd.selected = game.Outcomes[k].Selected;
            innerOdd.setAttribute("data-group", game.Slug);
            innerOdd.setAttribute("data-odd", matchId + "|" + game.Slug + "|" + game.Outcomes[k].Name);
            innerOdd.innerText = game.Outcomes[k].Name.replace("[Home]", home).replace("[Away]", away).replace("[Draw]", "Draw").replace(" ", "").substring(0, 8);
            innerOdd.id = nId;
            if (event)
                odd.addEventListener("change", setPrediction, false);
            odd.appendChild(innerOdd);
        }

        odd.selectedIndex = odd.selectedIndex ? odd.selectedIndex : odd.options[0].value;

        td.appendChild(odd);
    }
    else if (game.Repeater === "input") {
        for (var j = 0; j < game.Outcomes.length; j++) {
            var odd = document.createElement("input");
        }
    }

    return td;
}

function genClanTable(e) {
    var mainTag = document.createElement("table");
    mainTag.id = "clan-table";
    mainTag.className = "table table-hover manage-clan";

    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Member Name").tEl("Name")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Rank").tEl("Rank")));
    //hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Level").tEl("Lvl")));
    //hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Form").tEl("Form")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Points").tEl("Pts")));
    //hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Member Since").tEl("Member Since")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Roles and Actions").tEl("#")));
    tHead.appendChild(hRow);

    //body
    var tBody = document.createElement("tbody");
    var cUserLeader = cuser.Username.toLowerCase() === e.Leader.toLowerCase();
    
    for (var j = 0; j < e.Users.length; j++) {
        var cun = e.Users[j].Username;
        var cn = e.Name;
        var form = getUserForm(e.Users[j]);
        var form1 = genProgressBar(form).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");
        var level = getOverAllForm(e.Users[j]);
        
        var guid = e.Users[j].Guid;
        
        var row = cEl("tr").wr({ Guid: guid }).listener("click", function () { showProfileClan(this); }).append(cEl("td").tEl(e.Users[j].Username)).append(cEl("td").tEl(e.Users[j].Rank)).append(cEl("td").tEl(e.Users[j].Points));

        //.append(cEl("td").tEl(e.Users[j].InClanSince));
        row.className = e.Users[j].Username === e.Leader ? "leader" : "";
        if (cun === e.Leader) {
            row.append(cEl("td").append(cEl("span").tEl("Ⓒ").attr("style", "font-size:20px;")));
        } else {
            if (cUserLeader) {
                if (e.Users[j].Username !== e.Leader) {
                    if (e.Users[j].isApproved) {
                        row.append(cEl("td").append(
                            cEl("i").attr("class", "icon-cancel-1").attr("style", "color:red;font-size:15px;").attr("cel-uname", cun).attr("cel-cname", cn).listener("click", removeMember)
                            ));
                    } else {
                        row.attr("class","not-approved").append(cEl("td").append(
                                cEl("span").append(
                                    cEl("i").attr("class", "icon-ok").attr("style", "color:green;font-size:20px;margin-bottom:7px;padding-right:25px;").attr("cel-uname", cun).attr("cel-cname", cn).listener("click", approveMember)
                                    ).append(
                                    cEl("i").attr("class", "icon-cancel-1").attr("style", "color:red;font-size:15px;margin-top:4px;margin-bottom:5px;").attr("cel-uname", cun).attr("cel-cname", cn).listener("click", removeMember)
                                )
                            ));
                    }
                }
            } else {
                row.append(cEl("td").tEl(""));
            }
        }

        

    tBody.append(row);
    }
        
    mainTag.appendChild(tHead);
    mainTag.appendChild(tBody);

    return mainTag;
}


var firstClick = 0;
var lastClick = 0;
function showProfileClan(el) {
    var guid = el.wrapper.Guid;
    var rownumber;
    
    var table = document.getElementById("clan-table");
    var lastTableEl = document.getElementById("clan-table").rows.length;
    var todyaDate = getFullDate(new Date(), 0);
    var lastWeekDate = getFullDate(new Date(), -7);
    $.post("Actions/User.aspx", { type: "RFR", userGuid: guid, fromDateDetails: lastWeekDate, toDateDetails: todyaDate },
       function (e) {
           if ($("#clan-table tr").hasClass("profile")) {
               $("#clan-table .profile").remove();
           }
           rownumber = el.rowIndex;
           if (firstClick == 0) {
               var e = JSON.parse(e);
               var level = getOverAllForm(e);//level
               var form = getUserForm(e);//form
               var form1 = genProgressBar(form).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");
               var globalRank = e.Rank;//globalrank
               var todayPts = e.TodayPoints;
               var yesterdayPts = e.YesterdayPoints;
               var lastWeekPts = e.DetailPoints;;
               var avatar = e.AvatarId;
               var row3 = cEl("div").attr("class", "row-fluid text-center")
                   .append(cEl("div").attr("class", "profile-el").append(cEl("img").attr("style", "height:27px;").attr("src", "style/images/avatars/" + avatar + ".png")))
                        .append(cEl("div").attr("class", "profile-el").tEl("Level: ").append(cEl("span").attr("class", "total-points label-warning").tEl(level)))
                            .append(cEl("div").attr("class", "profile-el").tEl("Global Rank: " + globalRank))
                                 .append(cEl("div").attr("class", "profile-el").tEl("Today Pts: " + todayPts))
                                   .append(cEl("div").attr("class", "profile-el").tEl("Yesterday Pts: " + yesterdayPts))
                                        .append(cEl("div").attr("style", "text-align:center").tEl("Last Week Pts: " + lastWeekPts)).append(cEl("div").attr("class", "profile-form").tEl("Form: ").append(form1));
               var td1 = cEl("td").attr("colspan", "3").append(row3);
               var row = table.insertRow(rownumber + 1);
               row.attr("class", "profile").append(td1);
               firstClick = 1;
               lastClick = rownumber;
           }
           else if (firstClick == 1 && lastClick == rownumber) {
               firstClick = 0;
           }
           else {
               var e = JSON.parse(e);
               var level = getOverAllForm(e);//level
               var form = getUserForm(e);//form
               var form1 = genProgressBar(form).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");
               var globalRank = e.Rank;//globalrank
               var todayPts = e.TodayPoints;
               var yesterdayPts = e.YesterdayPoints;
               var lastWeekPts = e.DetailPoints;;
               var avatar = e.AvatarId;
               var row3 = cEl("div").attr("class", "row-fluid text-center")
                   .append(cEl("div").attr("class", "profile-el").append(cEl("img").attr("style", "height:27px;").attr("src", "style/images/avatars/" + avatar + ".png")))
                        .append(cEl("div").attr("class", "profile-el").tEl("Level: ").append(cEl("span").attr("class", "total-points label-warning").tEl(level)))
                            .append(cEl("div").attr("class", "profile-el").tEl("Global Rank: " + globalRank))
                                 .append(cEl("div").attr("class", "profile-el").tEl("Today Pts: " + todayPts))
                                   .append(cEl("div").attr("class", "profile-el").tEl("Yesterday Pts: " + yesterdayPts))
                                        .append(cEl("div").attr("style", "text-align:center").tEl("Last Week Pts: " + lastWeekPts)).append(cEl("div").attr("class", "profile-form").tEl("Form: ").append(form1));
               var td1 = cEl("td").attr("colspan", "3").append(row3);
               var row = table.insertRow(rownumber + 1);
               row.attr("class", "profile").append(td1);
               firstClick = 1;
               lastClick = rownumber;
           }
       });
}
