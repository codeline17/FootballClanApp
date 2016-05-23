var pageNumber = 0;
var tabIdPagination = 0;
var competitionType;
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
    var contentEl = cEl("div").attr("class", "panel-container").attr("id","leagueTable").attr("style", "overflow: hidden;");

    for (var i = 0; i < tabs.length; i++) {
        var cId = makeid();
        var contEl = cEl("div").attr("class", "tab-block").attr("id", cId).append(content[i]).attr("style", "display:none;");
        contentEl.append(contEl);
        if (i == tabIdPagination) {
            var tabEl = cEl("li").listener("click", switchTabs, false).attr("class", "tab active").append(cEl("a").attr("href", "#" + cId).attr("class", "active").tEl(tabs[i].Name));
            contentEl.childNodes[i].attr("class", "tab-block active").attr("style", "display: block; position: static; visibility: visible;");
        } else {
            var tabEl = cEl("li").listener("click", switchTabs, false).attr("class", "tab").append(cEl("a").attr("href", "#" + cId).tEl(tabs[i].Name));
            contentEl.childNodes[i].attr("class", "tab-block active").attr("style", "display: none;");
        }
        
        tabsEl.append(tabEl);
        
    }
    var Pagination = cEl("div").attr("id", "paginationCompetation").attr("class", "pull-right");
    //tabsEl.childNodes[0].className = "tab active";
    //tabsEl.childNodes[0].childNodes[0].className = "active";
    //alert(tabsEl.childNodes.length);
    
    body.append(tabsEl).append(contentEl).append(Pagination);
    mainC.append(body);
}

function firstel() {
    pageNumber = 1;
    $('html, body').animate({
        scrollTop: 0
    }, 0);
    getLeagueData(pageNumber, 100);
    
}
function previousel() {
    if (pageNumber == 1)
        return;
    $('html, body').animate({
        scrollTop: 0
    }, 0);
    pageNumber -= 1;
    getLeagueData(pageNumber, 100);
}
function nextel() {
    $('html, body').animate({
        scrollTop: 0
    }, 0);
    pageNumber += 1;
    getLeagueData(pageNumber, 100);
}
function genLeagueTable(n,u,pagenumber,i,leagueType) {
    //User-Points
    //HEADER
    var mTag = cEl("div");
    var img = "default";
    for (var j = 0; j < leagueBadges.length; j++) {
        img = n.toLowerCase().indexOf(leagueBadges[j].type) > -1 ? leagueBadges[j].type : img;
    }
    var tTitle = cEl("h3").append(cEl("img").attr("src","style/images/leagues/" + img + ".png")).tEl(n);
    var tabTag = document.createElement("table");
    tabTag.id = "livescore-table"+i;
    tabTag.className = "table table-hover livescore-table";
    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "#").tEl("#")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Member").tEl("Member")));
    hRow.append(cEl("th").append(cEl("span").attr("data-toggle", "tooltip").attr("data-placement", "top").attr("title", "Points").tEl("Pts")));
    tHead.appendChild(hRow);

    var tBody = document.createElement("tbody");
    
    for (var i = pagenumber*100; i < u.length+pagenumber*100; i++) {
        var j = i - (pagenumber * 100);
        var pg = i - 100;
        var compareGoneUpDown = (j + (pagenumber-1)*100);
        if (pagenumber == 1) {
           pg = i - 99+pagenumber-1;
        }
        else {
           pg = i - 100+pagenumber-1;
        }
        var tdRang;

        if (u[j].PreviousLeagueRank > compareGoneUpDown+1) {
            tdRang = cEl("td").tEl(pg ).append(cEl("i").attr("class", "icon-up-dir-1 goneup"));
        } else if (u[j].PreviousLeagueRank < compareGoneUpDown+1) {
            tdRang = cEl("td").tEl(pg ).append(cEl("i").attr("class", "icon-down-dir-1 gonedown"));
        } else {
            tdRang = cEl("td").tEl(pg ).append(cEl("i").attr("class", "icon-right-dir-1"));
        }
        if (pg < 51 && competitionType == 1) {
            tdRang.appendChild(cEl("i").attr("class", "icon-trophy gold"));
        } else if (pg < 4 && competitionType == 2) {
            tdRang.appendChild(cEl("i").attr("class", "icon-trophy gold"));
        }
        var tdUsername = cEl("td").tEl(u[j].Username ? u[j].Username : u[j].Name);
        var tdPoints = cEl("td").tEl(u[j].Points);
        if (leagueType==1){
            var guid = u[j].Guid;
            var row = cEl("tr").wr({ Guid: guid }).listener("click", function () { showProfile(this); }).append(tdRang).append(tdUsername).append(tdPoints);
        }
        else {
            var guid = u[j].Id;

            var row = cEl("tr").wr({ id: guid }).listener("click", function () { showClanProfile(this); }).append(tdRang).append(tdUsername).append(tdPoints);
        }
        
        row.className = cuser.Username === u[j].Username || cuser.NameOfClan === u[j].Name ? "leader" : "";
        tBody.append(row);
    }
    tabTag.appendChild(tHead);
    tabTag.appendChild(tBody);
    mTag.append(tTitle).append(tabTag);
    return mTag;
    
}

