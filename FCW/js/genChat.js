var currentChatroomId;

var chatRefreshInterval;

function refreshCurrentTab() {
   
    if (currentChatroomId) {
    
        getChat("noparse", currentChatroomId);
    }
}

function getChat(parse, chatroomid) {
   
    var focus;
    $.post("Actions/User.aspx", { type: "CHT" },
        function (e) {
            cuser = JSON.parse(e);
            if (parse === "parse" || !chatroomid) {
                genChat();
               
            } else if (chatroomid) {
                for (var i = 0; i < cuser.Chatrooms.length; i++) {
                    if (cuser.Chatrooms[i].Id === chatroomid) {
                        try {
                            var txtV = document.getElementById("global-ixinput" + chatroomid).value;
                            var focus = document.getElementById("global-ixinput" + chatroomid);
                            document.getElementById("chatTab").replaceChild(genChatArea(cuser.Chatrooms[i]), document.getElementById("chatTab").firstChild);
                            document.getElementById("global-ixinput" + chatroomid).value = txtV;
                        } catch (e) {
                            
                            clearInterval(chatRefreshInterval);
                        }
                    }
                }
                
            }
        });
}

function genChat() {
    //TODO : Gjenero Tabet
    var tabGroup = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true");
    var tabs = cEl("ul").attr("class", "etabs")
        .append(cEl("li").attr("class", "tab active").append(cEl("a").attr("style","text-align:center;").listener("click", switchChatTab).wr({ Tab: "create", ChatroomId: cuser.Chatrooms[0].Id })
            .tEl("Global")));
    
   
    var globalInput = cEl("div").attr("class", "clanSpan").append(cEl("input").attr("type", "text").attr("class", "global-msg-input").attr("id", "global-ixinput" + cuser.Chatrooms[0].Id).wr({ roomid: cuser.Chatrooms[0].Id, roomelement: "0x" + name }).listener("keyup", sendMessage)).append(cEl('div').attr("class", "send-global-msg-btn").listener("click", sendMessage2).tEl("Send"));
    tabGroup.append(tabs).append(globalInput);

    var tabContainer = cEl("div").attr("id", "chatTab").attr("class", "chatcontainer panel-container");

    //TODO : Mbush Tabet
    var globalTab = genChatArea(cuser.Chatrooms[0]);

    //Set Refresh Interval
    currentChatroomId = cuser.Chatrooms[0].Id;
   
    chatRefreshInterval = setInterval(refreshCurrentTab, 10000);

    tabContainer.append(globalTab);

    var mainC = document.getElementById("mainContainer");


    //appends
    tabGroup.append(tabContainer);
    mainC.appendChild(tabGroup).appendChild(cEl("a").attr("href", "#").attr("id", "scroll-to-top-msg").tEl("Scroll to top"));

    
}



function switchChatTab(e) {
    var w = e.target.wrapper.Tab;
    var chatroomid = e.target.wrapper.ChatroomId;
    $("li.tab").each(function () {
        this.className = this.className.replace(" active", "");
    });
    e.target.parentElement.className += " active";

    getChat("noparse", chatroomid);
}

function genChatArea(room) {

    var name = room.Name;
    var messages = room.Messages;
    var cmsg = cEl("div").attr("id", "1x" + room.Id).attr("class","global-messages");

    for (var i = 0 ; i <messages.length; i++) {

        cmsg.append(genMessageArea(messages[i]));
    }

    var r = cEl("div").attr("class", "row-fluid")
        .append(cEl("div").attr("class", "span12").attr("id", "0x" + name)
            .append(cmsg)
        );

    return r;
}

function genMessageArea(m) {
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

function appendMessage(e, m) {
    var el = document.getElementById(e);
    if (el) {
        el.append(genMessageArea(m));
    }
}

function sendMessage(e) {
    if (e.keyCode === 13) {
        
        var chatroomid = cuser.Chatrooms[0].Id;
        $.post("Actions/User.aspx", { type: "SND", chatroomid: chatroomid, message: e.target.value },
        function (r) {

            if (r != 0) {
                getChat("noparse", chatroomid);
                e.target.value = "";
            }
        });
    }
}
function sendMessage2() {
    var chatroomid = cuser.Chatrooms[0].Id;
    var mesazhi = document.getElementById("global-ixinput" + 3);
  
    if (mesazhi.value.length != 0) {
        
        $.post("Actions/User.aspx", { type: "SND", chatroomid: chatroomid, message: mesazhi.value },
   function (r) {

       if (r != 0) {
   
           getChat("noparse", chatroomid);
           mesazhi.value = "";
       }
   });
    }

}