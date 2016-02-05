function genTable(id, matches) {

    var head = getHead(matches[0]);

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
    tHead.appendChild(tHead);
    
    //body
    var tBody = document.createElement("tbody");
    for (var j = 0; j < matches; j++) {
        tBody.appendChild(getMatchRow(matches[i]));
    }

    mainTag.appendChild(tHead);
    mainTag.appendChild(tBody);
}


function getHead(sMatch) {
    var r = new Array();

    var el = { Title: "Match", Text: "Match" }
    r.push(el);
    el = { Title: "Time", Text: "Time" };
    r.push(el);
    el = { Title: "League", Text: "League" };
    r.push(el);

    for (var i = 0; i < sMatch.Games; i++) {
        el = { Title: sMatch.Games[i].Name, Text: sMatch.Games[i].Slug }
        r.push(el);
    }

    return r;
}

function getMatchRow(match) {
    var tr = document.createElement("tr");
    var td = document.createElement("td");
    var span = document.createElement("span");

    /**fixed**/
    //Match Name
    span.setAttribute("data-toggle", "tooltip");
    span.setAttribute("data-placement", "top");
    span.setAttribute("title", match.HomeTeam.Name + "-" + match.AwayTeam.Name);
    span.innerText = getFixtureName(match);
    td.appendChild(span);
    tr.appendChild(span);
    //Match Name
    td = document.createElement("td");
    span.setAttribute("data-toggle", "tooltip");
    span.setAttribute("data-placement", "top");
    span.setAttribute("title", match.ShortTime);
    span.innerText = match.ShortTime;
    td.appendChild(span);
    tr.appendChild(span);
    //Match Name
    td = document.createElement("td");
    span.setAttribute("data-toggle", "tooltip");
    span.setAttribute("data-placement", "top");
    span.setAttribute("title", match.League.Name);
    span.innerText = match.League.Name.substring(0, 8);
    td.appendChild(span);
    tr.appendChild(span);
    /*********/


}

function getGameCell(game) {

    
     /*for (var j = 0; j < matches[h].Games.length; j++) {
            inMatchGroups += "<td>";
            for (var k = 0; k < matches[h].Games[j].Outcomes.length; k++) {
                var cl = (matches[h].Sealed ? "greyed" : "");
                cl += (matches[h].Sealed ? " closed" : "");
                var event = !matches[h].Sealed && state;
                inMatchGroups += "<a class=\"odd " + cl + "\" " + (event ? "onclick = \"setPrediction(this)\"" : "") +
                    " data-toggle=\"tooltip\" data-placement=\"top\" title=\"" +
                    getShortTeamName(matches[h].Games[j].Outcomes[k].Name, matches[h], 100) + "\" data-group=\"" +
                    matches[h].Games[j].Slug + "\" data-odd=\"" + matches[h].ID + "|" + matches[h].Games[j].Slug + "|" +
                    matches[h].Games[j].Outcomes[k].Name + "\" >" + getShortTeamName(matches[h].Games[j].Outcomes[k].Name, matches[h], 5) +
                    "</a> ";
            }
            inMatchGroups += "</td>";
        }*/
    
}