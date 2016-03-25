document.addEventListener("DOMContentLoaded", function (event) {
    var btnLogin = document.getElementById("btnLogin");
    btnLogin.addEventListener("click", login);

    var pass = document.getElementById("password");
    pass.addEventListener("keyup", keypress);

    var btnGotoRegister = document.getElementById("btnGotoRegister");
    btnGotoRegister.addEventListener("click", gotoRegister);

    var btnGotoLogin = document.getElementById("btnGotoLogin");
    btnGotoLogin.addEventListener("click", gotoLogin);

    var btnReg = document.getElementById("btnRegister");
    btnReg.addEventListener("click", register);

    CookieCheck();
});

function gotoRegister() {
    var regForm = document.getElementById("frmRegister");
    regForm.className = regForm.className.replace(" hidden", "");

    var signInForm = document.getElementById("frmLogin");
    signInForm.className += " hidden";
}

function gotoLogin() {
    var regForm = document.getElementById("frmLogin");
    regForm.className = regForm.className.replace(" hidden", "");

    var signInForm = document.getElementById("frmRegister");
    signInForm.className += " hidden";
}

function register() {
    var username = document.getElementById("regUsername");
    var password = document.getElementById("regPassword");
    var email = document.getElementById("regEmail");
    
    //incomplete info
    if (!mainRegChecks()) {
        return;
    }

    $.post("Actions/Register.aspx", { username: username.value, password: password.value, email:email.value},
     function (e) {
         var r = JSON.parse(e);
         switch (r) {
             case -1:
                 showErrorAfterId("regForm", "This username is taken, try another one!");
                 break;
             case -2:
                 showErrorAfterId("regForm", "This e-mail is already associated with a user!");
                 break;
             default:
                 showSuccessAfterId("regForm", "You have successfully created a user. Please log-in.");
                 resetRegisterForm();
                 break;
         }
     });
}

function login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    $.post("Actions/Login.aspx", { type: "Login", username: username, password: password },
        function (e) {
            var user = JSON.parse(e);
            afterAjax(user);
        });
}

function CookieCheck() {
    var guid = localStorage["rInfo"];
    if (!guid)
        return;

    $.post("Actions/Login.aspx", { type: "CookieCheck", userguid: guid },
        function (e) {
            var user = JSON.parse(e);
            if (user.Username) {
                document.location = "Default.aspx";
            }
        });
}

function keypress(e) {
    if (e.keyCode === 13) {
        login();
    }
}

function afterAjax(user) {
    if (!user.Username) {
        showErrorAfterId("loginError", "Username or password incorrect.");
        //setTimeout(function () { err.className = "alert alert-error orangered hide"; }, 5000);
    } else {
        localStorage["rInfo"] = user.Guid;
       document.location = "Default.aspx";
    }
}

function showErrorAfterId(id, msg) {
    var alert = document.createElement("div");
    alert.className = "alert alert-error";
    alert.innerText = msg;

    var dismiss = document.createElement("button");
    dismiss.type = "button";
    dismiss.className = "close";
    dismiss.setAttribute("data-dismiss", "alert");
    dismiss.innerText = "x";

    alert.appendChild(dismiss);

    var appendTo = document.getElementById(id);
    appendTo.appendChild(alert);
}

function showSuccessAfterId(id, msg) {
    var alert = document.createElement("div");
    alert.className = "alert alert-success";
    alert.innerText = msg;

    var dismiss = document.createElement("button");
    dismiss.type = "button";
    dismiss.className = "close";
    dismiss.setAttribute("data-dismiss", "alert");
    dismiss.innerText = "x";

    alert.appendChild(dismiss);

    var appendTo = document.getElementById(id);
    appendTo.appendChild(alert);
}

function mainRegChecks() {
    var username = document.getElementById("regUsername");
    var password = document.getElementById("regPassword");
    var confirmpassword = document.getElementById("regConfirmPassword");
    var email = document.getElementById("regEmail");

    if (!username.value) {
        showErrorAfterId("regForm", "Please fill the username field!");
        return false;
    }
    if (!password.value) {
        showErrorAfterId("regForm", "Please fill the password field!");
        return false;
    }
    if (!confirmpassword.value) {
        showErrorAfterId("regForm", "Please fill the confirm password field!");
        return false;
    }
    if (!email.value) {
        showErrorAfterId("regForm", "Please fill the e-mail field!");
        return false;
    }
    if (!validateEmail(email.value)) {
        showErrorAfterId("regForm", "The e-mail format is not correct!");
        return false;
    }
    //password do not match
    if (password.value !== confirmpassword.value) {
        showErrorAfterId("regForm", "Passwords do not match!");
        return false;
    }
    if (!document.getElementById("termsAndConditions").checked) {
        showErrorAfterId("regForm", "Accept terms and conditions before continuing!");
        return false;
    }

    return true;
}

function validateEmail(email) {
    var atpos = email.indexOf("@");
    var dotpos = email.lastIndexOf(".");
    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= email.length) {
        return false;
    } else {
        return true;
    }
}

function resetRegisterForm() {
    var username = document.getElementById("regUsername");
    var password = document.getElementById("regPassword");
    var confirmpassword = document.getElementById("regConfirmPassword");
    var email = document.getElementById("regEmail");

    username.value = "";
    password.value = "";
    confirmpassword.value = "";
    email.value = "";
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}