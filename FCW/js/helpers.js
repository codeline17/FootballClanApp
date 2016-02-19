function genHeader() {
    //$.post("Actions/Fixture.aspx", { type: "GUN" },
    $.post("Actions/User.aspx", { type: "GU" },
     function (e) {
         e = JSON.parse(e);
         var h = document.getElementById("mainHeader");

         var username = e.Username + "     - " + e.Points + " points";
         var userCredit = e.Credit;

         var overallBadge = Math.floor(e.PredictionsNo / 1000) + 1;
         var overallBadgeClass = "label-warning";

         var lastBadge = Math.floor(e.SuccessfulPredictions / e.PredictionsNo + 1);
         var lastBadgeClass = "label-default";

         var btnLogout = cEl("a").attr("href", "#").attr("class", "btn btn-orange pull-right").tEl("Logout").listener("click", fnLogout, false);
         var userEl = cEl("h4").attr("class", "media-heading").tEl(username);
         var goldenBall = cEl("span").attr("class", "creditBall header-margin");
         var credit = cEl("p").append(goldenBall).append(cEl("span").attr("class", "userCredit").tEl(userCredit)).append(cEl("span").attr("class", "header-margin label " + overallBadgeClass).tEl(overallBadge)).append(cEl("span").attr("class", "header-margin label " + lastBadgeClass).tEl(lastBadge));
         var badges = cEl("p").append(btnLogout);

         var userDetailEl = cEl("div").attr("class", "media-body").append(userEl).append(credit).append(badges);

         var thumbNail = cEl("a").attr("class", "thumbnail pull-left").attr("href", "#").append(cEl("img").attr("class","media-object").attr("style","height:60px;").attr("src", "style/images/default_avatar.png"));
         var body = cEl("div").attr("class", "media-body").append(userEl);

         body.append(thumbNail).append(userDetailEl);

         var hEl = cEl("div").attr("class", "well well-sm").append(cEl("div").attr("class", "media").append(body));
         
         h.innerHTML = "";
         h.appendChild(hEl);
     });

}

function fnLogout() {
    $.post("Actions/User.aspx", { type: "LO" },
        function (e) {
            console.log(e);
            window.location = "Login.aspx";
        });
}