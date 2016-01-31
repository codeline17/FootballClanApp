document.addEventListener("DOMContentLoaded", function (event) {
    var btn = document.getElementById("btnLogin");
    btn.addEventListener("click", login);

    var pass = document.getElementById("password");
    pass.addEventListener("keyup", keypress);
});

function login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    console.log(username);
    console.log(password);

    $.post("Actions/Login.aspx", { username: username, password: password },
        function (e) {
            var user = JSON.parse(e);
            afterAjax(user);
        });
}

function keypress(e) {
    if (e.keyCode === 13) {
        login();
    }
}

function afterAjax(user) {
    if (!user.Username) {
        var err = document.getElementById("loginErrorMsg");
        err.className = "alert alert-error";
        setTimeout(function () { err.className = "alert alert-error hide"; }, 5000);
    } else {
        document.location = "Default.aspx";
    }
}