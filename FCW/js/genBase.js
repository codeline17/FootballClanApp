window.onload = function (e) {
    var tomorrowMatches;
    mode = 'matches';
    var menus = $("li[content-type]");
    for (var i = 0; i < menus.length; i++) {
        menus[i].addEventListener("click", getContent);
    }

    $.getScript("style/js/DateFormat.js", function () {
    });

    $.getScript("js/genUnlock.js", function () {
    });


    genHeader();
    getMatches("w");
    getUnlocks();
    
    //genMatches();

    if (site == "play") {
        $("li[content-type]").each(function () {
            if (this.getAttribute("content-type") === "store") {
                this.parentElement.removeChild(this);
            }
        });
    }
    else {
        $("li[content-type]").each(function () {
            if (this.getAttribute("content-type") === "unlock") {
                this.parentElement.removeChild(this);
            }
        });
    }
    
    
}

function getUnlocks() {
    $.post("Actions/User.aspx", { type: "UNL" },
        function (e) {
            unlocks = JSON.parse(e);
        });
}

function getContent(e) {
     var type = this.getAttribute("content-type");
     $("li[content-type]").each(function() {
         this.className = "";
     });

     this.className = "active";

     var mainC = document.getElementById("mainContainer");
     mainC.innerHTML = "";

     mode = type;
     switch (type) 
     {
         case "matches":
             state = true;
             getMatches("w");
             
             //genMatches();
             break;
         case "predictions":
             state = false;
             addFilterHead();
             genPredictions(getFullDate(new Date(), -1));
             break;
         case "clans":
            genClans();
             break;
         case "leagues":
            genLeagues();
             break;
         case "leaderboard":
            genLeadBoard();
             break;
         case "livescore":
             addFilterHead();
             genLiveScore(getFullDate(new Date()));
             break;
         case "store":
            genStoreUnlocks();
             break;
         case "unlock":
             genUnlocksMenu();
             break;
         case "chat":
             getChat("parse");
             break;
         case "prizes":
             getPrizes();
             break;
         case "tutorial":
             tutorial();
             break;
         default:
             break;

     }

     if (document.getElementsByClassName("icon-cancel-1").length === 1) {
     document.getElementsByClassName("icon-cancel-1")[0].click();
     }

 }
 function getMatches(opt) {
     var date = getFullDate(new Date(), 0);
    $.post("Actions/Fixture.aspx", { type: "PREDS", date: date },
        function (e) {
            matches = JSON.parse(e);
            if (opt === "w") {
                genMatches();
            } else {
                var trs = document.getElementsByTagName("tr");
                for (var j = 0; j < matches.length; j++) {
                    for (var i = 0; i < trs.length; i++) {
                        if (trs[i].wrapper) {
                            if (trs[i].wrapper.ID === matches[j].ID) {
                                trs[i].wrapper = matches[j];
                                trs[i].innerHTML = genSingleMatchRow(matches[j]).innerHTML;
                            }
                           
                        }
                    }
                }
            }
        });
 }
 function getTomorrowMatches(opt){
     var date = getFullDate(new Date(), 1);
     $.post("Actions/Fixture.aspx", { type: "PREDS", date: date },
         function (e) {
             tomorrowMatches = JSON.parse(e);
             if (opt === "w") {
                 genTomorrowMatches();
             } else {
                 var trs = document.getElementsByTagName("tr");
                 for (var j = 0; j < matches.length; j++) {
                     for (var i = 0; i < trs.length; i++) {
                         if (trs[i].wrapper) {
                             if (trs[i].wrapper.ID === matches[j].ID) {
                                 trs[i].wrapper = matches[j];
                                 trs[i].innerHTML = genSingleMatchRow(matches[j]).innerHTML;
                             }
                           
                         }
                     }
                 }
             }
         });
 }

function genMatches() {
    genGrid(matches, "nope");
    
}

