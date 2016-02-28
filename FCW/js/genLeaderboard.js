var favIds = new Array();

function genLeaderboardTabs(favs) {
    var mainTabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                            .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                            .append(
                                cEl("li").attr("class","tab active").append(cEl("a").attr("id","lbFavorites").attr("href","#").tEl("Favorites"))
                            ).append(
                                cEl("li").attr("class","tab").append(cEl("a").attr("id","lbGlobal").attr("href","#").tEl("Global"))
                            ).append(
                                cEl("li").attr("class","tab").append(cEl("a").attr("id","lbClans").attr("href","#").tEl("Clans"))
                            ).append(
                                cEl("li").attr("class","tab").append(cEl("a").attr("id","lbTrophies").attr("href","#").tEl("Trophies"))
                            ));

    var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

    var tbFavorites = cEl("div").attr("class", "tab-block active").attr("id", "tbFavorites").attr("style", "display: block; position: static; visibility: visible;");
    var lbGlobal = cEl("div").attr("class", "tab-block").attr("id", "lbGlobal").attr("style", "display: none;");
    var lbClans = cEl("div").attr("class", "tab-block").attr("id", "lbClans").attr("style", "display: none;");
    var lbTrophies = cEl("div").attr("class", "tab-block").attr("id", "lbTrophies").attr("style", "display: none;");

    tbFavorites.append(genFavorites(favs));

    tabContainer.append(tbFavorites).append(lbGlobal).append(lbClans).append(lbTrophies);

    mainTabs.append(tabContainer);
    return mainTabs;
}

function genFavorites(favs) {
    var i = 0;
    //Table Tag
    var mainTag = document.createElement("table");
    mainTag.id = "favTbl";
    mainTag.className = "table table-hover";

    //Header
    var head = [{ Title: "Fav", Text: "Fav" }, { Title: "Username", Text: "User" }, { Title: "Points", Text: "Points" },{ Title: "Level", Text: "Level" }];
    var tHead = document.createElement("thead");
    var hRow = document.createElement("tr");
    for (i = 0; i < head.length; i++) {
        var hElement = document.createElement("th");
        var hSpan = document.createElement("span");
        hSpan.setAttribute("data-toggle", "tooltip");
        hSpan.setAttribute("data-placement", "top");
        hSpan.title = head[i].Title;
        hSpan.innerText = head[i].Text;
        hElement.append(hSpan);
        hRow.append(hElement);
    }
    tHead.append(hRow);

    var tBody = document.createElement("tbody");

    console.log(favs);

    for (i = 0; i < favs.length; i++) {
        favIds.push(favs[i].Username);
        var favRow = cEl("tr");
        //<i class="icon-star-1"></i>
        favRow.append(cEl("td").append(cEl("i").attr("class", "icon-star-1 lbFav").listener("click", toggleFavorite))) //star
              .append(cEl("td").tEl(favs[i].Username))
              .append(cEl("td").tEl(favs[i].Points))
              .append(cEl("td").tEl(Math.floor(favs[i].TotalPredictions / 1000) + 1));

        //tBody.append(genSingleMatchRow(matches[j]));
        tBody.append(favRow);

    }

    mainTag.append(tHead);
    mainTag.append(tBody);
    console.log(mainTag);
    return mainTag;
}

function genFavoritesObjs() {
    var favs;
    $.post("Actions/User.aspx", { type: "GFA" },
   function (e) {
       favs = JSON.parse(e);

       var mainC = document.getElementById("mainContainer");
       mainC.append(genLeaderboardTabs(favs));
   });
}

function genGlobal() {
    
}

function genLbClans() {
    
}

function genTrophies() {
    
}

function getFavorites() {
    
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
            break;
        
    default:
    }
}