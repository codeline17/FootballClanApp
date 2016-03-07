var headerInterval;

function genHeader() {
    getHeaderInfo();
}

function getHeaderInfo() {

    if (document.getElementById("userModal") && document.getElementById("userModal").getAttribute("aria-hidden") === "false")
        return;

    $.post("Actions/User.aspx", { type: "RFR" },
     function (e) {
         e = JSON.parse(e);
         cuser = e;
         var h = document.getElementById("mainHeader");

         var username = e.Username.toUpperCase() + "     - " + e.Points + " POINTS";
         var userCredit = e.Credit;

         var overallBadge = getOverAllForm(e);
         var overallBadgeClass = "label-warning";

         var lastBadge = getUserForm(e);

         var btnLogout = cEl("a").attr("href", "#").attr("class", "btn btn-orange pull-right").tEl("Logout").listener("click", fnLogout, false);
         var goldenBall = cEl("span").attr("class", "creditBall header-margin");
         var userEl = cEl("h4").attr("class", "media-heading").tEl(username).append(cEl("span").attr("class", "userCredit").tEl(userCredit).append(goldenBall));
         var credit = cEl("p").attr("class", "row-fluid").attr("style","padding: 5px;")
             .append(cEl("div").attr("class", "row-fluid span4").tEl("Level :").append(cEl("span").attr("class", "header-margin label " + overallBadgeClass).tEl(overallBadge)))
             .append(cEl("div").attr("class", "row-fluid span8").append(cEl("span").attr("style","float:left;margin-right:1em;").tEl("Form : ")).append(genProgressBar(lastBadge)));
         var badges = cEl("p").attr("class", "row-fluid").append(btnLogout);

         var userDetailEl = cEl("div").attr("class", "media-body").append(userEl).append(credit).append(badges);
         var thumbNail = cEl("a").attr("class", "thumbnail pull-left").attr("href", "#").append(cEl("img").attr("class", "media-object").attr("style", "height:60px;").attr("src", "style/images/avatars/" + cuser.AvatarId + ".png")).listener("click", genUserDetails);
         var body = cEl("div").attr("class", "media-body").append(userEl);

         body.append(thumbNail).append(userDetailEl);

         var hEl = cEl("div").attr("class", "well well-sm").append(cEl("div").attr("class", "media").append(body));

         h.innerHTML = "";
         h.appendChild(hEl);
         headerInterval = setTimeout(function () { getHeaderInfo() }, 60000);
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
    w = w ? w : 0;
    switch (true) {

        case (w < 25):
            cl += "red";
            break;
        case (w > 25 && w < 50):
            cl += "orange";
            break;
        case (w >= 50 && w < 70):
            cl += "blue";
            break;
        case (w >= 70):
            cl += "green";
            break;
    }

    var cDiv = cEl("div").attr("class", "progress").append(cEl("div").attr("class", "progress-bar " + cl).attr("role", "progressbar").attr("aria-valuenow", w / 2).attr("aria-valuemin", 0).attr("aria-valuemax", 100).attr("style", "width:" + w + "%;").tEl(Math.floor(w)));

    return cDiv;
}

function getUserForm(user) {
    var form = Math.floor((user.LastSuccessfulPredictions / user.LastPredictions) * 200);
    return form ? form : 0;
}

function getOverAllForm(user) {
    var form = Math.floor(user.TotalPredictions / 1000) + 1;
    return form ? form : 0;
}