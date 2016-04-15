$("#toggle-btn").click(function () {
    $("#clanChat").animate({ width: "toggle" });
    $(".send-msg-btn").toggle();
});



function generateClanChat(){
    $.post("Actions/User.aspx", { type: "CHT" },
        function (e) {
            cuser = JSON.parse(e);
            if(cuser.ClanId!=0){
                getClanChat("parse");
            }
            else{
                document.getElementById("toggle-btn").attr("style","display:none");
            }
        });
}


generateClanChat();







var currentChatroomIdcl;

var chatRefreshInterval;

function refreshCurrentClanTab() {
   
    if (currentChatroomIdcl) {

        getClanChat("noparse", currentChatroomIdcl);
    }
}

function getClanChat(parse, chatroomidcl) {
   
    var clanfocus;
    $.post("Actions/User.aspx", { type: "CHT" },
        function (e) {
            cuser = JSON.parse(e);
            if (parse === "parse" || !chatroomidcl) {
                genClanChat();

            } else if (chatroomidcl) {
                for (var i = 0; i < cuser.Chatrooms.length; i++) {
                    if (cuser.Chatrooms[i].Id === chatroomidcl) {
                        try {
                            var clantxtV = document.getElementById("clan-ixinput" + chatroomidcl).value;
                            var clanfocus = document.getElementById("clan-ixinput" + chatroomidcl);
                            document.getElementById("clanchatTab").replaceChild(genClanChatArea(cuser.Chatrooms[i]), document.getElementById("clanchatTab").firstChild);
                            document.getElementById("clan-ixinput" + chatroomidcl).value = clantxtV;
                        } catch (e) {

                            clearInterval(chatRefreshInterval);
                        }
                    }
                }

            }
        });
}

function genClanChat() {
    //TODO : Gjenero Tabet
    var clantabGroup = cEl("div").attr("class", "clan-tabs tabs-top ").attr("data-easytabs", "true");
    var clantabs = cEl("ul").attr("class", "etabs")
        .append(cEl("li").attr("class", "tab active").append(cEl("a").attr("style","text-align:center;").wr({ Tab: "create", ChatroomId: cuser.Chatrooms[1].Id })
            .tEl("Clan")));
    var msgInput = cEl("div").attr("class", "clanSpan").append(cEl("input").attr("type", "text").attr("class", "msg-input").attr("id", "clan-ixinput" + cuser.Chatrooms[1].Id).wr({ roomid: cuser.Chatrooms[1].Id, roomelement: "0x" + name }).listener("keyup", sendClanMessage)).append(cEl('div').attr("class", "send-msg-btn").listener("click", sendClanMessage2).tEl("Send"));

    clantabGroup.append(clantabs).append(msgInput);

    var clantabContainer = cEl("div").attr("id", "clanchatTab").attr("class", "chatcontainer panel-container");

    //TODO : Mbush Tabet
    var clanTab = genClanChatArea(cuser.Chatrooms[1]);

    //Set Refresh Interval
    currentChatroomIdcl = cuser.Chatrooms[1].Id;
    
    chatRefreshInterval = setInterval(refreshCurrentClanTab, 10000);

    clantabContainer.append(clanTab);

    var clanmainC = document.getElementById("clanChat");


    //appends
    clantabGroup.append(clantabContainer);

    clanmainC.appendChild(clantabGroup);


}





function genClanChatArea(room) {

    var clanname = room.Name;
    var clanmessages = room.Messages;
    var clancmsg = cEl("div").attr("id", "1x" + room.Id).attr("class","MessageDiv");
    if(clanmessages.length-1<=200){
        for (var i = clanmessages.length - 1; i >= 0 ; i--) {
            clancmsg.append(genClanMessageArea(clanmessages[i]));
        }
    } else {
        for (var i = clanmessages.length - 1; i >= (clanmessages.length - 200) ; i--) {
            clancmsg.append(genClanMessageArea(clanmessages[i]));
        }
    }
    

    var rr = cEl("div").attr("class", "row-fluid")
        .append(cEl("div").attr("class", "span12").attr("id", "0x" + clanname)
            .append(clancmsg)
        );

    return rr;
}

function genClanMessageArea(m) {
    /*
        <div class="message-item">
            <div class="message-inner">
                <div class="message-head clearfix">
                    <div class="avatar pull-left">
                        <img class="chatimg" alt="img" src="https://ssl.gstatic.com/accounts/ui/avatar_2x.png"/>
                    </div>
                    <div class="user-detail">
                        <h5>Oleg Kolesnichenko</h5>
                        <div class="pull-right">
                            Jan 21
                        </div>
                    </div>
                </div>
                Yo!
            </div>
        </div>
    */
    var outcont = cEl("div").attr("class", "message-item");
    var innercont = cEl("div").attr("class", "message-inner");
    var messhead = cEl("div").attr("class", "message-head clearfix");
   
    var userdetails = cEl("div").attr("class", "user-detail").append(cEl("h5").tEl(m.From)).append(cEl("div").attr("class", "pull-right").tEl(m.TimeStamp));
    messhead.append(userdetails);
    innercont.append(messhead).tEl(m.Message);
    outcont.append(innercont);

    return outcont;
}

function appendClanMessage(e, m) {
    var el = document.getElementById(e);
    if (el) {
        el.append(genClanMessageArea(m));
    }
}

function sendClanMessage(e) {

    if (e.keyCode === 13) {
        
        var chatroomidcl = cuser.Chatrooms[1].Id;
        if (e.target.value.length != 0) {
            $.post("Actions/User.aspx", { type: "SND", chatroomid: chatroomidcl, message: e.target.value },
       function (r) {
           if (r !== 0) {
               getClanChat("noparse", chatroomidcl);
               e.target.value = "";
           }
       });
        }
    }
}

function sendClanMessage2() {

    var chatroomidcl = cuser.Chatrooms[1].Id;
    var mesazhi = document.getElementById("clan-ixinput"+chatroomidcl);
    
    if (mesazhi.value.length != 0) {
        $.post("Actions/User.aspx", { type: "SND", chatroomid: chatroomidcl, message: mesazhi.value },
   function (r) {
       if (r !== 0) {
           getClanChat("noparse", chatroomidcl);
           mesazhi.value = "";
       }
   });
    }

}