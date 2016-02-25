var imgsm = ["1", "2", "3", "4", "5", "6", "7", "8"];
var cAv;
function genUserDetails() {
    cAv = cuser.AvatarId;
    var exMd = document.getElementById("userModal");
    if (exMd) {
        exMd.parentNode.removeChild(exMd);
    }

    var mdHeader = cEl("div").attr("class", "modal-header").append(cEl("button").attr("type", "button").attr("class", "close").attr("data-dismiss", "modal").attr("aria-label", "Close")
                    .append(cEl("span").attr("aria-hidden", "true").tEl("x"))).append(cEl("h4").tEl("User Details"));
    var mdBody = cEl("div").attr("class", "modal-body");
    var mdFooter = cEl("div").attr("class", "modal-footer").attr("id","mdFooter").append(cEl("button").attr("type", "button").attr("class", "btn btn-primary").listener("click",updateUserDetails).tEl("Save"));

    //----------Elements-----------

    //----------Password-----------
    var pwds = cEl("p").append(cEl("h5").tEl("Change your password")).append(cEl("input").attr("type", "password").attr("class", "form-control").attr("id", "nPwd").attr("placeholder", "Change password")).append(cEl("input").attr("type", "password").attr("class", "form-control").attr("id", "nPwdRepeat").attr("placeholder", "Repeat new password"));

    //----------Avatars------------
    var avatars = cEl("p").append(cEl("h5").tEl("Choose your avatar"));

    for (var i = 0; i < imgsm.length; i++) {
        var ael = cEl("img").wr({id: imgsm[i]}).attr("src", "style/images/avatars/" + imgsm[i] + ".png").listener("click", toggleAvatars);
        ael.className = cuser.AvatarId-1 === i ? "avatars" : "desaturate avatars";
        avatars.append(ael);
    }
    mdBody.append(pwds).append(cEl("hr")).append(avatars);

    //----------------------------------

    var mdMain = cEl("div").attr("class", "modal fade").attr("id", "userModal").attr("tabindex", "-1").attr("role", "dialog")
                .append(cEl("div").attr("class", "modal-dialog").attr("role", "document")
                .append(cEl("div").attr("class", "modal-content").append(mdHeader).append(mdBody).append(mdFooter)));

    document.body.append(mdMain);
    $("#userModal").modal("show");
}

function toggleAvatars(e) {
    var el = e.srcElement;
    var els = document.getElementsByClassName("avatars");

    for (var i = 0; i < els.length; i++) {
        els[i].className = "desaturate avatars";
    }
    el.className = "avatars";
   cAv = el.wrapper.id;
}

function updateUserDetails() {
    var pwd = document.getElementById("nPwd");
    var pwdr = document.getElementById("nPwdRepeat");
    var avid = cAv;
    var q = true;
    //Checks //errorBox("Could not join this clan, please try again later.")
    if (pwd.value !== pwdr.value) {
        document.getElementById("mdFooter").appendFirst(errorBox("Passwords do not match."));
    } else if (pwd.value.length < 8) {
        document.getElementById("mdFooter").appendFirst(errorBox("Password should be at least 8 characters long."));
    } else {
        $.post("Actions/User.aspx", { type: "UUD", pwd: pwd.value, pwdr: pwdr.value, avid: avid },
        function (c) {
            console.log(c);
            if (c === "1") {
                getHeaderInfo();
                $("#userModal").modal("hide");
                $("#userModal").remove();
            }
            else {
                document.getElementById("mdFooter").appendFirst(errorBox("Error during processing."));
            }
        });
    }
}