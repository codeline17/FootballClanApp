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
    
    
    for (i = -1; i < objs.length; i++) {
       
        var favClass ="icon-star-1";
        var rowClass ="";
        var favRow = "";
        var form;
        var row1;
        var rowtd;
        var row3;
        var football;


        if (id === "fTbl" && i === -1) {
            rowClass = "self";
            football = cuser.Credit2;
            var cusername = cuser.Username;
            if (cusername.length > 10) {
                cusername = cusername.substr(0, 8)+"...";
            }
            form = genProgressBar(getUserForm(cuser)).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");
            row1 = cEl("tr").attr("class", "profile-hidden");
            rowtd = cEl("td").attr("colspan", "4");
            row3 = cEl("div").attr("class", "row-fluid")
                .append(cEl("div").attr("class", "profile-el").tEl("Level: ").append(cEl("span").attr("class", "total-points label-warning").tEl(getOverAllForm(cuser))))
                       .append(cEl("div").attr("class", "profile-el").tEl("White Balls: "+football)).append(cEl("div").attr("class", "profile-form").tEl("Form: ").append(form));


            favRow = cEl("tr").attr("class", rowClass).listener("click", showFavoritesProfile);
            favRow.append(cEl("td").append(cEl("i").attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
              .append(cEl("td").tEl(cuser.Rank)) //Rank
              .append(cEl("td").tEl(cusername)) //Username
              .append(cEl("td").tEl(cuser.Points)); //Points
              //.append(cEl("td").tEl(getOverAllForm(cuser))) //Level
            //.append(cEl("td").tEl(getUserForm(cuser))); //Form
            rowtd.append(row3);
            row1.append(rowtd);
            favRow.append(row1);
        }
        else if (id === "uTbl" && i === -1) {
            continue;
        }
        else if (id === "uTbl" && i !=-1) {
            var objusername = objs[i].Username;
            if (objusername.length > 10) {
                objusername = objusername.substr(0, 8) + "...";
            }
        football = objs[i].Credit2;
        favClass = favIds.indexOf(objs[i].Username) > -1 ? "icon-star-1" : "icon-star-empty-1";
        rowClass = objs[i].Username === cuser.Username ? "self" : "regular";

        form = genProgressBar(getUserForm(objs[i])).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");
        
        row1 = cEl("tr").attr("class", "profile-hidden");
        rowtd = cEl("td").attr("colspan", "4");
        row3 = cEl("div").attr("class", "row-fluid")
            .append(cEl("div").attr("class", "profile-el").tEl("Level: ").append(cEl("span").attr("class", "total-points label-warning").tEl(getOverAllForm(objs[i]))))
                   .append(cEl("div").attr("class", "profile-el").tEl("White Balls: "+football)).append(cEl("div").attr("class", "profile-form").tEl("Form: ").append(form));

        favRow = cEl("tr").attr("class", rowClass).listener("click", showGlobalProfile);
        favRow.append(cEl("td").append(cEl("i").wr({ uname: objs[i].Username }).attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
              .append(cEl("td").tEl(objs[i].Rank)) //Rank
              .append(cEl("td").tEl(objusername)) //Username
              .append(cEl("td").tEl(objs[i].Points)); //Points
              //.append(cEl("td").tEl(getOverAllForm(objs[i]))) //Level
            //.append(cEl("td").tEl(getUserForm(objs[i]))); //Form

            rowtd.append(row3);
            row1.append(rowtd);
        }
        else if (id === "fTbl" && i != -1) {
            var objusername = objs[i].Username;
            if (objusername.length > 10) {
                objusername = objusername.substr(0, 8)+"...";
            }
            football = objs[i].Credit2;
            favClass = favIds.indexOf(objs[i].Username) > -1 ? "icon-star-1" : "icon-star-empty-1";
            rowClass = objs[i].Username === cuser.Username ? "self" : "regular";

            form = genProgressBar(getUserForm(objs[i])).attr("style", "display: inline-block;width: 80%;margin-bottom:0px;");

            row1 = cEl("tr").attr("class", "profile-hidden");
            rowtd = cEl("td").attr("colspan", "4");
            row3 = cEl("div").attr("class", "row-fluid")
                .append(cEl("div").attr("class", "profile-el").tEl("Level: ").append(cEl("span").attr("class", "total-points label-warning").tEl(getOverAllForm(objs[i]))))
                       .append(cEl("div").attr("class", "profile-el").tEl("White Balls: " + football)).append(cEl("div").attr("class", "profile-form").tEl("Form: ").append(form));

            favRow = cEl("tr").attr("class", rowClass).listener("click", showFavoritesProfile);
            favRow.append(cEl("td").append(cEl("i").wr({ uname: objs[i].Username }).attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
                  .append(cEl("td").tEl(objs[i].Rank)) //Rank
                  .append(cEl("td").tEl(objusername)) //Username
                  .append(cEl("td").tEl(objs[i].Points)); //Points
            //.append(cEl("td").tEl(getOverAllForm(objs[i]))) //Level
            //.append(cEl("td").tEl(getUserForm(objs[i]))); //Form

            rowtd.append(row3);
            row1.append(rowtd);
        }

        //tBody.append(genSingleMatchRow(matches[j]));
        tBody.append(favRow).append(row1);
        
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


    for (i = 0; i < objs.length; i++) {
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
        var row3 = cEl("div").attr("class","row-fluid")
                    .append(cEl("div").attr("class", "profile-el").append(leader).append(leaderName))
                    .append(cEl("div").attr("class", "profile-el").append(clan).append(clanavg))
                    .append(cEl("div").attr("class", "profile-el").append(users).append(userCnt))
                    .append(cEl("div").attr("class", "profile-el").append(trophies).append(trophiesNr))
                    ;
        var td = cEl("td").attr("colspan", "3").append(row3);
        row2.append(td);
        var favRow = cEl("tr").attr("class", rowClass).listener("click",showClanProfile);
        favRow.append(cEl("td").tEl(objs[i].Rank)) //Rank
            .append(cEl("td").tEl(objs[i].Name)) //Clan Name
            .append(cEl("td").tEl(objs[i].Points)); //Points
        




        tBody.append(favRow).append(row2);
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

function genGlobal() {
    var uObj;
    $.post("Actions/User.aspx", { type: "GAU" },
   function (e) {
       uObj = JSON.parse(e);
       appendToItem("tbMain", genLbUserTable(uObj, "uTbl"), "-");
       pageToSelf("u");
   });
}
function genGlobals() {
    var uObj;
    $.post("Actions/User.aspx", { type: "GAU",PageNumber:pageNumber },
   function (e) {
       uObj = JSON.parse(e);
       console.log(uObj);
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
            break;
        case "users":
            genGlobals();
            break;
        case "clans":
            genLbClans();
            break;
        case "trophies":
            appendToItem("tbMain", genTrophyTable());
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

function showFavoritesProfile(){
    var index = this.rowIndex + 1;
    var tabela = document.getElementById("fTbl");
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
function showClanProfile() {

    var index = this.rowIndex + 1;
    var tabela = document.getElementById("cTbl");
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