var imgsm = ["1", "2", "3", "4", "5", "6", "7", "8"];
function genUserDetails() {

    var exMd = document.getElementById("userModal");
    if (exMd) {
        exMd.parentNode.removeChild(exMd);
    }

    var mdHeader = cEl("div").attr("class", "modal-header").append(cEl("button").attr("type", "button").attr("class", "close").attr("data-dismiss", "modal").attr("aria-label", "Close")
                    .append(cEl("span").attr("aria-hidden", "true").tEl("x"))).append(cEl("h4").tEl("User Details"));
    var mdBody = cEl("div").attr("class", "modal-body");
    var mdFooter = cEl("div").attr("class", "modal-footer").append(cEl("button").attr("type", "button").attr("class", "btn btn-primary").attr("data-dismiss", "modal").listener("click",updateUserDetails).tEl("Save"));

    //----------Elements-----------

    //----------Password-----------
    var pwds = cEl("p").append(cEl("h5").tEl("Change your password")).append(cEl("input").attr("type", "text").attr("class", "form-control").attr("id", "nPwd").attr("placeholder","Change password")).append(cEl("input").attr("type", "text").attr("class", "form-control").attr("id", "nPwdRepeat").attr("placeholder","Repeat new password"));

    //----------Avatars------------
    var avatars = cEl("p").append(cEl("h5").tEl("Choose your avatar"));

    for (var i = 0; i < imgsm.length; i++) {
        var ael = cEl("img").attr("src", "style/images/avatars/" + imgsm[i] + ".png").listener("click", toggleAvatars);
        ael.className = cuser.AvatarId-1 === i ? "avatars" : "desaturate avatars";
        avatars.append(ael);
    }
    mdBody.append(pwds).append(cEl("hr")).append(avatars);

    //----------------------------------

    var mdMain = cEl("div").attr("class", "modal fade").attr("id", "userModal").attr("tabindex", "-1").attr("role", "dialog")
                .append(cEl("div").attr("class", "modal-dialog").attr("role", "document")
                .append(cEl("div").attr("class", "modal-content").append(mdHeader).append(mdBody).append(mdFooter)));

    document.body.append(mdMain);
}

function toggleAvatars(e) {
    var el = e.srcElement;
    var els = document.getElementsByClassName("avatars");

    for (var i = 0; i < els.length; i++) {
        els[i].className = "desaturate avatars";
    }
    el.className = "avatars";
}

function updateUserDetails() {
    //password
    //avatar
    //city//age//??
    
}