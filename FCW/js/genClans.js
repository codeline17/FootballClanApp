var joinTab;
var createTab;
var joinTabEvent = false;
var contextClan;
var clanBadges = new Array();
var clanBadgesUrl = "style/images/clans/";
var clanBadgesExt = ".png";
for (var i = 1; i < 42; i++) {
    clanBadges.push(i.toString());
}

function genClans() {
    var mainC = document.getElementById("mainContainer");
    mainC.innerHTML = "";

    $.post("Actions/User.aspx", { type: "GU" },
      function (e) {
          e = JSON.parse(e);
          if (e.ClanId === 0) { //NoClan : Show CreateClan or JoinClan
              //preps
              var tabGroup = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true");
              var tabs = cEl("ul").attr("class", "etabs")
                  .append(cEl("li").attr("class", "tab active").append(cEl("a").listener("click", switchCTab).wr({Tab: "create"})
                        .tEl("Create Clan")))
                  .append(cEl("li").attr("class", "tab").append(cEl("a").listener("click", switchCTab).wr({Tab: "join"})
                        .attr("class", "active").tEl("Join Clan")));

              tabGroup.append(tabs);

              var tabContainer = cEl("div").attr("id","tcTab").attr("class", "panel-container");

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

              //JoinClan
              var jcPanel = createPanel("Join a clan!");
              jcPanel.id = "jcp";
              var jcBody = jcPanel.getElementsByClassName("panel-body")[0];

              var ddc = genClanListTable();
              jcBody.appendChild(ddc);

              //affects
              createTab = cEl("div").attr("class", "tab-block").attr("id", "tbJoin").attr("style", "display: block;").append(ccPanel);
              joinTab = cEl("div").attr("class", "tab-block active").attr("id", "tbCreate").attr("style", "display: block;").append(jcPanel);
              tabContainer.append(createTab);

              //appends
              tabGroup.append(tabContainer);
              mainC.appendChild(tabGroup);

              /***After Event Assignments***/
              $("#tgPrv").bootstrapToggle();
              /****************************/

          } else if (e.ClanId === -1) {
              mainC.append(cEl("div").attr("class","alert").tEl("You are waiting to be approved to join a clan."));
          } else { //InClan : Show ClanDetails
              $.post("Actions/User.aspx", { type: "CDL", id: e.ClanId },
                  function(c) {
                      c = JSON.parse(c);
                      contextClan = c;
                      //mainC.append(cEl("h3").tEl(c.Name + "   ").append(cEl("span").attr("class","cups").tEl("0").append(cEl("i").attr("class", "icon-trophy gold"))).append(cEl("small").tEl("[ " + clanPts + " Pts ]")).append(cEl("small").tEl("  [ " + c.Users.length + " of 11 members ]")));

                      //mainC.append(cEl("p").append(cEl("a").attr("href","#").attr("cel-uname", cuser.Username).attr("cel-cname", c.Name).tEl("Leave Clan").listener("click", removeMember)));
                      mainC.append(genClanHeader(c));
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
                      rFluid.appendChild(genLeaveClanBtn());
                      mainC.appendChild(rFluid);

                      /***After Event Assignments***/
                      $('[data-toggle="tooltip"]').tooltip();
                      /****************************/
                  });
          }
      });
}

function switchCTab(e) {
    var w = e.target.wrapper.Tab;
    console.log(w);
    $("li.tab").each(function() {
        this.className = this.className.replace(" active", "");
    });
    e.target.parentElement.className += " active";

    var mainCnt = document.getElementById("tcTab");
    mainCnt.innerHTML = "";

    switch (w) {
        case "join":
            mainCnt.append(joinTab);
            if (!joinTabEvent) {
                $('body').off('click', '.pagination li');
                $("#cltable").bdt({
                    pageRowCount: 25
                });
                joinTabEvent = true;
            }
            break;
        case "create":
            mainCnt.append(createTab);
            $("#tgPrv").bootstrapToggle();
            break;
    }
}

function genLeaveClanBtn() {
    return cEl("div").attr("class", "row-fluid").append(cEl("div").attr("class", "span4 offset8").append(cEl("a").attr("class", "btn btn-orange pull-right").listener("click", removeMember).tEl("Leave Clan")));
}