function genTomorrowMatches(){
    genGrid(tomorrowMatches, "nope");
    var text = document.getElementById("headerText");
    text.innerHTML = "Tomorrow Matches";
    text.append(cEl("div").attr("id", "prevDay").attr("width", "40px").attr("style", "float:left;font-style:normal;transform: rotate(180deg);").listener("click", genMatches).tEl("➜"));
}

 function genPredictions(date) {
     $.post("Actions/Fixture.aspx", { type: "PREDS", date : date },
   function (e) {
       var matches = JSON.parse(e);
       genGrid(matches, date);
   });
 }
 
 function genLeagues() {
     tabIdPagination = 0;
     pageNumber = 0;
     getLeagueData(pageNumber,100);
     //isInLeague();
     

 }

 function genLeadBoard() {
     genLeaderboardTabs();
     //genGlobals();
 }
 function genStoreUnlocks(){
     var mainC = document.getElementById("mainContainer");
     var tabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                            .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                            .append(
                                cEl("li").listener("click", switchStoreTabs, false).attr("class", "tab active").append(cEl("a").wr({ el: "store" }).tEl("Store"))
                            ).append(
                                cEl("li").listener("click", switchStoreTabs, false).attr("class", "tab").append(cEl("a").wr({ el: "unlocks" }).tEl("Unlocks"))
                            ));
     var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

     var tbMain = cEl("div").attr("class", "tab-block active").attr("id", "tbMain").attr("style", "display: block; position: static; visibility: visible;");

     tabContainer.append(tbMain);

     tabs.append(tabContainer);

     var mainC = document.getElementById("mainContainer");
     mainC.append(tabs);

     genStore();
 }
 function switchStoreTabs(e) {
     var tbs = e.target.parentNode.parentNode.childNodes;

     var clicked = e.target.wrapper.el;
     for (var j = 0; j < tbs.length; j++) {
         tbs[j].className = tbs[j].className.replace("active", "").replace(" ", "");
         
     }

     this.className = "tab active";

     switch (clicked) {
         case "store":
             genStore();
             break;
         case "unlocks":
             genUnlocks();
             break;
     }
 }
 function genStore() {

     var mainC = document.getElementById("mainContainer");
     mainC.innerHTML = "";
     var mainC = document.getElementById("mainContainer");
     var tabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                            .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                            .append(
                                cEl("li").listener("click", switchStoreTabs, false).attr("class", "tab active").append(cEl("a").wr({ el: "store" }).tEl("Store"))
                            ).append(
                                cEl("li").listener("click", switchStoreTabs, false).attr("class", "tab").append(cEl("a").wr({ el: "unlocks" }).tEl("Unlocks"))
                            ));
     var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

     var tbMain = cEl("div").attr("class", "tab-block active").attr("id", "tbMain").attr("style", "display: block; position: static; visibility: visible;");

     tabContainer.append(tbMain);

     tabs.append(tabContainer);
     mainC.append(tabs);
     var els1 = cEl("div").attr("class", "row-fluid")
         .append(cEl("div").attr("class", "span4").append(cEl("img").attr("width", "100%").attr("src", "style/images/shop_0.jpg"))
         )
         .append(cEl("a").attr("href", "#").listener("click", buyActions).append(cEl("div").attr("class", "span4").append(cEl("img").wr({ itemName: "5balls", btnId: "E9PAYL8FLDA4Y" }).attr("width", "100%").attr("src", "style/images/shop_1.jpg")))
         )
         .append(cEl("a").attr("href", "#").listener("click", buyActions).append(cEl("div").attr("class", "span4").append(cEl("img").wr({ itemName: "10balls", btnId: "9G7KFDM3LLKR8" }).attr("width", "100%").attr("src", "style/images/shop_2.jpg")))
         );
     var els2 = cEl("div").attr("class", "row-fluid")
         .append(cEl("a").attr("href", "#").listener("click", buyActions).append(cEl("div").attr("class", "span4").append(cEl("img").wr({ itemName: "20balls", btnId: "ARXPC9JXWC7QW" }).attr("width", "100%").attr("src", "style/images/shop_3.jpg")))
         )
         .append(cEl("a").attr("href", "#").listener("click", buyActions).append(cEl("div").attr("class", "span4").append(cEl("img").wr({ itemName: "50balls", btnId: "BF6UAY773LD9E" }).attr("width", "100%").attr("src", "style/images/shop_4.jpg")))
         )
         .append(cEl("a").attr("href", "#").listener("click", buyActions).append(cEl("div").attr("class", "span4").append(cEl("img").wr({ itemName: "100balls", btnId: "4TZ2JBBLBCF8S" }).attr("width", "100%").attr("src", "style/images/shop_5.jpg")))
         );
     mainC.append(els1).append(els2);
 }
 function genUnlocks() {
     var mainC = document.getElementById("mainContainer");
     mainC.innerHTML = "";
     var tabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                            .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                            .append(
                                cEl("li").listener("click", switchStoreTabs, false).attr("class", "tab").append(cEl("a").wr({ el: "store" }).tEl("Store"))
                            ).append(
                                cEl("li").listener("click", switchStoreTabs, false).attr("class", "tab active").append(cEl("a").wr({ el: "unlocks" }).tEl("Unlocks"))
                            ));
     var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

     var tbMain = cEl("div").attr("class", "tab-block active").attr("id", "tbMain").attr("style", "display: block; position: static; visibility: visible;");

     tabContainer.append(tbMain);

     tabs.append(tabContainer);
     mainC.append(tabs);

     var rootElement = cEl("div").attr("class", "pricing row-fluid");

     for (var i = 0; i < unlocks.length; i++) {

         rootElement.append(genSingleUnlockElement(unlocks[i].Name, unlocks[i].ExpiresOn));
     }

     mainC.append(rootElement);
 }
 function genUnlocksMenu() {
     var mainC = document.getElementById("mainContainer");
     mainC.innerHTML = "";
     var mainC = document.getElementById("mainContainer");
     var rootElement = cEl("div").attr("class", "pricing row-fluid");

     for (var i = 0; i < unlocks.length; i++) {

         rootElement.append(genSingleUnlockElement(unlocks[i].Name, unlocks[i].ExpiresOn));
     }

     mainC.append(rootElement);
 }

