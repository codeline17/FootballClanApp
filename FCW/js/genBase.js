 /*matches
 **predictions
 **clans
 **leagues
 **leadbord
 **livescore
 **account*/

window.onload = function (e) {
    var menus = $("li[content-type]");
    for (i = 0; i < menus.length; i++) {
        menus[i].addEventListener("click", getContent);
    }
    genMatches();
}

 function getContent(e){
     var type = this.getAttribute("content-type");
     switch (type) 
     {
         case "matches":
             genMatches();
             break;
         case "predictions":
            genPredictions();
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

            var mainC = document.getElementById("mainContainer");
            mainC.innerHTML = "";
            var rFluid = document.createElement("div");
            rFluid.className = "row-fluid";
            var opts = "";

            for (var i = 0; i < matches[0].Games.length; i++) {
                opts += "<th><span data-toggle=\"tooltip\" data-placement=\"top\" title=\"" + matches[0].Games[i].Name + "\" >" + matches[0].Games[i].Slug + "</span></th>";
            }
            var tableTxt = "<table class=\"table table-hover\" id=\"bootstrap-table\">\
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
                        inMatchGroups += "<a class=\"odd\" onclick=\"setPrediction(this)\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"" + getShortTeamName(matches[h].Games[j].Outcomes[k].Name, matches[h], 100) + "\" data-group=\"" + matches[h].Games[j].Slug + "\" data-odd=\"" + matches[h].ID + "|" + matches[h].Games[j].Slug + "|" + matches[h].Games[j].Outcomes[k].Name + "\" >" + getShortTeamName(matches[h].Games[j].Outcomes[k].Name, matches[h], 5) + "</a> ";
                    }
                    inMatchGroups += "</td>";
                }

                tableTxt += "<tr id = \"rid"+ matches[h].ID + "\"> \
                            <td><span data-toggle=\"tooltip\" data-placement=\"top\" title=\"" + matches[h].HomeTeam.Name + "-" + matches[h].AwayTeam.Name + "\">" + getFixtureName(matches[h]) + "</td> \
                            <td>" + matches[h].ShortTime + "</td> \
                            <td><span data-toggle=\"tooltip\" data-placement=\"top\" title=\"" + matches[h].League.Name + "\">" + matches[h].League.Name     + "</span></td>\
                            " + inMatchGroups;
                tableTxt += "</tr>";
            }

            tableTxt += "</tbody>\
                        </table><a id=\"predictionSubmit\" data-toggle=\"confirmation\" class=\"btn btn-block btn-success\" href=\"#\">Submit</a>";
            

            rFluid.innerHTML = tableTxt;
            mainC.appendChild(rFluid);
            
            /***After Event Assignments***/
            $('[data-toggle="tooltip"]').tooltip();
            $('[data-toggle="confirmation"]').confirmation({ popout: true });
            var submitBtn = document.getElementById("predictionSubmit");
            submitBtn.addEventListener("click", sendPredictions);
            /****************************/

        });
 }

 function genPredictions(){
     
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
    var matchId = e.getAttribute("data-odd").split('|')[0];
    var row = document.getElementById("rid" + matchId);
    var allAs = row.querySelectorAll("[data-odd]");
    var prevClass = e.className;
    
    for (var i = 0; i < allAs.length; i++) {
        if (allAs[i].getAttribute("data-group") === e.getAttribute("data-group")) {
            allAs[i].className = "odd";
        }
    }

    if (prevClass === "odd bet")
        return;

    e.className = "odd bet";
}

function sendPredictions() {
    var ps = document.getElementsByClassName("odd bet");
    var pString = "" ;

    for (var i = 0; i < ps.length; i++) {
        pString += ps[i].getAttribute("data-odd") + ";";
    }

    console.log(pString);
    console.log(pString.substring(0, pString.length - 1));

    /*$.post("Actions/Fixture.aspx", { type: "SNDPD", pds: pString.substring(0, pString.length - 1) },
        function(e) {
            console.log(e);
        });*/
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