 /*matches
 **predictions
 **clans
 **leagues
 **leadbord
 **livescore
 **account*/
var cuser = "";
var state = true;
var mObjs = new Array();
var username = "";
var mode = "";
var matches = "";
genHeader();

window.onload = function (e) {
    var menus = $("li[content-type]");
    for (i = 0; i < menus.length; i++) {
        menus[i].addEventListener("click", getContent);
    }
    genLeadBoard();

    cuser = JSON.parse(getCookie("u"));
}

 function getContent(e){
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
             genMatches();
             break;
         case "predictions":
             state = false;
             addFilterHead();
             genPredictions(getFullDate(new Date()));
             break;
         case "clans":
            genClans();
             break;
         case "leagues":
            genLeagues();
             break;
         case "leadboard":
            genLeadBoard();
             break;
         case "livescore":
             addFilterHead();
             genLiveScore(getFullDate(new Date()));
             break;
         case "account":
            genAccount();
             break;
         default:
             break;
     }
 }

function getMatches(opt) {
    $.post("Actions/Fixture.aspx", { type: "UDM" },
        function (e) {
            matches = JSON.parse(e);
            if (opt === "w") {
                genMatches();
            } else {
                var trs = document.getElementsByTagName("tr");
                for (var j = 0; j < matches.length; j++) {
                    console.log(matches[j].ID);
                    for (var i = 0; i < trs.length; i++) {
                        if (trs[i].wrapper) {
                            if (trs[i].wrapper.ID === matches[j].ID) {
                                trs[i].wrapper = matches[j];
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

 function genPredictions(date) {
     $.post("Actions/Fixture.aspx", { type: "PREDS", date : date },
   function (e) {
       var matches = JSON.parse(e);
       genGrid(matches, date);
   });
 }

 function genLeagues() {
     getLeagueData();
 }

 function genLeadBoard() {
     genFavoritesObjs(1);
 }

 function genAccount() {

     var mainC = document.getElementById("mainContainer");

     $.post("Actions/Fixture.aspx", { type: "GUN" },
   function (e) {
        var lblUserName = document.createElement("span");
        lblUserName.innerHTML = "Username : " + e.split("|")[0] + "                      ";
        lblUserName.style.cssFloat = "left";

        var newPassword = document.createElement("input");
        newPassword.setAttribute("placeholder", "New Password");
        newPassword.className = "form-control input-sm";
        newPassword.type = "text";

        var confirmNewPassword = document.createElement("input");
        confirmNewPassword.setAttribute("placeholder", "Confirm New Password");
        confirmNewPassword.className = "form-control input-sm";
        confirmNewPassword.type = "text";

        var btnDo = document.createElement("button");
        btnDo.type = "button";
        btnDo.className = "btn btn-danger";
        btnDo.innerHTML = "Confirm";

        mainC.appendChild(lblUserName);
        mainC.appendChild(newPassword);
        mainC.appendChild(confirmNewPassword);
        mainC.appendChild(btnDo);
   });
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
      nameSpan.style = "margin-right : 15px;"

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
/*
function sendPredictions() {
    var ps = document.getElementsByClassName("odd bet");
    var pString = "";

    for (var i = 0; i < ps.length; i++) {
        pString += ps[i].getAttribute("data-odd") + ";";

    $.post("Actions/Fixture.aspx", { type: "SNDPD", pds: pString.substring(0, pString.length - 1) });
    }
    genMatches();
}
*/
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

    if (date !== "nope") {
        var totPoints = 0;

        for (var i = 0; i < matches.length; i++) {
            totPoints += matches[i].PointsWon;
        }

        var pEl = cEl("h3").tEl(date + " - " + totPoints + " points").attr("style","text-align:center;");

        rFluid.append(pEl);
    }
    
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
        if (mode==="predictions") {
            genPredictions(getFullDate(dt));
        }
        else if (mode ==="livescore") {
            genLiveScore(getFullDate(dt));
        }
    });
    //$("#predSBtn").click(function () { genPredictions($("#pref-search").text) })
}

function getFullDate(date) {
    var dd = date.getDate();
    var mm = date.getMonth() + 1; //January is 0!

    var yyyy = date.getFullYear();
    if (dd < 10) {
        dd = "0" + dd;
    }
    if (mm < 10) {
        mm = "0" + mm;
    }
    return dd - 1 + "/" + mm + "/" + yyyy;
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