function genClanHeader(c) {
    var clanPts = 0;
    for (var i = 0; i < c.Users.length; i++) {
        clanPts += c.Users[i].Points;
    }
    var m = cEl("table").attr("class","clans")
        .append(
            cEl("tr")
            .append(
                cEl("td").attr("rowspan", "2")
        //.listener("click", editClanBadge)
                .append(cEl("img").attr("class", "img-responsive").attr("width", "50px").attr("src", clanBadgesUrl + c.Image + clanBadgesExt))
            )
            .append(
                cEl("td")
                .append(
                    cEl("h4").attr("class","text-center").tEl(c.Name)
                )
            )
            .append(
                cEl("td")
                .append(
                    cEl("h4").attr("class","text-center").append(cEl("span").attr("class", "cups").tEl("0").append(cEl("i").attr("class", "icon-trophy gold"))
                    )
                )
            )
            .append(
                cEl("td")
                .append(
                    cEl("h4").attr("class","text-center").tEl("Rank: " + c.Rank)
                )
            )
        )
        .append(
            cEl("tr")
            .append(
                cEl("td")
                .append(
                    cEl("h4").attr("class","text-center").tEl(clanPts + " pts")
                )
            )
            .append(
                cEl("td")
                .append(
                    cEl("h4").attr("class","text-center").tEl("Lvl: 1")
                )
             )
            .append(
                cEl("td")
                .append(
                    cEl("h4").attr("class","text-center").tEl("Avg: " + (clanPts / c.Users.length).toFixed(2))
                )
             )
        );

    return cEl("div").attr("class","row-fluid").append(m);
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
                genHeader();
            } else {
                genHeader();
                genClans();
            }
        });
}

function JoinClan(e) {
    var name = e.target.parentElement.wrapper.Name;

    if (!name)
        return;

    $.post("Actions/User.aspx", { type: "JC", name: name },
        function (e) {
            e = JSON.parse(e);
            if (e === 0) {
                //alert alert-error
                //<button type="button" class="close" data-dismiss="alert">×</button>
                var jcp = document.getElementById("jcp");
                jcp.appendChild(errorBox("Could not join this clan, please try again later."));
                genHeader();
            } else {
                genHeader();
                genClans();
            }
        });
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

function genClanListTable() {
    //main
    var clt = cEl("table").attr("id","cltable").attr("class", "table table-hover");

    //header
    var cltHeader = cEl("thead");
    var thead = [{ Title: "Rank", Text: "Rank" },{ Title: "Name", Text: "Name" }, { Title: "Leader", Text: "Leader" }, 
        { Title: "Members", Text: "#" }, { Title: "Points", Text: "Pts" }];
    for (var j = 0; j < thead.length; j++) {
        cltHeader.append(cEl("th").tEl(thead[j].Text));
    }

    //body
    var cltbody = cEl("tbody");

    $.post("Actions/User.aspx", { type: "GACBU" },
        function (e) {
            e = JSON.parse(e);
            for (var i = 0; i < e.length; i++) {
                var r = cEl("tr").wr({ Name: e[i].Name }).listener("click", JoinClan)
                    .append(cEl("td").tEl(e[i].Rank))
                    .append(cEl("td").tEl(e[i].Name))
                    .append(cEl("td").tEl(e[i].Leader))
                    .append(cEl("td").tEl(e[i].UserCount))
                    .append(cEl("td").tEl(e[i].Points))
                ;
                cltbody.append(r);
            }
            clt.append(cltHeader).append(cltbody);
        });

    return clt;
}

function approveMember(e) {
    var uname = e.target.getAttribute("cel-uname");
    var cname = e.target.getAttribute("cel-cname");
    $.post("Actions/User.aspx", { type: "AUC", name: uname, clanName: cname },
        function(c) {
            console.log(c);
            if (c === "1") {
                getHeaderInfo();
                genClans();
            }
        });
}

function removeMember(e) {
    var uname = e.target.getAttribute("cel-uname");
    $.post("Actions/User.aspx", { type: "RMUC", name: uname, clanName: cuser.NameOfClan },
        function (c) {
            console.log(c);
            if (c === "1") {
                getHeaderInfo();
                genClans();
            }
        });
}

function editClanBadge() {
    var exMd = document.getElementById("clanDetailsModal");
    if (exMd) {
        exMd.parentNode.removeChild(exMd);
    }

    var mdHeader = cEl("div").attr("class", "modal-header").append(cEl("button").attr("type", "button").attr("class", "close").attr("data-dismiss", "modal").attr("aria-label", "Close")
        .append(cEl("span").attr("aria-hidden", "true").tEl("x"))).append(cEl("h4").tEl("Clan Details"));

    var mdBody = cEl("div").attr("class", "modal-body");
    var badges = cEl("div").attr("class", "row-fluid");

    for (var i = 0; i < clanBadges.length; i++) {
        var cel = cEl("img").wr({ id: clanBadges[i] }).attr("src", clanBadgesUrl + clanBadges[i] + clanBadgesExt);//.listener("click", toggleAvatars);
        cel.className = contextClan.Image - 1 === i ? "avatars" : "desaturate avatars";
        badges.append(cel);
    }

    mdBody.append(badges);


    var mdFooter = cEl("div").attr("class", "modal-footer").attr("id", "mdFooter").append(cEl("button").attr("type", "button").attr("class", "btn btn-primary").tEl("Update"));//.listener("click", updateUserDetails));
    
    var mdMain = cEl("div").attr("class", "modal fade").attr("id", "userModal").attr("tabindex", "-1").attr("role", "dialog")
        .append(cEl("div").attr("class", "modal-dialog").attr("role", "document")
            .append(cEl("div").attr("class", "modal-content").append(mdHeader).append(mdBody).append(mdFooter)));

    document.body.append(mdMain);

    $("#clanDetailsModal").modal("show");

}