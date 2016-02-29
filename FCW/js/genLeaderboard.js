var favIds = new Array();
var lbFavs;
var lbUsers;
var lbClans;
var lbTrophies;

function genLeaderboardTabs() {
    var mainTabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                            .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                            .append(
                                cEl("li").listener("click", switchTabs, false).attr("class", "tab active").append(cEl("a").attr("id", "lbFavorites").attr("href", "#tbFavorites").tEl("Favorites"))
                            ).append(
                                cEl("li").listener("click", switchTabs, false).attr("class", "tab").append(cEl("a").attr("id", "lbGlobal").attr("href", "#lbGlobal").tEl("Global"))
                            ).append(
                                cEl("li").listener("click", switchTabs, false).attr("class", "tab").append(cEl("a").attr("id", "lbClans").attr("href", "#lbClans").tEl("Clans"))
                            ).append(
                                cEl("li").listener("click", switchTabs, false).attr("class", "tab").append(cEl("a").attr("id", "lbTrophies").attr("href", "#lbTrophies").tEl("Trophies"))
                            ));

    var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

    var tbFavorites = cEl("div").attr("class", "tab-block active").attr("id", "tbFavorites").attr("style", "display: block; position: static; visibility: visible;")
                        .append(genFavorites(lbFavs, "tblFavs"));
    var lbGlobal = cEl("div").attr("class", "tab-block").attr("id", "lbGlobal").attr("style", "display: none;")
                        .append(genFavorites(lbUsers, "tblUsrs"));
    var lbClans = cEl("div").attr("class", "tab-block").attr("id", "lbClans").attr("style", "display: none;");
    var lbTrophies = cEl("div").attr("class", "tab-block").attr("id", "lbTrophies").attr("style", "display: none;");


    tabContainer.append(tbFavorites).append(lbGlobal).append(lbClans).append(lbTrophies);

    mainTabs.append(tabContainer);
    return mainTabs;
}

function genFavorites(favs, id) {
    var i = 0;
    //Table Tag
    var mainTag = document.createElement("table");
    mainTag.id = id;
    mainTag.className = "table table-hover";

    //Header
    var head = [{ Title: "Fav", Text: "Fav" }, { Title: "Rank", Text: "#" },  { Title: "Username", Text: "User" }, { Title: "Points", Text: "Points" }, { Title: "Level", Text: "Level" }];
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
    
    
    for (i = 0; i < favs.length; i++) {
        favIds.push(favs[i].Username);
        var favRow = cEl("tr");
        //<i class="icon-star-1"></i>
        favRow.append(cEl("td").append(cEl("i").wr({ uname: favs[i].Username }).attr("class", "icon-star-1 lbFav").listener("click", toggleFavorite))) //Favorite Star
              .append(cEl("td").tEl(favs[i].Rank)) //Rank
              .append(cEl("td").tEl(favs[i].Username)) //Username
              .append(cEl("td").tEl(favs[i].Points)) //Points
              .append(cEl("td").tEl(Math.floor(favs[i].TotalPredictions / 1000) + 1)); //Level

        //tBody.append(genSingleMatchRow(matches[j]));
        tBody.append(favRow);

    }

    mainTag.append(tHead);
    mainTag.append(tBody);
    return mainTag;
}

function genFavoritesObjs(rfr) {
    var lb;
    favIds = new Array();
    $.post("Actions/User.aspx", { type: "GLB" },
   function (e) {
       lb = JSON.parse(e);
       for (var i = 0; i < lb.Favorites.length; i++) {
           favIds.push(lb.Favorites[i].Username);
       }
       lbFavs = lb.Favorites;
       lbUsers = lb.Users;
       lbClans = lb.Clans;
       lbTrophies = lb.Trophies;
       if (rfr === 1) {
           var mainC = document.getElementById("mainContainer");
           mainC.append(genLeaderboardTabs());
       }
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
    }

    $.post("Actions/User.aspx", { type: "TGF", FavUname : cc.wrapper.uname },
    function (resp) {
        if (resp === "1") {
            switch (cc.className) {
            case "icon-star-1 lbFav":
                cc.className = "icon-star-empty-1 lbFav";
                break;
            case "icon-star-empty-1 lbFav":
                cc.className = "icon-star-1 lbFav";
                break;
            }
            e.target.parentNode.parentNode.parentNode.removeChild(e.target.parentNode.parentNode);
        }
    });
}