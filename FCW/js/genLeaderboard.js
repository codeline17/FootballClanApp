var favIds = new Array();
var lbAction = "favs";

function genLeaderboardTabs() {
    var mainTabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                            .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                            .append(
                                cEl("li").listener("click", switchLbTabs, false).attr("class", "tab active").append(cEl("a").wr({el : "favs"}).attr("id", "lbFavorites").tEl("Favorites"))
                            ).append(
                                cEl("li").listener("click", switchLbTabs, false).attr("class", "tab").append(cEl("a").wr({el : "users"}).attr("id", "lbGlobal").tEl("Global"))
                            ).append(
                                cEl("li").listener("click", switchLbTabs, false).attr("class", "tab").append(cEl("a").wr({el : "clans"}).attr("id", "lbClans").tEl("Clans"))
                            ).append(
                                cEl("li").listener("click", switchLbTabs, false).attr("class", "tab").append(cEl("a").wr({el : "trophies"}).attr("id", "lbTrophies").tEl("Trophies"))
                            ));

    var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

    var tbMain = cEl("div").attr("class", "tab-block active").attr("id", "tbMain").attr("style", "display: block; position: static; visibility: visible;");
    
    tabContainer.append(tbMain);

    mainTabs.append(tabContainer);

    var mainC = document.getElementById("mainContainer");
    mainC.append(mainTabs);

    getFavorites();
    var first = cEl("div").attr("id", "firstpageGlobal").attr("style", "display:inline-block").listener("click", firstelGlobal).tEl(" First ");
    var previous = cEl("div").attr("id", "previousGlobal").attr("style", "display:inline-block").listener("click", previouselGlobal).tEl(" << ");
    var next = cEl("div").attr("id", "nextGlobal").attr("style", "display:inline-block").listener("click", nextelGlobal).tEl(" >> ");
    var mypage = cEl("div").attr("id", "mypageGlobal").attr("style", "display:inline-block").tEl(" ");
    var lastpage = cEl("div").attr("id", "lastpageGlobal").attr("style", "display:inline-block").listener("click", lastellGlobal).tEl(" Last Page ");
    var Pagination = cEl("div").attr("id", "paginationGlobal").attr("class", "pull-right").attr("style","display:none");
    Pagination.append(cEl("br")).append(first).append(previous).append(mypage).append(next).append(lastpage);
    mainC.append(Pagination);

}
var lastpage;
function genGlobalUserTable(objs, id) {
    pageNumber = objs.PageNumber;
    //Table Tag
    var mainTag = document.createElement("table");
    mainTag.id = id;
    mainTag.className = "table table-hover";

    //Header
    var head = [{ Title: "Fav", Text: "Fav" }, { Title: "Rank", Text: "Rank" }, { Title: "Username", Text: "User" },
                { Title: "Points", Text: "Pts" }]; //, { Title: "Level", Text: "Lvl" }, { Title: "Form", Text: "Form" }
    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    for (i = 0; i < head.length; i++) {
        var hElement = cEl("th").tEl(head[i].Text);
        hRow.append(hElement);
    }
    
    tHead.append(hRow);
    var tBody = document.createElement("tbody");

    var first = 0;
    for (var i = pageNumber * 100; i < objs.Users.length + pageNumber * 100; i++) {
        var j = i - (pageNumber * 100);
        var pg = i - 100;
        if (pageNumber == 1) {
            pg = i - 99 + pageNumber - 1;
        }
        else {
            pg = i - 100 + pageNumber - 1;
        }
        var rank = objs.Users[j].Rank + pageNumber * 100;
        var favClass;
        var rowClass = "";
        var favRow = "";
        
            var objusername = objs.Users[j].Username;
            if (objusername.length > 10) {
                objusername = objusername.substr(0, 8) + "...";
            }
            favClass = favIds.indexOf(objs.Users[j].Username) > -1 ? "icon-star-1" : "icon-star-empty-1";
            rowClass = objs.Users[j].Username === cuser.Username ? "self" : "regular";
            favRow = cEl("tr").attr("class", rowClass).wr({ Guid: objs.Users[j].Guid }).listener("click", function () { showFavoritesProfile(this, "uTbl"); });
        favRow.append(cEl("td").append(cEl("i").wr({ uname: objs.Users[j].Username }).attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
                  .append(cEl("td").tEl(pg)) //Rank
                  .append(cEl("td").tEl(objusername)) //Username
                  .append(cEl("td").tEl(objs.Users[j].Points)); //Points
            //.append(cEl("td").tEl(getOverAllForm(objs[i]))) //Level
            //.append(cEl("td").tEl(getUserForm(objs[i]))); //Form
        //tBody.append(genSingleMatchRow(matches[j]));
        tBody.append(favRow);
    }
    mainTag.append(tHead);
    mainTag.append(tBody);
    pageNumber = objs.PageNumber;
    document.getElementById("mypageGlobal").innerHTML = pageNumber;
    document.getElementById("paginationGlobal").attr("style", "display:inline-block");
    return mainTag;
}

function firstelGlobal() {
    pageNumber = 1;
    genGlobal(pageNumber, 100);
}
function previouselGlobal() {
    if (pageNumber == 1)
        return;
    pageNumber -= 1;
    genGlobal(pageNumber, 100);
}
function nextelGlobal() {
    if (pageNumber == lastpage) {
        return;
    }
    pageNumber += 1;
    genGlobal(pageNumber, 100);

}
function lastellGlobal() {
    pageNumber = lastpage;
    
    genGlobal(pageNumber, 100)
}








function genLbUserTable(objs, id) {
    var i = 0;
    //Table Tag
    var mainTag = document.createElement("table");
    mainTag.id = id;
    mainTag.className = "table table-hover";

    //Header
    var head = [{ Title: "Fav", Text: "Fav" }, { Title: "Rank", Text: "Rank" }, { Title: "Username", Text: "User" },
                { Title: "Points", Text: "Pts" }]; //, { Title: "Level", Text: "Lvl" }, { Title: "Form", Text: "Form" }
    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    for (i = 0; i < head.length; i++) {
        var hElement = cEl("th").tEl(head[i].Text);
        hRow.append(hElement);
    }
    tHead.append(hRow);

    var tBody = document.createElement("tbody");
    
    var first = 0;
    for (i = 0; i < objs.length; i++) {
       
        var favClass;
        var rowClass = "";
        var favRow = "";
        if (id === "fTbl" && first == 0 && cuser.Rank < objs[i].Rank) {
            rowClass1 = "self";
            football1 = cuser.Credit2;
            var cusername = cuser.Username;
            if (cusername.length > 10) {
                cusername = cusername.substr(0, 8)+"...";
            }
            form1 = genProgressBar(getUserForm(cuser)).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");
            rowtd1 = cEl("td").attr("colspan", "4");
            favRow1 = cEl("tr").attr("class", rowClass1).wr({ Guid: cuser.Guid }).listener("click", function () { showFavoritesProfile(this, "fTbl"); });
            favRow1.append(cEl("td").append(cEl("i").attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
              .append(cEl("td").tEl(cuser.Rank)) //Rank
              .append(cEl("td").tEl(cusername)) //Username
              .append(cEl("td").tEl(cuser.Points)); //Points
              //.append(cEl("td").tEl(getOverAllForm(cuser))) //Level
            //.append(cEl("td").tEl(getUserForm(cuser))); //Form
            
        }
         
        else if (id === "fTbl" && first == 0 && cuser.Rank > objs[i].Rank) {
            rowClass1 = "self";
            football1 = cuser.Credit2;
            var cusername = cuser.Username;
            if (cusername.length > 10) {
                cusername = cusername.substr(0, 8) + "...";
            }
            favRow1 = cEl("tr").attr("class", rowClass1).wr({ Guid: cuser.Guid }).listener("click", function () { showFavoritesProfile(this,"fTbl"); });
            favRow1.append(cEl("td").append(cEl("i").attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
              .append(cEl("td").tEl(cuser.Rank)) //Rank
              .append(cEl("td").tEl(cusername)) //Username
              .append(cEl("td").tEl(cuser.Points)); //Points
            //.append(cEl("td").tEl(getOverAllForm(cuser))) //Level
            //.append(cEl("td").tEl(getUserForm(cuser))); //Form

        }
        if (id === "fTbl"){
            var objusername = objs[i].Username;
            if (objusername.length > 10) {
                objusername = objusername.substr(0, 8)+"...";
            }
            football = objs[i].Credit2;
            favClass = favIds.indexOf(objs[i].Username) > -1 ? "icon-star-1" : "icon-star-empty-1";
            rowClass = objs[i].Username === cuser.Username ? "self" : "regular";
            favRow = cEl("tr").attr("class", rowClass).wr({ Guid: objs[i].Guid }).listener("click", function () { showFavoritesProfile(this,"fTbl"); });
            favRow.append(cEl("td").append(cEl("i").wr({ uname: objs[i].Username }).attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
                  .append(cEl("td").tEl(objs[i].Rank)) //Rank
                  .append(cEl("td").tEl(objusername)) //Username
                  .append(cEl("td").tEl(objs[i].Points)); //Points
            //.append(cEl("td").tEl(getOverAllForm(objs[i]))) //Level
            //.append(cEl("td").tEl(getUserForm(objs[i]))); //Form

        }
        if (id === "fTbl" && first == 0 && cuser.Rank < objs[i].Rank) {
            tBody.append(favRow1);
            first = 1;
        }
        //tBody.append(genSingleMatchRow(matches[j]));
        tBody.append(favRow);
        if (id === "fTbl" && first == 0 && cuser.Rank > objs[i].Rank && i==objs.length-1) {
            tBody.append(favRow1);
        }
        
        
    }
    if (objs.length == 0) {
        var favClass = "icon-star-1";
        var rowClass = "";
        var favRow = "";
        var form;
        var row1;
        var rowtd;
        var row3;
        var football;
        var row2 = "";
        rowClass1 = "self";
        football1 = cuser.Credit2;
        var cusername = cuser.Username;
        if (cusername.length > 10) {
            cusername = cusername.substr(0, 8) + "...";
        }
        favRow1 = cEl("tr").attr("class", rowClass1).wr({ Guid: cuser.Guid }).listener("click", function () { showFavoritesProfile(this,"fTbl"); });
        favRow1.append(cEl("td").append(cEl("i").attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
          .append(cEl("td").tEl(cuser.Rank)) //Rank
          .append(cEl("td").tEl(cusername)) //Username
          .append(cEl("td").tEl(cuser.Points)); //Points
        //.append(cEl("td").tEl(getOverAllForm(cuser))) //Level
        //.append(cEl("td").tEl(getUserForm(cuser))); //Form
        tBody.append(favRow1);
    }
    mainTag.append(tHead);
    mainTag.append(tBody);
    return mainTag;
}

function genLbClanTable(objs, id) {
    var i = 0;
    //Table Tag
    var mainTag = cEl("table");
    mainTag.id = id;
    mainTag.className = "table table-hover";

    //Header
    var head = [{ Title: "Rank", Text: "#" }, { Title: "Username", Text: "User" }, { Title: "Points", Text: "Pts" }];
    var tHead = cEl("thead");
    var hRow = cEl("tr");
    for (i = 0; i < head.length; i++) {
        var hElement = cEl("th").tEl(head[i].Text);
        hRow.append(hElement);
    }
    tHead.append(hRow);

    var tBody = cEl("tbody");

    var clanName;
    for (i = 0; i < objs.length; i++) {
        var clanName = objs[i].Name;
        if (clanName.length > 10) {
            clanName = clanName.substr(0, 16) + "...";
        }
        var avg = objs[i].Points / objs[i].UserCount;
        avg = avg.toFixed(2);
        var rowClass = objs[i].Name === cuser.NameOfClan ? "self" : "regular";
        var row2 = cEl("tr").attr("class", "profile-hidden");
        var leader = cEl("div").attr("class", "pull-left").tEl("Leader : ");
        var leaderName = cEl("div").attr("class", "pull-right").tEl(objs[i].Leader);
        var users = cEl("div").attr("class", "pull-left").tEl("Users : ");
        var userCnt = cEl("div").attr("class", "pull-right").tEl(objs[i].UserCount + "/11");
        var trophies = cEl("div").attr("class", "pull-left").tEl("Trophies : ");
        var trophiesNr = cEl("div").attr("class", "pull-right").tEl(objs[i].Trophies.length);
        var clan = cEl("div").attr("class", "pull-left").tEl("Clan avg : ");
        var clanavg = cEl("div").attr("class", "pull-right").tEl(avg);
        var favRow = cEl("tr").attr("class", rowClass);
        var id = objs[i].Id
        favRow.append(cEl("td").tEl(objs[i].Rank)) //Rank
            .append(cEl("td").tEl(objs[i].Name))//.append(cEl("td").append(cEl("img").attr("style", "width:30px; margin-right:30px;").wr({ id: id }).listener("click", function () { showClanProfile(this); }).attr("src", "style/images/clans/" + objs[i].Image + ".png")).append(cEl("span").tEl(clanName))) //Clan NamecEl("td").tEl(objs[i].Name)
            .append(cEl("td").tEl(objs[i].Points)); //Points
        tBody.append(favRow);
    }

    mainTag.append(tHead);
    mainTag.append(tBody);
    return mainTag;
}

function genTrophyTable() {
    var trTbl = cEl("table").attr("class", "trophies").append(cEl("tr").append(cEl("td")).append(cEl("td")).append(cEl("td")).append(cEl("td")))
                                                      .append(cEl("tr").append(cEl("td")).append(cEl("td")).append(cEl("td")).append(cEl("td")))
                                                      .append(cEl("tr").append(cEl("td")).append(cEl("td")).append(cEl("td")).append(cEl("td")))
                                                      .append(cEl("tr").append(cEl("td")).append(cEl("td")).append(cEl("td")).append(cEl("td")))
                                                      .append(cEl("tr").append(cEl("td")).append(cEl("td")).append(cEl("td")).append(cEl("td")));
    return trTbl;
}
function genGlobal(pagenumber,pagesize) {
    var uObj;
    $.post("Actions/User.aspx", { type: "GAU",PageNumber:pagenumber,PageSize:pagesize },
   function (e) {
       var uObj = JSON.parse(e);
       lastpage = uObj.TotalPages-2;
       appendToItem("tbMain", genGlobalUserTable(uObj, "uTbl"), "-");
   });
}

function genLbClans() {
    var cObj;
    $.post("Actions/User.aspx", { type: "GAC" },
   function (e) {
       cObj = JSON.parse(e);
       appendToItem("tbMain", genLbClanTable(cObj, "cTbl"), "-");
       pageToSelf("c");
   });
}

function genTrophies() {
    
}

function getFavorites() {
    var fObj;
    favIds = new Array();
    $.post("Actions/User.aspx", { type: "GFA" },
   function (e) {
       fObj = JSON.parse(e);
       favIds = new Array();
       for (var i = 0; i < fObj.length; i++) {
           favIds.push(fObj[i].Username);
       }
       appendToItem("tbMain", genLbUserTable(fObj, "fTbl"), "-");
       
   });
}

function getAllUsers() {
    
}

function getClanRanking() {
    
}

function toggleFavorite(e) {
    var cc = e.target;
    switch (cc.className) {
        case "icon-star-1 lbFav":
            cc.className = "icon-star-empty-1 lbFav";
            break;
        case "icon-star-empty-1 lbFav":
            cc.className = "icon-star-1 lbFav";
            if (lbAction === "favs") {
                e.target.parentNode.parentNode.parentNode.removeChild(e.target.parentNode.parentNode);
            }
            break;
    }

    $.post("Actions/User.aspx", { type: "TGF", FavUname : cc.wrapper.uname },
    function (resp) {
        if (resp === "1") {
        }
    });
}
function switchLbTabs(e) {
    pageNumber = 0;
    var tbs = e.target.parentNode.parentNode.childNodes;

    var clicked = e.target.wrapper.el;
    lbAction = clicked;

    for (var j = 0; j < tbs.length; j++) {
        tbs[j].className = tbs[j].className.replace("active", "").replace(" ", "");
    }

    this.className = "tab active";

    switch (clicked) {
        case "favs":
            getFavorites();
            document.getElementById("paginationGlobal").attr("style", "display:none");
            break;
        case "users":
            genGlobal(pageNumber,100);
            break;
        case "clans":
            genLbClans();
            document.getElementById("paginationGlobal").attr("style", "display:none");
            break;
        case "trophies":
            appendToItem("tbMain", genTrophyTable());
            document.getElementById("paginationGlobal").attr("style", "display:none");
            break;
    }
}

function pageToSelf(opt) {
    var pages = document.getElementsByClassName("pagination");

    switch (opt) {
        case "u":
            pages[0].childNodes[Math.floor(cuser.Rank / 100) + 1].childNodes[0].click();
            break;
        case "c":
            var own = document.getElementsByClassName("self")[0];
            if (own) {
                var pos = own.childNodes[0].innerText;
                pages[0].childNodes[Math.floor(pos / 100) + 1].childNodes[0].click();
            }
            break;
            
    }
}

function isHidden(el) {
    return (el.style.display === "none");
}


function showFavoritesProfile(el, Id) {
    var id = $(".etabs li.active").index();
    var guid = el.wrapper.Guid;
    var rownumber;

    var table = document.getElementById(Id);
    var lastTableEl = document.getElementById(Id).rows.length;
    var todyaDate = getFullDate(new Date(), 0);
    var lastWeekDate = getFullDate(new Date(), -7);
    $.post("Actions/User.aspx", { type: "RFR", userGuid: guid, fromDateDetails: lastWeekDate, toDateDetails: todyaDate },
       function (e) {
           var livescore = "#"+ Id+" tr";
           var livescore1 = "#"+ Id+" .profile";
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
               var row3 = cEl("div").attr("class", "row-fluid text-center")
                   .append(cEl("div").attr("class", "profile-el").append(cEl("img").attr("style", "height:27px;").attr("src", "style/images/avatars/" + avatar + ".png")))
                        .append(cEl("div").attr("class", "profile-el").tEl("Level: ").append(cEl("span").attr("class", "total-points label-warning").tEl(level)))
                            .append(cEl("div").attr("class", "profile-el").tEl("Global Rank: " + globalRank))
                                 .append(cEl("div").attr("class", "profile-el").tEl("Today Pts: " + todayPts))
                                   .append(cEl("div").attr("class", "profile-el").tEl("Yesterday Pts: " + yesterdayPts))
                                        .append(cEl("div").attr("style", "text-align:center").tEl("Last Week Pts: " + lastWeekPts)).append(cEl("div").attr("class", "profile-form").tEl("Form: ").append(form1));
               var td1 = cEl("td").attr("colspan", "4").append(row3);
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
               var td1 = cEl("td").attr("colspan", "4").append(row3);
               var row = table.insertRow(rownumber + 1);
               row.attr("class", "profile").append(td1);
               firstClick = 1;
               lastClick = rownumber;
           }
       });
}
function showGlobalProfile() {
    
    var index = this.rowIndex + 1;
    var tabela = document.getElementById("uTbl");
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
/*
function showClanProfile(id) {
    var Id = id.wrapper.id;
    $.post("Actions/User.aspx", { type: "CDL", Id: Id },
      function (e) {

          e = JSON.parse(e);
          contextClan = e;
          var mainC = cEl("div");
          mainC.append(genClanHeader(e));
          var rFluid = document.createElement("div");
          rFluid.id = "tblContainer";
          var opts = "";
          var exGrid = document.getElementById("match-table");
          if (exGrid) {
              exGrid.parentNode.removeChild(exGrid);
          }
          rFluid.appendChild(genClanTable(e));
          mainC.appendChild(rFluid);



          var exMd = document.getElementById("clanProfileModal");
          if (exMd) {
              exMd.parentNode.removeChild(exMd);
          }
          
          var mdHeader = cEl("div").attr("class", "modal-header").append(cEl("button").attr("type", "button").attr("class", "close").attr("data-dismiss", "modal").attr("aria-label", "Close")
                      .append(cEl("span").attr("aria-hidden", "true").tEl("x"))).append(cEl("h4").tEl(e.Name));

          var mdFooter = cEl("div").attr("class", "modal-footer").attr("id", "mdFooter");
          var mdMain = cEl("div").attr("class", "modal fade").attr("id", "clanProfileModal").attr("style","min-height:94vh;top:15px!important;").attr("tabindex", "-1").attr("role", "dialog")
                  .append(cEl("div").attr("class", "modal-dialog").attr("role", "document")
                  .append(cEl("div").attr("class", "modal-content").append(mdHeader))
                  .append(mainC));
              

          document.body.append(mdMain);
          
          $("#nBday").datepicker({
              format: "dd/mm/yyyy"
          }).on("changeDate", function (e) {
              $(".datepicker.dropdown-menu").hide();
          });
          $("#clanProfileModal").modal("show");















      });
   
}*/