function buyActions(e) {
    var itemName = e.target.wrapper.itemName;
    var buttonId = e.target.wrapper.btnId;
    if (!itemName || !buttonId)
        return;

    //Ajax Create
    $.post("Actions/Paypal.aspx", { type: "PUI", ItemName: itemName },
        function (r) {
            cuser.Username
            if (r.length > 5) {
                window.location.href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=" + buttonId + "&custom=" + r;
            }
        });
}

function paymentChecker() {
    
}

function genHeader1() {
     $.post("Actions/Fixture.aspx", { type: "GUN" },
  function (e) {
      username = e.split("|")[0];
      var h = document.getElementById("mainHeader");
      var sub = document.createElement("li");

      var iSub = document.createElement("i");
      iSub.className = "icon-user";
      sub.appendChild(iSub);

      var nameSpan = document.createElement("span");
      nameSpan.innerText = e.split("|")[0];
      nameSpan.style = "margin-right : 15px;";

      var crediti = document.createElement("i");
      crediti.className = "icon-dribbble-circled icn";

      var creditspan = document.createElement("span");
      creditspan.innerText = e.split("|")[1];

      sub.appendChild(iSub);
      sub.appendChild(nameSpan);
      sub.appendChild(crediti);
      sub.appendChild(creditspan);

      h.innerHTML = "";
      h.appendChild(sub);
  });
     
 }

function setPrediction(e) {
    //remove all other selected
    var el = "";
    if (e.type === "click") {
        el = document.getElementById(e.target.id);

    }
    else if (e.type === "change") {
        el =  e.target.options[e.target.selectedIndex];
    }
    var matchId = el.getAttribute("data-odd").split("|")[0];
    var row = document.getElementById("rid" + matchId);
    var allAs = row.querySelectorAll("[data-odd]");
    var prevClass = el.className;
    
    for (var i = 0; i < allAs.length; i++) {
        if (allAs[i].getAttribute("data-group") === el.getAttribute("data-group")) {
            allAs[i].className = "odd";
        }
    }

    if (prevClass === "odd bet")
        return;

    el.className = "odd bet";
    sendPredictions();
}

function getShortTeamName(name, match, length) {
    if (length === 100) {
        return name.replace("[Home]", match.HomeTeam.Name).replace("[Away]", match.AwayTeam.Name).replace("[Draw]", "Draw").replace(" ", "");
    } else {
        return name.replace("[Home]", match.HomeTeam.Name).replace("[Away]", match.AwayTeam.Name).replace("[Draw]", "Draw").replace(" ", "").substring(0, 10);
    }
}

function getFixtureName(match) {
    return match.HomeTeam.Name.substring(0, 10) + "-" + match.AwayTeam.Name.substring(0, 80);
}

