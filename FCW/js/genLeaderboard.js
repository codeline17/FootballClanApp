﻿var favIds = new Array();
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
    var head = [{ Title: "Fav", Text: "Fav" }, { Title: "Rank", Text: "#" }, { Title: "Username", Text: "User" },
                { Title: "Points", Text: "Pts" }, { Title: "Level", Text: "Lvl" }, { Title: "Form", Text: "Form" }];
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
        if (id === "fTbl" && i === -1) {
            rowClass = "self";
            favRow = cEl("tr").attr("class", rowClass);
            favRow.append(cEl("td").append(cEl("i").attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
              .append(cEl("td").tEl(cuser.Rank)) //Rank
              .append(cEl("td").tEl(cuser.Username)) //Username
              .append(cEl("td").tEl(cuser.Points)) //Points
              .append(cEl("td").tEl(getOverAllForm(cuser))) //Level
              .append(cEl("td").tEl(getUserForm(cuser))); //Form
            console.log(cuser);
        }
        else if (id === "uTbl" && i === -1) {
            continue;
        }
        else{
        

        favClass = favIds.indexOf(objs[i].Username) > -1 ? "icon-star-1" : "icon-star-empty-1";
        rowClass = objs[i].Username === cuser.Username ? "self" : "regular";
        favRow = cEl("tr").attr("class", rowClass).listener("click", expandMyDetails);
        favRow.append(cEl("td").append(cEl("i").wr({ uname: objs[i].Username }).attr("class", favClass + " lbFav").listener("click", toggleFavorite))) //Favorite Star
              .append(cEl("td").tEl(objs[i].Rank)) //Rank
              .append(cEl("td").tEl(objs[i].Username)) //Username
              .append(cEl("td").tEl(objs[i].Points)) //Points
              .append(cEl("td").tEl(getOverAllForm(objs[i]))) //Level
              .append(cEl("td").tEl(getUserForm(objs[i]))); //Form
        }     

        //tBody.append(genSingleMatchRow(matches[j]));
        tBody.append(favRow);
        
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
        var rowClass = objs[i].Name === cuser.NameOfClan ? "self" : "regular";

        var favRow = cEl("tr").attr("class", rowClass);
        favRow.append(cEl("td").tEl(objs[i].Rank)) //Rank
            .append(cEl("td").tEl(objs[i].Name)) //Clan Name
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

function genGlobal() {
    var uObj;
    $.post("Actions/User.aspx", { type: "GAU" },
   function (e) {
       uObj = JSON.parse(e);
       appendToItem("tbMain", genLbUserTable(uObj, "uTbl"), "-");
       pageToSelf("u");
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
            genGlobal();
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
            case "l": var own = document.getElementsByClassName("leader")[0];
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