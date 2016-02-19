function genTabs(tabs, content) {

    var mainC = document.getElementById("mainContainer");
    mainC.innerHTML = "";
    mainC.append(cEl("h3").attr("id", "LivescoreTitle").tEl("Leagues"));

    var exTab = document.getElementById("tabsLeagues");
    if (exTab) {
        exTab.parentNode.removeChild(exTab);
    }

    var body = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true").attr("id","tabsLeagues");

    if (tabs.length === 0 || content.length === 0 || tabs.length !== content.length) {
        return body;
    }

    var tabsEl = cEl("ul").attr("class", "etabs");
    var contentEl = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

    for (var i = 0; i < tabs.length; i++) {
        var cId = makeid();
        var tabEl = cEl("li").attr("class", "tab").append(cEl("a").attr("href", "#" + cId).tEl(tabs[i].Name));
        tabsEl.append(tabEl);

        var contEl = cEl("div").attr("class", "tab-block").attr("id", cId).append(content[i]).attr("style", "display:none;");

        contentEl.append(contEl);
    }

    tabsEl.childNodes[0].className = "tab active";
    tabsEl.childNodes[0].childNodes[0].className = "active";
    contentEl.childNodes[0].attr("class", "tab-block active").attr("style", "display: block; position: static; visibility: visible;");
    body.append(tabsEl).append(contentEl);

    mainC.append(body);
}


function getLeagueData() {
    $.post("Actions/User.aspx", { type: "LDL"},
    function (e) {
        e = JSON.parse(e);

        var tabs = [];
        var content = [];
            
        for (var i = 0; i < e.length; i++) {
            if (e[i].Name) {
                var l = { Name: e[i].Name }
                tabs[i] = l;

                var c = genLeagueTable(e[i].Users);
                content[i] = c;
            }
        }

        genTabs(tabs, content);

    });
}

function genLeagueTable(u) {
    //User-Points
    //HEADER
    var mainTag = document.createElement("table");
    mainTag.id = "livescore-table";
    mainTag.className = "table table-hover";

    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "League").tEl("Member")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Start Time").tEl("Points")));
    //hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Score").tEl("Score")));
    tHead.appendChild(hRow);

    var tBody = document.createElement("tbody");
    for (var i = 0; i < u.length; i++) {
        var tdUsername = cEl("td").tEl(u[i].Username);
        var tdPoints = cEl("td").tEl(u[i].Points);
        var row = cEl("tr").append(tdUsername).append(tdPoints);
        tBody.append(row);
    }

    mainTag.appendChild(tHead);
    mainTag.appendChild(tBody);

    return mainTag;
}