function genGrid(matches, date) {
    var mainC = document.getElementById("mainContainer");
    if (document.getElementById("tblContainer")) {
        document.getElementById("tblContainer").parentNode.removeChild(document.getElementById("tblContainer"));
    }

    var rFluid = cEl("div").attr("id", "tblContainer").attr("class", "row");

    var exGrid = document.getElementById("match-table");
    if (exGrid) {
        exGrid.parentNode.removeChild(exGrid);
    }

    var totPoints = 0;
    var pEl;

    for (var i = 0; i < matches.length; i++) {
        totPoints += matches[i].PointsWon;
    }

    if (date !== "nope") {
        pEl = cEl("h3").tEl(date + " - " + totPoints + " pts").attr("style", "text-align:center;").append(cEl("div").attr("id", "prevDay").attr("width", "40px").attr("style", "float:right;font-style:normal;").listener("click", function () {
            genMatches();
            var mainContainer = document.getElementById('pastDate');
            mainContainer.remove();
        }).tEl("➜"));
    } else {
        pEl = cEl("h3").attr("class", "todays").attr("id","headerText").tEl("Today - " + totPoints + " points").attr("style", "text-align:center;")
            .append(cEl("div").attr("id", "prevDay").attr("width", "40px").attr("style", "float:left;font-style:normal;transform: rotate(180deg);").listener("click", function () { addFilterHead(); genPredictions(getFullDate(new Date(), -1)); }).tEl("➜"))
                .append(cEl("img").attr("src", "style/images/reload.png").attr("width", "35px").attr("style", "margin-left: 10px;").listener("click", refreshFunction))
                    .append(cEl("div").attr("id", "nextDay").attr("width", "40px").attr("style", "float:right;font-style:normal;").listener("click", function () { getTomorrowMatches("w") }).tEl("➜"));
    }

    rFluid.append(pEl);
    
    //rFluid.appendChild(genTable("match-table", matches, state));
    rFluid.append(genMatchRows(matches, "match-table"));
    mainC.appendChild(rFluid);

    /***After Event Assignments***/
    $('[data-toggle="tooltip"]').tooltip();
    /****************************/
}

function addFilterHead() {
    var mainC = document.getElementById("mainContainer");
    var filterHead = document.createElement("div");
    filterHead.className = "row";
    filterHead.id = 'pastDate';
    var htmlTxt = "<div class=\"panel panel-default\">\
                            <div class=\"panel-body\">\
                                <form class=\"form-inline\" role=\"form\">\
                                    <div class=\"form-group\">\
                                        <input type=\"datetime\" placeholder=\"Pick a date\" class=\"form-control input-sm\" id=\"pref-search\" >\
                                    </div><!-- form group [search] -->\
                                    <div class=\"form-group\">\
                                        <!--button id=\"predSBtn\" value=\"\" type=\"submit\" class=\"btn btn-default filter-col\">\
                                            <span class=\"glyphicon glyphicon-record\"></span> Search\
                                        </button -->\
                                    </div>\
                                </form>\
                            </div>";

    filterHead.innerHTML = htmlTxt;
    mainC.appendChild(filterHead);
    $("#pref-search").datepicker({
        format: "dd/mm/yyyy"
    }).on("changeDate", function (e) {
        var dt = e.date;
        $('.datepicker.dropdown-menu').hide();
        if (mode==="matches") {
            genPredictions(getFullDate(dt,0));
        }
        else if (mode ==="livescore") {
            genLiveScore(getFullDate(dt,0));
        }
    });
}

function getFullDate(date, days) {
    date.setDate(date.getDate() + days);

    var dd = date.getDate();
    var mm = date.getMonth() + 1; //January is 0!

    var yyyy = date.getFullYear();
    if (dd < 10) {
        dd = "0" + dd;
    }
    if (mm < 10) {
        mm = "0" + mm;
    }
    return dd + "/" + mm + "/" + yyyy;
}

function makeid() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 5; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}

function createPanel(title) {
    var panel = document.createElement("div");

    var panelHeading = document.createElement("h3");
    panelHeading.className = "section-title";
    panelHeading.innerText = title;

    var panelBody = document.createElement("p");
    panelBody.className = "panel-body";

    panel.appendChild(panelHeading);
    panel.appendChild(panelBody);

    return panel;
}
function refreshFunction() {
    window.location.reload();
}


