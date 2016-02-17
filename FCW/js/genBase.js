 /*matches
 **predictions
 **clans
 **leagues
 **leadbord
 **livescore
 **account*/

var state = true;
var mObjs = new Array();
var username = "";
var mode = "";
genHeader();

window.onload = function (e) {
    var menus = $("li[content-type]");
    for (i = 0; i < menus.length; i++) {
        menus[i].addEventListener("click", getContent);
    }
    genMatches();
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
         case "leadbord":
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

 function genMatches(){
     $.post("Actions/Fixture.aspx", { type:"UDM" },
        function (e) {
            var matches = JSON.parse(e);
            genGrid(matches);
        });
 }

 function genPredictions(date) {
     console.log(date);
     $.post("Actions/Fixture.aspx", { type: "PREDS", date : date },
   function (e) {
       var matches = JSON.parse(e);
       genGrid(matches);
   });
 }

 function genClans() {
     var mainC = document.getElementById("mainContainer");
     mainC.innerHTML = "";

     $.post("Actions/User.aspx", { type: "GU"},
       function (e) {
           e = JSON.parse(e);
           if (e.ClanId === 0) { //NoClan : Show CreateClan or JoinClan
               //CreateClan
               var ccPanel = createPanel("Create you own clan!");
               ccPanel.id = "ccp";
               var ccBody = ccPanel.getElementsByClassName("panel-body")[0];

               var icc = document.createElement("input");
               icc.setAttribute("placeholder", "New Clan Name");
               icc.className = "form-control input-sm";
               icc.id = "icc";
               icc.type = "text";

               var btnCreateClan = document.createElement("button");
               btnCreateClan.type = "button";
               btnCreateClan.className = "btn btn-success";
               btnCreateClan.innerHTML = "Create!";
               btnCreateClan.addEventListener("click", CreateClan);

               ccBody.appendChild(icc);
               ccBody.appendChild(btnCreateClan);

               //Arrow section
               var greenArrow = document.createElement("hr");
               greenArrow.className = "arrow";

               //JoinClan
               var jcPanel = createPanel("Join a clan!");
               jcPanel.id = "jcp";
               var jcBody = jcPanel.getElementsByClassName("panel-body")[0];

               /*var ijc = document.createElement("input");
               ijc.setAttribute("placeholder", "Search Clan");
               ijc.className = "form-control input-sm";
               ijc.type = "text";
               jcBody.appendChild(ijc);*/

               var btnJoinClan = document.createElement("button");
               btnJoinClan.type = "button";
               btnJoinClan.className = "btn btn-success";
               btnJoinClan.innerHTML = "Join Clan!";
               btnJoinClan.addEventListener("click", JoinClan);
               
               var ddc = GenClanList();
               jcBody.appendChild(ddc);
               jcBody.appendChild(btnJoinClan);

               //Append Everything
               mainC.appendChild(ccPanel);
               mainC.appendChild(greenArrow);
               mainC.appendChild(jcPanel);

           } else { //InClan : Show ClanDetails
               console.log(e.ClanId);
               $.post("Actions/User.aspx", { type: "CDL", id : e.ClanId },
                   function(c) {
                       c = JSON.parse(c);
                       console.log(c);
                       mainC.append(cEl("h3").tEl(c.Name));
                       var rFluid = document.createElement("div");
                       rFluid.id = "tblContainer";
                       //rFluid.className = "row-fluid";
                       var opts = "";

                       var exGrid = document.getElementById("match-table");
                       if (exGrid) {
                           exGrid.parentNode.removeChild(exGrid);
                       }

                       // rFluid.innerHTML = tableTxt;

                       rFluid.appendChild(genClanTable(c));
                       mainC.appendChild(rFluid);

                       /***After Event Assignments***/
                       $('[data-toggle="tooltip"]').tooltip();
                       /****************************/
                   });
           }
   });
    //ajax if user is in clan than show clan
        
    //else show button create clan
}

 function genLeagues(){
     
 }

 function genLeadBoard(){
     
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

 function genHeader() {
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
    if (e.type === "click") {
        var el = document.getElementById(e.target.id);

    }
    else if (e.type === "change") {
        var el =  e.target.options[e.target.selectedIndex];
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

function sendPredictions() {
    var ps = document.getElementsByClassName("odd bet");
    var pString = "";

    for (var i = 0; i < ps.length; i++) {
        pString += ps[i].getAttribute("data-odd") + ";";

    $.post("Actions/Fixture.aspx", { type: "SNDPD", pds: pString.substring(0, pString.length - 1) });
    }
    genMatches();
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

function genGrid(matches) {
    var mainC = document.getElementById("mainContainer");
    var rFluid = document.createElement("div");
    rFluid.id = "tblContainer";
    //rFluid.className = "row-fluid";
    var opts = "";

    var exGrid = document.getElementById("match-table");
    if (exGrid) {
        exGrid.parentNode.removeChild(exGrid);
    }

   // rFluid.innerHTML = tableTxt;

    rFluid.appendChild(genTable("match-table", matches, state));
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