 /*matches
 **predictions
 **clans
 **leagues
 **leadbord
 **livescore
 **account*/

window.onload = function (e) {
    console.log('kalova');
    var menus = $("li[content-type]");
    console.log(menus);
    for (i = 0; i < menus.length; i++) {
        console.log(menus[i]);
        menus[i].addEventListener("click", getContent);
    }
    genMatches();
}

 function getContent(e){
     var type = this.getAttribute('content-type');
     console.log(type);
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
            console.log(matches);

            var mainC = document.getElementById("mainContainer");
            var rFluid = document.createElement("div");
            rFluid.className = "row-fluid";
            var opts = "";
            for (var i = 0; i < matches[0].Games.length; i++) {
                opts += "<th>" + matches[0].Games[i].Name + "</th>";
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
            for (var i = 0; i < matches.length; i++) {

                var inMatchGroups = "";
                for (var j = 0; j < matches[i].Games.length; j++) {
                    inMatchGroups += "<td>";
                    for (var k = 0; k < matches[i].Games[j].Outcomes.length; k++) {
                        inMatchGroups += "<a class=\"odd\" onclick=\"setPrediction(this)\" data-group=\"" + matches[i].Games[j].Slug + "\" data-odd=\"" + matches[i].ID + "|" + matches[i].Games[j].Outcomes[k].Name + "\" >" + matches[i].Games[j].Outcomes[k].Name + " </a> ";
                    }
                    inMatchGroups += "</td>";
                }

                tableTxt += "<tr id = \"rid"+ matches[i].ID + "\"> \
                            <td>" + matches[i].HomeTeam.Name + "-" + matches[i].AwayTeam.Name + "</td> \
                            <td>18:45" /*+ matches[i].AwayTeam.Name +*/ + "</td> \
                            <td>" + matches[i].League.Name + "</td>\
                            " + inMatchGroups;
                tableTxt += "</tr>";
            }

            tableTxt += "</tbody>\
                        </table><a class=\"btn btn-block btn-success\" href=\"#\">Submit</a>";
            

            rFluid.innerHTML = tableTxt;



            /*
                <table class="table table-hover" id="bootstrap-table">
                <thead>
                <tr>
                    <th>#ID</th>
                    <th>Username</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                </tr>
                </thead>
            */
            mainC.appendChild(rFluid);
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
    var as = [];
    
    console.log(as);

    for (var i = 0; i < allAs.length; i++) {
        if (allAs[i].getAttribute("data-group") == e.getAttribute("data-group")) {
            allAs[i].className = "odd";
        }
    }

    e.className = "odd bet";

}