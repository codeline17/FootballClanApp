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

         var lastBadge = (e.SuccessfulPredictions / e.PredictionsNo) * 200;
         lastBadge = lastBadge > 50 ? 50 : lastBadge;
         var lastBadgeClass = "label-default";

         var btnLogout = cEl("a").attr("href", "#").attr("class", "btn btn-orange pull-right").tEl("Logout").listener("click", fnLogout, false);
         var goldenBall = cEl("span").attr("class", "creditBall header-margin");
         var userEl = cEl("h4").attr("class", "media-heading").tEl(username).append(cEl("span").attr("class", "userCredit").tEl(userCredit).append(goldenBall));
         var credit = cEl("p").attr("style","padding-left:5px;").tEl("Level :").append(cEl("span").attr("class", "header-margin label " + overallBadgeClass).tEl(overallBadge)).append(cEl("span").attr("style","margin-left:13%;").tEl("Form : ")).append(genProgressBar(lastBadge));//.append(cEl("span").attr("class", "header-margin label " + lastBadgeClass).tEl(lastBadge));
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
            window.location = "Login.aspx";
        });
}

function genProgressBar(w) {

    var cl = "progress-bar-";

    console.log(w);
    switch (true) {

        case (w < 12.5):
            cl += "red";
            break;
        case (w > 12.5 && w < 25):
            cl += "orange";
            break;
        case (w > 25 && w < 37.5):
            cl += "blue";
            break;
        case (w > 37.5):
            cl += "green";
            break;
    }

    console.log(cl);

    var cDiv = cEl("div").attr("class", "progress").attr("style", "width:40%;float:right;").append(cEl("div").attr("class", "progress-bar " + cl).attr("role", "progressbar").attr("aria-valuenow", w * 2).attr("aria-valuemin", 0).attr("aria-valuemax", 100).attr("style", "width:" + w * 2 + "%;").tEl(Math.floor(w / 10)));

    return cDiv;
}