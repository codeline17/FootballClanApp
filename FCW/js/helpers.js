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

         var username = e.Username.toUpperCase() + "     - " + e.Points + " points";
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
            localStorage["rInfo"] = null;
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
    console.log(user);
    var fValue = user.LastSuccessfulPredictions / user.LastPredictions;
    fValue = fValue > 0.5 ? 0.5 : fValue;
    var form = Math.floor(fValue * 200);
    return form ? form : 0;
}

function getOverAllForm(user) {
    var form = Math.floor(user.TotalPredictions / 500) + 1;
    return form ? form : 0;
}


/*
<div class="accordion-group">
    <div class="accordion-heading">
        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
            <h5>100% Responsive</h5>
        </a> 
    </div>
    <div id="collapseOne" class="accordion-body collapse" style="height: 0px;">
        <div class="accordion-inner"> Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt. </div>
    </div>
</div>
*/

function genAccordionElement(elementid, headertext, headerevent, bodyelement) {
    var a = cEl("div")
        .attr("class", "accordion-group")
        .append(
            cEl("div")
            .attr("class", "accordion-heading")
            .append(
                cEl("a")
                .attr("class", "accordion-toggle collapsed").attr("data-toggle", "collapse").attr("data-parent", "#accordion").attr("href", "#" + elementid)
                .listener("click",headerevent ? headerevent : function() {})
                .append(
                    cEl("h5").tEl(headertext)
                )
            )
        )
        .append(
            cEl("div")
            .attr("id", elementid).attr("class", "accordion-body collapse").attr("style", "height: 0px;")
            .append(
                cEl("div")
                .attr("class", "accordion-inner")
                .append(bodyelement)
            )
        );
    return a;
}

function genRuleTuple(title, text) {
    return cEl("div")
        .append(
            cEl("h5").tEl(title)
        )
        .append(
            cEl("p").tEl(text)
        );
}

function posY(elm) {
    var test = elm, top = 0;

    while (!!test && test.tagName.toLowerCase() !== "body") {
        top += test.offsetTop;
        test = test.offsetParent;
    }

    return top;
}

function viewPortHeight() {
    var de = document.documentElement;

    if (!!window.innerWidth)
    { return window.innerHeight; }
    else if (de && !isNaN(de.clientHeight))
    { return de.clientHeight; }

    return 0;
}

function scrollY() {
    if (window.pageYOffset) { return window.pageYOffset; }
    return Math.max(document.documentElement.scrollTop, document.body.scrollTop);
}

function checkvisible(elm) {
    var vpH = viewPortHeight(), // Viewport Height
        st = scrollY(), // Scroll Top
        y = posY(elm);

    return (y > (vpH + st));
}