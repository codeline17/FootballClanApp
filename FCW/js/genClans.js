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
                ccp.appendChild(errorBox("A Clan with this name already exists. Please try another name."));
            } else {
                genClans();
            }

        });
}

function JoinClan() {
    console.log("aa");
    var name = document.getElementById("ddc");
    name = name.options[name.selectedIndex].value;

    $.post("Actions/User.aspx", { type: "JC", name: name },
        function (e) {
            e = JSON.parse(e);
            if (e === 0) {
                //alert alert-error
                //<button type="button" class="close" data-dismiss="alert">×</button>
                var jcp = document.getElementById("jcp");
                jcp.appendChild(errorBox("Could not join this clan, please try later."));
            } else {
                genClans();
            }
        });
}

function GenClanDetails() {
    
}

function GenClanList() {
    var ddc = document.createElement("select");
    ddc.id = "ddc";
    ddc.className = "input-large";
    //ddc.addEventListener("change", JoinClan);
    $.post("Actions/User.aspx", { type: "GAC"},
        function (e) {
            e = JSON.parse(e);
            console.log(e);
            var clans = [];
            for (var i = 0; i < e.length; i++) {
                var opt = document.createElement("option");
                opt.value = e[i].Name;
                opt.innerText = e[i].Name + " | Leader : " + e[i].Leader + " | " + e[i].UserCount + " members";
                
                ddc.appendChild(opt);
            }
            $("#ddc").select2();
        });
    return ddc;
}