function switchTabs(e) {
    tabIdPagination = $(this).index();
    pageNumber = 0;
    getLeagueData(pageNumber, 100);
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

var firstClick = 0;
var lastClick = 0;
function showProfile(el) {
    var id = $(".etabs li.active").index();
    var guid = el.wrapper.Guid;
    var rownumber;
    
    var table = document.getElementById("livescore-table"+id);
    var lastTableEl = document.getElementById("livescore-table"+id).rows.length;
    var todyaDate = getFullDate(new Date(), 0);
    var lastWeekDate = getFullDate(new Date(), -7);
    $.post("Actions/User.aspx", { type: "RFR", userGuid: guid, fromDateDetails: lastWeekDate, toDateDetails: todyaDate },
       function (e) {
           var livescore = "#livescore-table" + id + " tr";
           var livescore1 = "#livescore-table"+id+" .profile";
           if ($(livescore).hasClass("profile")) {
               $(livescore1).remove();
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
               var lastWeekPts = e.DetailPoints;
               var avatar = e.AvatarId;
               var row3 = cEl("div").attr("class", "row-fluid")
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
           else if(firstClick==1&&lastClick==rownumber) {
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
               var row3 = cEl("div").attr("class", "row-fluid")
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

function getLeagueData(pagenumber, pagesize) {
    var loadcontainer = cEl("div").attr("style", "position:fixed;width:100vw;height:100vh;background-color:rgba(0,0,0,0.3);top:0;left:0;z-index:999;");
    var animation = cEl("div").attr("class", "cssload-loader").attr("id", "loader").tEl("Loading...");
    var el = document.getElementById('mainContainer');
    if (document.getElementById("leagueTable")) {
       // document.getElementById("leagueTable").innerHTML = " ";
       // document.getElementById("paginationCompetation").innerHTML = " ";
    }
    loadcontainer.append(animation);
    el.appendChild(loadcontainer);
    $.post("Actions/User.aspx", { type: 'LDL2', PageNumber: pagenumber, PageSize: pagesize },
function (e) {
    e = JSON.parse(e);
    if(e.length===0){

    }
    var tabs = [];
    var content = [];
    for (var i = 0; i < e.length; i++) {
       
        if (e[i].Name) {
            competitionType = e[tabIdPagination].LeagueType;
            var l = { Name: e[i].Name }
            tabs.push(l);
            var els = e[i].Users.length > 0 ? e[i].Users : e[i].Clans;
            var c = genLeagueTable(e[i].Name, els, e[i].Page, i,e[i].LeagueType);
            content.push(c);
            
        }
        if (e[i].Page) {
            genTabs(tabs, content);
            pageNumber = e[tabIdPagination].Page;
            var first = cEl("div").attr("id", "firstpage").attr("style", "display:inline-block").listener("click", firstel).tEl(" First ");
            var previous = cEl("div").attr("id", "previous").attr("style", "display:inline-block").listener("click", previousel).tEl(" << ");
            var next = cEl("div").attr("id", "next").attr("style", "display:inline-block").listener("click", nextel).tEl(" >> ");
            var mypage = cEl("div").attr("id", "mypage").attr("style", "display:inline-block").tEl(" " + pageNumber + " ");
            var Pagination = document.getElementById("paginationCompetation");
            Pagination.append(first).append(previous).append(mypage).append(next);
            pageNumber = e[tabIdPagination].Page;
            
        } else {

            var first = cEl("div").attr("id", "firstpage").attr("style", "display:inline-block").listener("click", firstel).tEl(" First ");
            var previous = cEl("div").attr("id", "previous").attr("style", "display:inline-block").listener("click", previousel).tEl(" << ");
            var next = cEl("div").attr("id", "next").attr("style", "display:inline-block").tEl(" >> ");
            var mypage = cEl("div").attr("id", "mypage").attr("style", "display:inline-block").tEl(" " + pageNumber + " ");
            var Pagination = document.getElementById("paginationCompetation");
            Pagination.innerHTML = " ";
            Pagination.append(first).append(previous).append(mypage).append(next);


        }
    }
    
    
});
    
}
