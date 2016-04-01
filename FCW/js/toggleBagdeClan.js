var imgsclan = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34","35", "36", "37", "38", "39", "40", "41"];

function toggleClanBadges(e) {
    var el = e.target;
    var els = document.getElementsByClassName("avatars");

    for (var i = 0; i < els.length; i++) {
        els[i].className = "desaturate avatars";
    }
    el.className = "avatars";
    cAv = el.wrapper.id;
    
}
function updateClanBadge() {
    
    $.post("Actions/User.aspx", { type: "GU" },
      function (e) {
          var c = JSON.parse(e);
          var clanid = c.ClanId;
          var imageid = cAv;
          
          
          $.post("Actions/User.aspx", { type: "UCI", clanid: clanid,image:imageid},
          function (e) {
              genClans();
              $("#userModal").modal("hide");
              $("#userModal").remove();
          
          });
      });
    
}
    

function genEditBadgeTab() {
    cAv = cuser.AvatarId;


    var mdBody = cEl("div").attr("class", "modal-body");


    //----------Clan Badges------------
    var cbadges = cEl("p").append(cEl("h5").tEl("Choose Your Clan Badge"));

    for (var i = 0; i < imgsclan.length; i++) {
        var ael = cEl("img").wr({ id: imgsclan[i] }).attr("src", "style/images/clans/" + imgsclan[i] + ".png").attr("id","clanbadges").listener("click", toggleClanBadges);
        ael.className = cuser.AvatarId - 1 === i ? "avatars" : "desaturate avatars";
        cbadges.append(ael);
    }
    mdBody.append(cEl("hr")).append(cbadges);
    mdBody.append(
                    cEl("a").attr("class", "btn btn-primary").listener("click", updateClanBadge).tEl("Save")
                );
           

    //var mdFooter = cEl("div").attr("class", "modal-footer").attr("id", "mdFooter").append(cEl("button").attr("type", "button").attr("class", "btn btn-primary").listener("click", updateUserDetails).tEl("Save"));

    //----------------------------------

    return mdBody;
}

function genClanBadges() {
    var exMd = document.getElementById("userModal");
    if (exMd) {
        exMd.parentNode.removeChild(exMd);
    }
    

    var mdHeader = cEl("div").attr("class", "modal-header").append(cEl("button").attr("type", "button").attr("class", "close").attr("data-dismiss", "modal").attr("aria-label", "Close")
                .append(cEl("span").attr("aria-hidden", "true").tEl("x"))).append(cEl("h4").tEl("Change Clan Badge"));

    var mdFooter = cEl("div").attr("class", "modal-footer").attr("id", "mdFooter").append(cEl("button").attr("type", "button").attr("class", "btn btn-primary").listener("click", updateClanBadge).tEl("Save"));

    var mdMain = cEl("div").attr("class", "modal fade").attr("id", "userModal").attr("tabindex", "-1").attr("role", "dialog")
            .append(cEl("div").attr("class", "modal-content").append(mdHeader)
        .append(
            genEditBadgeTab()
            )
        );
   
    document.body.append(mdMain);
    $("#userModal").modal("show");
}
