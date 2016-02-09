 /*matches
 **predictions
 **clans
 **leagues
 **leadbord
 **livescore
 **account*/

var state = true;
var mObjs = new Array();

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
         case "leagues":
            genLeagues();
             break;
         case "leadbord":
            genLeadBoard();
             break;
         case "livescore":
            genLiveScore();
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
            addPredSubmitBtn();
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

 function genLeagues(){
     
 }

 function genLeadBoard(){
     
 }

 function genLiveScore(){
     
 }

 function genAccount(){
     
 }

function setPrediction(e) {
    //remove all other selected
    var el = document.getElementById(e.target.id);
    console.log(e.target.id);
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
}

function sendPredictions() {
    var r = confirm("Submit these predictions?");
    if (r === true) {
        var ps = document.getElementsByClassName("odd bet");
        var pString = "";

        for (var i = 0; i < ps.length; i++) {
            pString += ps[i].getAttribute("data-odd") + ";";
        }

        $.post("Actions/Fixture.aspx", { type: "SNDPD", pds: pString.substring(0, pString.length - 1) });

        genMatches();
    }
}

function getShortTeamName(name, match, length) {
    if (length === 100) {
        return name.replace("[Home]", match.HomeTeam.Name).replace("[Away]", match.AwayTeam.Name).replace("[Draw]", "Draw").replace(" ", "");
    } else {
        return name.replace("[Home]", match.HomeTeam.Name).replace("[Away]", match.AwayTeam.Name).replace("[Draw]", "Draw").replace(" ", "").substring(0, 8);
    }
}

function getFixtureName(match) {
    return match.HomeTeam.Name.substring(0, 10) + "-" + match.AwayTeam.Name.substring(0, 10);
}

function genGrid(matches) {
    var mainC = document.getElementById("mainContainer");
    var rFluid = document.createElement("div");
    rFluid.id = "tblContainer";
    rFluid.className = "row-fluid";
    var opts = "";

    var exGrid = document.getElementById("match-table");
    if (exGrid) {
        exGrid.parentNode.removeChild(exGrid);
    }

    for (var i = 0; i < matches[0].Games.length; i++) {
        opts += "<th><span data-toggle=\"tooltip\" data-placement=\"top\" title=\"" + matches[0].Games[i].Name + "\" >" + matches[0].Games[i].Slug + "</span></th>";
    }
    var tableTxt = "<table class=\"table table-hover\" id=\"match-table\">\
                            <thead>\
                            <tr>\
                                <th>Match</th>\
                                <th>Time</th>\
                                <th>League</th>\
                                " + opts + "</tr>\
                            </thead>\
                            <tbody>";

    for (var h = 0; h < matches.length; h++) {
        var inMatchGroups = "";
        for (var j = 0; j < matches[h].Games.length; j++) {
            inMatchGroups += "<td>";
            for (var k = 0; k < matches[h].Games[j].Outcomes.length; k++) {
                var cl = (matches[h].Sealed ? "greyed" : "");
                cl += (matches[h].Sealed ? " closed" : "");
                var event = !matches[h].Sealed && state;
                inMatchGroups += "<a class=\"odd " + cl + "\" " + (event ? "onclick = \"setPrediction(this)\"" : "") +
                    " data-toggle=\"tooltip\" data-placement=\"top\" title=\"" +
                    getShortTeamName(matches[h].Games[j].Outcomes[k].Name, matches[h], 100) + "\" data-group=\"" +
                    matches[h].Games[j].Slug + "\" data-odd=\"" + matches[h].ID + "|" + matches[h].Games[j].Slug + "|" +
                    matches[h].Games[j].Outcomes[k].Name + "\" >" + getShortTeamName(matches[h].Games[j].Outcomes[k].Name, matches[h], 5) +
                    "</a> ";
            }
            inMatchGroups += "</td>";
        }

        tableTxt += "<tr id = \"rid" + matches[h].ID + "\"> \
                            <td><span data-toggle=\"tooltip\" data-placement=\"top\" title=\"" + matches[h].HomeTeam.Name + "-" + matches[h].AwayTeam.Name + "\">" + getFixtureName(matches[h]) + "</td> \
                            <td>" + matches[h].ShortTime + "</td> \
                            <td><span data-toggle=\"tooltip\" data-placement=\"top\" title=\"" + matches[h].League.Name + "\">" + matches[h].League.Name.substring(0,8) + "</span></td>\
                            " + inMatchGroups;
        tableTxt += "</tr>";
    }

    tableTxt += "</tbody>\
                        </table>";


   // rFluid.innerHTML = tableTxt;

    rFluid.appendChild(genTable("match-table", matches, state));
    mainC.appendChild(rFluid);

    /***After Event Assignments***/
    $('[data-toggle="tooltip"]').tooltip();
    /****************************/
}

function addPredSubmitBtn() {
    var rFluid = document.getElementById("tblContainer");
    var btnSb = document.createElement("a");
    btnSb.className = "btn btn-block btn-success";
    btnSb.id = "predictionSubmit";
    btnSb.innerText = "Submit";

    rFluid.appendChild(btnSb);
    var submitBtn = document.getElementById("predictionSubmit");
    submitBtn.addEventListener("click", sendPredictions);
}

function addFilterHead() {
    var mainC = document.getElementById("mainContainer");
    var filterHead = document.createElement("div");
    filterHead.className = "row";

    var htmlTxt = "<div class=\"panel panel-default\">\
                            <div class=\"panel-body\">\
                                <form class=\"form-inline\" role=\"form\">\
                                    <div class=\"form-group\">\
                                        <input type=\"datetime\" placeholder=\"Date (dd/mm/yyyy)\" class=\"form-control input-sm\" id=\"pref-search\">\
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
        console.log(e);
        var dt = e.date;
        genPredictions(getFullDate(dt));
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