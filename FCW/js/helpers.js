function errorBox(text) {
    var alert = document.createElement("div");
    alert.className = "alert alert-error";
    alert.innerText = text;

    var dismiss = document.createElement("button");
    dismiss.type = "button";
    dismiss.className = "close";
    dismiss.setAttribute("data-dismiss", "alert");
    dismiss.innerText = "x";

    alert.appendChild(dismiss);

    return alert;
}