function getPrizes() {
    var mainC = document.getElementById("mainContainer");
    mainC.innerHTML = "";
    
    var tabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                           .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                           .append(
                               cEl("li").listener("click", switchPrizesTabs, false).attr("class", "tab active").append(cEl("a").wr({ el: "playerCompetitions" }).tEl("Player Competitions"))
                           ).append(
                               cEl("li").listener("click", switchPrizesTabs, false).attr("class", "tab").append(cEl("a").wr({ el: "clanCompetitons" }).tEl("Clan Competitions"))
                           ));
    var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

    var tbMain = cEl("div").attr("class", "tab-block active").attr("id", "tbMain").attr("style", "display: block; position: static; visibility: visible;");

    tabContainer.append(tbMain);

    tabs.append(tabContainer);
    mainC.append(tabs);
    genPlayerPrizes();

}

function genPlayerPrizes() {
    var mainC = document.getElementById("mainContainer");
    mainC.innerHTML = "";
    var tabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                           .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                           .append(
                               cEl("li").listener("click", switchPrizesTabs, false).attr("class", "tab active").append(cEl("a").wr({ el: "playerCompetitions" }).tEl("Player Competitions"))
                           ).append(
                               cEl("li").listener("click", switchPrizesTabs, false).attr("class", "tab").append(cEl("a").wr({ el: "clanCompetitions" }).tEl("Clan Competitions"))
                           ));
    var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

    var tbMain = cEl("div").attr("class", "tab-block active").attr("id", "tbMain").attr("style", "display: block; position: static; visibility: visible;");

    tabContainer.append(tbMain);

    tabs.append(tabContainer);
    mainC.append(tabs);

    
    var eliteCompetion = cEl("div").append(cEl("p").tEl("Usually during Champions League period we will launch intense weekly competitions ..."))
        .append(cEl("p").tEl(" These Competitions will last for 7 days up to 20 days and they will dispose prizes as below:"))
        .append(cEl("ol").attr("style", "list-style-type:none;")
        .append(cEl("li").tEl("Position 1 -> PS4 + 30 golden balls"))
        .append(cEl("li").tEl("Position 2 -> Smartphone + 30 golden balls"))
        .append(cEl("li").tEl("Position 3 -> Nike football shoes + 30 golden balls"))
        .append(cEl("li").tEl("Position 7 - 4 -> Barca football jesy + 25 golden balls"))
        .append(cEl("li").tEl("Position 10 - 8 -> Smartphone cases + 25 golden balls"))
        .append(cEl("li").tEl("Position 15 - 11 -> Footballclans T-Shirt + 25 golden balls"))
        .append(cEl("li").tEl("Position 50 - 16 -> 20 golden balls"))
        );

    var euroCompetition = cEl("div")
        .append(cEl("p").tEl(" During EURO 2016 there will be a special competition and it will dispose prizes as below:"))
        .append(cEl("ol").attr("style", "list-style-type:none;")
        .append(cEl("li").tEl("Position 1 -> PS4 + 30 golden balls"))
        .append(cEl("li").tEl("Position 2 -> Smartphone + 30 golden balls"))
        .append(cEl("li").tEl("Position 3 -> Nike football shoes + 30 golden balls"))
        .append(cEl("li").tEl("Position 7 - 4 -> Barca football jesy + 25 golden balls"))
        .append(cEl("li").tEl("Position 10 - 8 -> Smartphone cases + 25 golden balls"))
        .append(cEl("li").tEl("Position 15 - 11 -> Footballclans T-Shirt + 25 golden balls"))
        .append(cEl("li").tEl("Position 50 - 16 -> 20 golden balls"))
        );

    var monthlyCompetition = cEl("div").append(cEl("p").tEl("Every month From August to June there will be a monthly competitions starting on the 1st of the month and ending on the last day of the month."))
        .append(cEl("p").tEl(" People who accumulate most points during this period will win prizes as below:"))
        .append(cEl("ol").attr("style", "list-style-type:none;").append(cEl("li").tEl("Position 50 - 16 -> 20 golden balls"))
        .append(cEl("li").tEl("Position 15 - 11 -> Footballclans T-Shirt + 25 golden balls"))
        .append(cEl("li").tEl("Position 10 - 8 -> Smartphone cases + 25 golden balls"))
        .append(cEl("li").tEl("Position 7 - 4 -> Barca football jesy + 25 golden balls"))
        .append(cEl("li").tEl("Position 3 -> Nike football shoes + 30 golden balls"))
        .append(cEl("li").tEl("Position 2 -> Smartphone + 30 golden balls"))
        .append(cEl("li").tEl("Position 1 -> PS4 + 30 golden balls")));
        

    var seasonCompetition = cEl("div").append(cEl("p").tEl("Every season starting from 1st of August until 31st of June there will be a season Competition which every user will be automatically registered."))
        .append(cEl("p").tEl(" Whoever accumulates the most points during this period will be winner of the SEASON. The Season winner will receive high publicity and will receive a REAL GOLDEN BALL: All other players will get prizes as below:"))
        .append(cEl("ol").attr("style", "list-style-type:none;").append(cEl("li").tEl("Position 200-101 -> 50 golden balls"))
        .append(cEl("li").tEl("Position 1 -> a REAL GOLDEN BALL, more than 1.5 KG in Pure Gold + 200 golden balls"))
        .append(cEl("li").tEl("Position 2 -> 2 Champions League Final Tickets + 175 golden balls"))
        .append(cEl("li").tEl("Position 3 -> 2 European Super Cup Final + 150 golden balls"))
        .append(cEl("li").tEl("Position 5 - 4 -> Footballclans Golden Bracelet + 150 golden balls"))
        .append(cEl("li").tEl("Position 10 - 6 -> Smartphone + 100 golden balls"))
        .append(cEl("li").tEl("Position 15 - 11 -> Football Shoes + 100 golden balls"))
        .append(cEl("li").tEl("Position 20 - 16 -> Original Champions League Football + 100 golden balls"))
        .append(cEl("li").tEl("Position 25 - 21 -> Football Jearsey + 90 golden balls"))
        .append(cEl("li").tEl("Position 40 - 26 -> Bracelets + 80 golden balls"))
        .append(cEl("li").tEl("Position 50 - 41 -> HATS + 70 golden balls"))
        .append(cEl("li").tEl("Position 100 - 51 -> Smartphone Cases + 60 golden balls"))
        );

    var rootElement = cEl("div").attr("class", "row-fluid");
    var prizes = cEl("div").attr("class", "row-fluid prizes");
    prizes.append(
            genAccordionElementa("elitetab", "Elite Player Competition", null, eliteCompetion)
            )
        .append(
            genAccordionElement("eurotab", "Euro 2016 individual", null, euroCompetition)
            );
       /* .append(
            genAccordionElement("monthlytab", "Monthly single competitions MSC", null, monthlyCompetition)
            ) 
        .append(
            genAccordionElement("seasontab", "Season single competition SSC", null, seasonCompetition)
            );*/
    rootElement.append(prizes);
    mainC.append(rootElement);

}
function genClanPrizes() {
    var mainC = document.getElementById("mainContainer");
    mainC.innerHTML = "";
    var tabs = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true")
                           .attr("id", "lbTabs").append(cEl("ul").attr("class", "etabs")
                           .append(
                               cEl("li").listener("click", switchPrizesTabs, false).attr("class", "tab").append(cEl("a").wr({ el: "playerCompetitions" }).tEl("Player Competitions"))
                           ).append(
                               cEl("li").listener("click", switchPrizesTabs, false).attr("class", "tab active").append(cEl("a").wr({ el: "clanCompetitions" }).tEl("Clan Competitions"))
                           ));
    var tabContainer = cEl("div").attr("class", "panel-container").attr("style", "overflow: hidden;");

    var tbMain = cEl("div").attr("class", "tab-block active").attr("id", "tbMain").attr("style", "display: block; position: static; visibility: visible;");

    tabContainer.append(tbMain);

    tabs.append(tabContainer);
    mainC.append(tabs);


    var euroClanCompetition = cEl("div")
        .append(cEl("p").tEl(" During EURO 2016 there will be a special Clan Competition and it will dispose prizes as below:"))
        .append(cEl("ol").attr("style", "list-style-type:none;")
        .append(cEl("li").tEl("Clan 1 -> 1100$ (100$ for each player)"))
        .append(cEl("li").tEl("Clan 2 -> 440$ (40$ for each player)"))
        .append(cEl("li").tEl("Clan 3 -> 220 Golden Balls (20 Golden Balls for each player)"))
        );


    var clanBattlesCompetition = cEl("div").append(cEl("p").tEl("This competition lasts about 1 months and is a clan competition for who gets to be the best clan on the Game... The Points accumulated from all players of the clan will be summed together to make clan points..."))
        .append(cEl("p").tEl(" Coalition with your friends in this competition in order to become the best Clan and win fantastic prizes below:"))
        .append(cEl("ol").attr("style","list-style-type:none;")
        .append(cEl("li").tEl("Clan 1 -> 1100$ (100$ for each player)"))
        .append(cEl("li").tEl("Clan 2 -> 440$ (40$ for each player)"))
        .append(cEl("li").tEl("Clan 3 -> 220 Golden Balls (20 Golden Balls for each player)")));


    var seasonClanCompetition = cEl("div").append(cEl("p").tEl("This competition lasts about 3 months and is a long clan competition for who gets to be the best clan on the Game... The Points accumulated from all players of the clan will be summed together to make clan points..."))
        .append(cEl("p").tEl(" Coalition with your friends in this competition in order to become the best Clan and win fantastic prizes below:"))
        .append(cEl("ol").append(cEl("li").tEl("Clan 50 - 41 -> HATS + 50 golden balls"))
        .append(cEl("li").tEl("Clan 40 - 21 -> Stylish Bracelets + 60 golden balls"))
        .append(cEl("li").tEl("Clan 20 - 11 -> Favourite Team Football Jearsey + 70 golden balls)"))
        .append(cEl("li").tEl("Clan 10 - 4 -> Footballclans Golden Bracelet + 80 golden balls"))
        .append(cEl("li").tEl("Clan 3 - 2 -> Smartphone + 100 golden balls"))
        .append(cEl("li").tEl("Clan 1 -> a Wonderful IBIZA Vacation EXPERIENCE + 200 golden balls")));

    var yearlyClanCompetition = cEl("div")
        .append(cEl("ol").append(cEl("li").tEl("Clan 200 - 51 -> 70 golden balls"))
        .append(cEl("li").tEl("Clan 50 - 41 -> HATS + 50 golden balls"))
        .append(cEl("li").tEl("Clan 40 - 26 -> Stylish Bracelets + 60 golden balls"))
        .append(cEl("li").tEl("Clan 25 - 16 -> Favourite Team Football Jearsey + 70 golden balls"))
        .append(cEl("li").tEl("Clan 15 - 6 -> Footballclans Golden Bracelet + 80 golden balls"))
        .append(cEl("li").tEl("Clan 5 - 4 -> Smartphone + 100 golden balls"))
        .append(cEl("li").tEl("Clan 3 - 1 -> a Wonderful Vacation EXPERIENCE + 200 golden balls")));





    var rootElement = cEl("div").attr("class", "row-fluid prizes");
    var prizes = cEl("div").attr("class", "row-fluid");
    prizes.append(
            genAccordionElementa("battlesclantab", "Clan Battles", null, clanBattlesCompetition)
            )
        .append(
            genAccordionElement("euroclantab", "Euro 2016 clans", null, euroClanCompetition)
            );
    /*

        .append(
            genAccordionElement("seasonclantab", "Season single competition SSC", null, seasonClanCompetition)
            )
        .append(
            genAccordionElement("yearlyclantab", "Yearly clan competition YCC", null, yearlyClanCompetition)
            ); */

    rootElement.append(prizes);
    mainC.append(rootElement);
}
function genAccordionElementa(elementid, headertext, headerevent, bodyelement) {

    var a = cEl("div")
        .attr("class", "accordion-group")
        .append(
            cEl("div")
            .attr("class", "accordion-heading")
            .append(
                cEl("a")
                .attr("class", "accordion-toggle collapsed").attr("data-toggle", "collapse").attr("data-parent", "#accordion").attr("href", "#" + elementid)
                .listener("click", headerevent ? headerevent : function () { })
                .append(
                    cEl("h5").tEl(headertext)
                )
            )
        )
        .append(
            cEl("div")
            .attr("id", elementid).attr("class", "accordion-body in collapse").attr("style", "height: auto;")
            .append(
                cEl("div")
                .attr("class", "accordion-inner")
                .append(bodyelement)
            )
        );
    return a;
}
function switchPrizesTabs(e) {
    var tbs = e.target.parentNode.parentNode.childNodes;

    var clicked = e.target.wrapper.el;
    for (var j = 0; j < tbs.length; j++) {
        tbs[j].className = tbs[j].className.replace("active", "").replace(" ", "");

    }

    this.className = "tab active";

    switch (clicked) {
        case "playerCompetitions":
            genPlayerPrizes();
            break;
        case "clanCompetitions":
            genClanPrizes();
            break;
    }
}