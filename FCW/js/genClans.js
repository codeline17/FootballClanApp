﻿function genClans() {
    var mainC = document.getElementById("mainContainer");
    mainC.innerHTML = "";

    $.post("Actions/User.aspx", { type: "GU" },
      function (e) {
          e = JSON.parse(e);
          console.log(e);
          if (e.ClanId === 0) { //NoClan : Show CreateClan or JoinClan
              //CreateClan
              var ccPanel = createPanel("Create you own clan!");
              ccPanel.id = "ccp";
              var ccBody = ccPanel.getElementsByClassName("panel-body")[0];

              var icc = document.createElement("input");
              icc.setAttribute("placeholder", "New Clan Name");
              icc.className = "form-control input-sm";
              icc.id = "icc";
              icc.type = "text";

              var prv = cEl("input").attr("id", "tgPrv").attr("type", "checkbox").attr("data-toggle", "toggle").attr("data-on", "private").attr("data-off", "public");

              var pClan = cEl("p").append(icc).append(prv);

              var btnCreateClan = cEl("p").append(cEl("button").attr("type", "button").attr("class", "btn btn-success").listener("click", CreateClan).tEl("Create!"));

              ccBody.append(pClan);
              ccBody.append(btnCreateClan);

              //Arrow section
              var greenArrow = document.createElement("hr");
              greenArrow.className = "arrow";

              //JoinClan
              var jcPanel = createPanel("Join a clan!");
              jcPanel.id = "jcp";
              var jcBody = jcPanel.getElementsByClassName("panel-body")[0];

              /*var ijc = document.createElement("input");
              ijc.setAttribute("placeholder", "Search Clan");
              ijc.className = "form-control input-sm";
              ijc.type = "text";
              jcBody.appendChild(ijc);*/

              var btnJoinClan = document.createElement("button");
              btnJoinClan.type = "button";
              btnJoinClan.className = "btn btn-success";
              btnJoinClan.innerHTML = "Join Clan!";
              btnJoinClan.addEventListener("click", JoinClan);

              var ddc = GenClanList();
              jcBody.appendChild(ddc);
              jcBody.appendChild(btnJoinClan);

              //Append Everything
              mainC.appendChild(ccPanel);
              mainC.appendChild(greenArrow);
              mainC.appendChild(jcPanel);


              /***After Event Assignments***/
              $("#tgPrv").bootstrapToggle();
              /****************************/

          } else { //InClan : Show ClanDetails
              $.post("Actions/User.aspx", { type: "CDL", id: e.ClanId },
                  function (c) {
                      console.log(c);
                      c = JSON.parse(c);

                      var clanPts = 0;
                      for (var i = 0; i < c.Users.length; i++) {
                          clanPts += c.Users[i].Points;
                      }
                      mainC.append(cEl("h3").tEl(c.Name + "   ").append(cEl("small").tEl("[ " + clanPts + " Pts ]")).append(cEl("small").tEl("  [ " + c.Users.length + " of 11 members ]")));
                      var rFluid = document.createElement("div");
                      rFluid.id = "tblContainer";
                      //rFluid.className = "row-fluid";
                      var opts = "";

                      var exGrid = document.getElementById("match-table");
                      if (exGrid) {
                          exGrid.parentNode.removeChild(exGrid);
                      }

                      // rFluid.innerHTML = tableTxt;

                      rFluid.appendChild(genClanTable(c));
                      mainC.appendChild(rFluid);

                      /***After Event Assignments***/
                      $('[data-toggle="tooltip"]').tooltip();
                      /****************************/
                  });
          }
      });
    //ajax if user is in clan than show clan

    //else show button create clan
}

function CreateClan() {
    //CL
    var name = document.getElementById("icc").value;
    var prv = document.getElementById("tgPrv").checked;
    $.post("Actions/User.aspx", { type: "CL", name : name, private : prv },
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