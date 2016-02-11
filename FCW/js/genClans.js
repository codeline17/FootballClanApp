function CreateClan() {
    //CL
    console.log("hyra");
    var name = document.getElementById("icc").value;
    $.post("Actions/User.aspx", { type: "CL", name : name },
        function (e) {
            e = JSON.parse(e);
            if (e === 0) {
                //alert alert-error
                //<button type="button" class="close" data-dismiss="alert">×</button>
                var ccp = document.getElementById("ccp");

                var alert = document.createElement("div");
                alert.className = "alert alert-error";
                alert.innerText = "A Clan with this name already exists. Please try another name";

                var dismiss = document.createElement("button");
                dismiss.type = "button";
                dismiss.className = "close";
                dismiss.setAttribute("data-dismiss", "alert");
                dismiss.innerText = "x";

                alert.appendChild(dismiss);
                ccp.appendChild(alert);
            } else {
                genClans();
            }

        });
}

function JoinClan() {
    
}

function GenClanDetails() {
    
}

function GenClanList() {
    var ddc = document.createElement("select");
    ddc.id = "ddc";
    ddc.addEventListener("change", JoinClan);
    $.post("Actions/User.aspx", { type: "GAC"},
        function (e) {
            e = JSON.parse(e);
            console.log(e);
            var clans = [];
            for (var i = 0; i < e.length; i++) {
                var opt = document.createElement("option");
                opt.value = e[i].Name;
                opt.innerText = 

                var cName = document.createElement("h3");
                cName.className = "section-title";
                cName.innerText = e[i].Name;

                var cp = document.createElement("p");
                cp.innerText = "Leader : " + e[i].Leader + " | " + e[i].Count + " Members";

                opt.appendChild(cName);
                opt.appendChild(cp);
                ddc.appendChild(opt);
            }

        });
    return ddc;
}