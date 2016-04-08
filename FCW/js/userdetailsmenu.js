var headerInterval;
function getPreds() {
    var date = getFullDate(new Date(), 0);
    
    
    var divpoints = document.getElementById("points");
    divpoints.innerHTML = "";
$.post("Actions/Fixture.aspx", { type: "PREDS", date: date },
function (e) {
    var totPoints = 0;
    var matches = JSON.parse(e);
    
                

    for (var i = 0; i < matches.length; i++) {
        totPoints += matches[i].PointsWon;
    }
   
    var tp = cEl("div").attr("class", "points-today").append(cEl("div").attr("class", "title-menu").tEl("TODAY POINTS :")).append(cEl("div").attr("class", "today-points").tEl(totPoints));
    
    divpoints.appendChild(tp);
});
    date = getFullDate(new Date(), -1);
    $.post("Actions/Fixture.aspx", { type: "PREDS", date: date },
function (e) {
    var totPoints = 0;
    var matches = JSON.parse(e);



    for (var i = 0; i < matches.length; i++) {
        totPoints += matches[i].PointsWon;
    }
    var tp = cEl("div").attr("class", "points-yesterday").append(cEl("div").attr("class", "title-menu").tEl("YESTERDAY POINTS :")).append(cEl("div").attr("class", "yesterday-points").tEl(totPoints));
    setTimeout(function () { divpoints.appendChild(tp); }, 1000);
    
});


}
var clan = document.getElementById("clanDetails-menu");
function getClans() {
    $.post("Actions/User.aspx", { type: "GU" },
                  function (e) {
                      e = JSON.parse(e);
                      if (e.ClanId === -1 || e.ClanId === 0) {
                          return;
                      }
                      else {

                      
    $.post("Actions/User.aspx", { type: "CDL", id: e.ClanId },
                  function (c) {
                      clan.innerHTML = " ";
                     c = JSON.parse(c);
                      clan.append(genClanMenu(c));




                  });
                      }
     });
}


function getMenuInfo() {

    if (document.getElementById("userModal") && document.getElementById("userModal").getAttribute("aria-hidden") === "false")
        return;

    $.post("Actions/User.aspx", { type: "RFR" },
     function (e) {
         e = JSON.parse(e);
         cuser = e;
         var username = e.Username.toUpperCase(); //username
         var points = e.Points; //total poins
         var userCredit = e.Credit; //golden balls
         var userCredit2 = e.Credit2;
         var overallBadge = getOverAllForm(e); //niveli
         var lastBadge = getUserForm(e); //forma
         var rank = e.Rank; //global rank
         var h = document.getElementById("myDetails-Menu");
         var avatar = document.getElementById("avatar");
         var logout = document.getElementById("userModal");
         var balls = document.getElementById("balls");
         balls.innerHTML = "";
         
         var goldenball = cEl("div").attr("class", "goldenBall-header").append(cEl("div").attr("class", "totalballs1").tEl(userCredit2)).append(cEl("span").attr("class", "footBall header-margin"))
             .append(cEl("div").attr("class", "totalballs").tEl(userCredit)).append(cEl("span").attr("class", "creditBall header-margin"))
             .append(cEl("div").attr("class","tp-header").tEl("PTS:"+points));
        
         balls.appendChild(goldenball);
         var thumbNail = cEl("a").attr("class", "thumbnail pull-right").attr("href", "#").append(cEl("img").attr("style", "height:27px;").attr("src", "style/images/avatars/" + cuser.AvatarId + ".png")).listener("click", genUserDetails);
         avatar.innerHTML = "";
         avatar.appendChild(thumbNail);

         
         var emri1 = cEl("div").attr("class", "details-menu").append(cEl("div").attr("class", "details-username").tEl(username)).append(cEl("div").attr("class", "details-progress").append(genProgressBar(lastBadge))); //username+forma
         var totalpoints = cEl("div").attr("class", "tp-menu").append(cEl("div").attr("class", "title-menu").tEl("POINTS :")).append(cEl("div").attr("class", "total-points").tEl(points));//total points : piket
         var level = cEl("div").attr("class", "lvl-menu").append(cEl("div").attr("class", "title-menu").tEl("LEVEL :")).append(cEl("span").attr("class", "total-points label-warning").tEl(overallBadge)); // niveli
         var globalrank = cEl("div").attr("class", "rank-menu").append(cEl("div").attr("class", "title-menu").tEl("GLOBAL RANK :")).append(cEl("div").attr("class", "total-points").tEl(rank)); //global rank
         var refresh = document.getElementById("refreshPage");
         
         refresh.innerHTML = "";
         refresh.appendChild(cEl("img").attr("src", "style/images/reload.png").attr("width", "35px")).addEventListener("click", function () { window.location.reload(); });
          
         getPreds();
         getClans();

         
         
      

         
         /*
         var overallBadgeClass = "label-warning";

         
         
         
         var goldenBall = cEl("span").attr("class", "creditBall header-margin");
         var userEl = cEl("h4").attr("class", "media-heading").tEl(username);
         var credit = cEl("p").attr("class", "row-fluid").attr("style", "padding: 5px;")
             .append(cEl("div").attr("class", "row-fluid span4").tEl("Level :").append(cEl("span").attr("class", "header-margin label " + overallBadgeClass).tEl(overallBadge)))
             .append(cEl("div").attr("class", "row-fluid span8").append(cEl("span").attr("style", "float:left;margin-right:1em;").tEl("Form : ")).append(genProgressBar(lastBadge)));

         

         var userDetailEl = cEl("div").attr("class", "media-body").append(credit);
         var body = cEl("div").attr("class", "media-body");

         body.append(userEl).append(userDetailEl).append(goldenBall).append(cEl("span").attr("class", "userCredit").tEl(userCredit));

         var hEl = cEl("div").attr("class", "well well-sm").append(cEl("div").attr("class", "media").append(body));
         */
         
         
         h.innerHTML = "";
         h.appendChild(emri1).append(totalpoints).append(level).append(globalrank);
         headerInterval = setTimeout(function () { getMenuInfo() }, 600000);
     });
    
}


function genClanMenu(c) {
    var clanPts = 0;
    for (var i = 0; i < c.Users.length; i++) {
        clanPts += c.Users[i].Points;
    }

    var clanname = c.Name;
    var clanrank = c.Rank;
    var avaragepoints = (clanPts / c.Users.length).toFixed(2);
    var clannamediv = cEl("div").attr("class", "clan-name").append(cEl("div").attr("class", "title-menu").tEl("CLAN NAME :")).append(cEl("div").attr("class", "clanname").tEl(clanname));
    var clanrankdiv = cEl("div").attr("class", "clan-rank").append(cEl("div").attr("class", "title-menu").tEl("CLAN RANK :")).append(cEl("div").attr("class", "clanrank").tEl(clanrank));
    var clanpointsdiv = cEl("div").attr("class", "clan-points").append(cEl("div").attr("class", "title-menu").tEl("CLAN POINTS :")).append(cEl("div").attr("class", "clanpoints").tEl(clanPts));
    var avaragepointsdiv = cEl("div").attr("class", "clan-avarage").append(cEl("div").attr("class", "title-menu").tEl("AVARAGE POINTS :")).append(cEl("div").attr("class", "avgpoints").tEl(avaragepoints));
    

    var m = cEl("div").attr("class", "clandiv").append(clannamediv).append(clanrankdiv).append(clanpointsdiv).append(avaragepointsdiv);

    return m;
}