function genTable(id, matches, state) {

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
            odd.setAttribute("title", game.Outcomes[i].Name.replace("[Home]", home).replace("[Away]", away).replace("[Draw]", "Draw").replace(" ", ""))
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
    mainTag.className = "table table-hover";

    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Member Name").tEl("Member Name")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Member Since").tEl("Member Since")));
    tHead.appendChild(hRow);

    //body
    var tBody = document.createElement("tbody");

    for (var j = 0; j < e.Users.length; j++) {
        var row = cEl("tr").append(cEl("td").tEl(e.Users[j].Username)).append(cEl("td").tEl(e.Users[j].InClanSince));
        row.className = e.Users[j].Username === e.Leader ? "leader" : "";
        tBody.append(row);
    }
    mainTag.appendChild(tHead);
    mainTag.appendChild(tBody);

    return mainTag;
}