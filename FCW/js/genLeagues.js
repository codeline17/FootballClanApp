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
        var tabEl = cEl("li").listener("click",switchTabs, false).attr("class", "tab").append(cEl("a").attr("href", "#" + cId).tEl(tabs[i].Name));
        tabsEl.append(tabEl);

        var contEl = cEl("div").attr("class", "tab-block").attr("id", cId).append(content[i]).attr("style", "display:none;");

        contentEl.append(contEl);
    }

    tabsEl.childNodes[0].className = "tab active";
    tabsEl.childNodes[0].childNodes[0].className = "active";
    contentEl.childNodes[0].attr("class", "tab-block active").attr("style", "display: block; position: static; visibility: visible;");
    body.append(tabsEl).append(contentEl);

    mainC.append(body);

    /***After Event Assignments***/
    $('[data-toggle="tooltip"]').tooltip();

   
    $('body').off('click', '.pagination li');
    $("#livescore-table").bdt({
        pageRowCount: 100
    });
    pageToSelf("l");
    /****************************/
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
                tabs.push(l);
                var els = e[i].Users.length > 0 ? e[i].Users : e[i].Clans;
                var c = genLeagueTable(e[i].Name, els);
                content.push(c);
            }
        }

        genTabs(tabs, content);

    });
    
}
function getLeagueDatass() {
    
        $.post("Actions/User.aspx", { type: 'LDL2', PageNumber: 0, PageSize: 100 },
   function (e) {
       var test = JSON.parse(e);
       //console.log(test); //console.log(test[0]); 

   });
    
}

function genLeagueTable(n,u) {
    //User-Points
    //HEADER
    var mTag = cEl("div");
    var img = "default";
    for (var j = 0; j < leagueBadges.length; j++) {
        img = n.toLowerCase().indexOf(leagueBadges[j].type) > -1 ? leagueBadges[j].type : img;
    }
    var tTitle = cEl("h3").append(cEl("img").attr("src","style/images/leagues/" + img + ".png")).tEl(n);
    var tabTag = document.createElement("table");
    tabTag.id = "livescore-table";
    tabTag.className = "table table-hover";

    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "#").tEl("#")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Member").tEl("Member")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Points").tEl("Pts")));
    tHead.appendChild(hRow);

    var tBody = document.createElement("tbody");
    for (var i = 0; i < u.length; i++) {
        if(u[i].Points>0){

        
        var tdRang;
        if (u[i].PreviousLeagueRank > i + 1) {
            tdRang = cEl("td").tEl(i + 1).append(cEl("i").attr("class", "icon-up-dir-1 goneup"));
        } else if (u[i].PreviousLeagueRank < i + 1) {
            tdRang = cEl("td").tEl(i + 1).append(cEl("i").attr("class", "icon-down-dir-1 gonedown"));
        } else {
            tdRang = cEl("td").tEl(i + 1).append(cEl("i").attr("class", "icon-right-dir-1"));
        }
        if (i < 50) {
            tdRang.appendChild(cEl("i").attr("class", "icon-trophy gold"));
        }
        
        var tdUsername = cEl("td").tEl(u[i].Username ? u[i].Username : u[i].Name);
        var tdPoints = cEl("td").tEl(u[i].Points);
            var row = cEl("tr").append(tdRang).append(tdUsername).append(tdPoints);//.listener("click", showProfile);
        var level = getOverAllForm(u[i]);//level
        var form = getUserForm(u[i]);//form
        var form1 = genProgressBar(form).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");
        var globalRank = u[i].Rank;//globalrank
        var footballs = u[i].Credit2;//footballs
        var row2 = cEl("tr").attr("class", "profile-hidden");
        var row3 = cEl("div").attr("class", "row-fluid")
            .append(cEl("div").attr("class", "profile-el").tEl("Global Rank: " + globalRank))
                .append(cEl("div").attr("class", "profile-el").tEl("Level: ").append(cEl("span").attr("class", "total-points label-warning").tEl(level)))
                        .append(cEl("div").attr("class", "profile-el").tEl("White Balls: " + footballs)).append(cEl("div").attr("class", "profile-form").tEl("Form: ").append(form1));
        var td1 = cEl("td").attr("colspan","3").append(row3);
        //row2.append(td1);
        

        
        row.className = cuser.Username === u[i].Username || cuser.NameOfClan === u[i].Name ? "leader" : "";
        tBody.append(row);//.append(row2)
        
        }
    }

    tabTag.appendChild(tHead);
    tabTag.appendChild(tBody);

    mTag.append(tTitle).append(tabTag);

    return mTag;
}

function switchTabs(e) {
    var tabId = this.childNodes[0].getAttribute("href").replace("#", "");

    var cts = document.getElementsByClassName("tab-block");

    for (var i = 0; i < cts.length; i++) {
        if (cts[i].id === tabId) {
            cts[i].attr("style", "display: block; position: static; visibility: visible;");
        } else {
            cts[i].attr("style", "display:none;");
        }
    }

    var tbs = document.getElementsByClassName("tab");

    for (var j = 0; j < tbs.length; j++) {
        tbs[j].className = tbs[j].className.replace("active","").replace(" ","");
    }

    this.className = "tab active";
}
function showProfile() {
    
    var index = this.rowIndex + 1;
    var tabela = document.getElementById("livescore-table");
    var length = tabela.rows.length;
    
    if (tabela.rows.item(index).className != "profile-show") {
        for (var i = 0; i < length; i += 2) {
            if (i === this.rowIndex) { }
            else {
                if (i == 0) {
                    tabela.rows.item(i).className = "profile-show";
                } else {
                    tabela.rows.item(i).className = "profile-hidden";
                }
            }
        }
    }
    if (tabela.rows.item(index).className === "profile-show") {
        tabela.rows.item(index).className = "profile-hidden";
    } else {
        tabela.rows.item(index).className = "profile-show";
    }
}