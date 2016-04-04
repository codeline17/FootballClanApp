/*
function expandMatch(e) {
    var el = e.target.parentElement;
    if (document.getElementById("exp") && el.className.indexOf("exp") > -1) {
        el.className = el.className.trim().replace("exp", "");
        e.target.parentElement.parentElement.removeChild(document.getElementById("exp"));
    } else {
        if (document.getElementById("exp")) {
            e.target.parentElement.parentElement.removeChild(document.getElementById("exp"));
            var exps = document.getElementsByClassName("exp");
            for (var i = 0; i < exps.length; i++) {
                exps[i].className = exps[i].className.trim().replace("exp", "");
            }
        }
        var sealed = e.target.parentElement.wrapper.Sealed;
        el.className += " exp";
        var panel = createMatchPanel(e.target.parentElement.wrapper).attr("class", "mDetails");
        panel.className += sealed ? " mSealed" : "";

        var expand = cEl("tr").attr("id", "exp").append(cEl("td").attr("colspan", 6).append(panel));

        if (el.nextSibling) {
            el.parentNode.insertBefore(expand, el.nextSibling);
        } else {
            el.parentNode.appendChild(expand);
        }
    }
}

*/

function expandMyDetails(e) {
    var el = e.target.parentElement;
    //alert(el.rowIndex);
}
function testisfirstlogin() {
    $.post("Actions/User.aspx", { type: "RFR" },
     function (e) {
         var e = JSON.parse(e);
         var isfirstlogin = e.IsFirstLogin;
         if (isfirstlogin) {
             //alert();













































         } else {
             //alert("false");

             return;
         }






     });
    
}