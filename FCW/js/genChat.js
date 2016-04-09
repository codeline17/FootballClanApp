var currentChatroomId;

var chatRefreshInterval;

function refreshCurrentTab() {
    console.log(currentChatroomId);
    if (currentChatroomId) {
        console.log("refresh chat");
        getChat("noparse", currentChatroomId);
    }
}

function getChat(parse, chatroomid) {
    console.log(cuser.ChatroomId);
    var focus;
    $.post("Actions/User.aspx", { type: "CHT" },
        function (e) {
            cuser = JSON.parse(e);
            if (parse === "parse" || !chatroomid ) {
                genChat();
                scrolltoend();
            } else if (chatroomid){
                for (var i = 0; i < cuser.Chatrooms.length; i++) {
                    if (cuser.Chatrooms[i].Id === chatroomid) {
                        try {
                            var txtV = document.getElementById("ixinput" + chatroomid).value;
                            var focus = document.getElementById("ixinput" + chatroomid).focus;
                            document.getElementById("chatTab").replaceChild(genChatArea(cuser.Chatrooms[i]), document.getElementById("chatTab").firstChild);
                            document.getElementById("ixinput" + chatroomid).value = txtV;
                        } catch (e) {
                            console.log(e);
                            clearInterval(chatRefreshInterval);
                        } 
                    }
                }
                if (focus) {
                    document.getElementById("ixinput" + chatroomid).focus();
                    scrolltoend();
                }
            }
        });
}

function genChat() {
    //TODO : Gjenero Tabet
    var tabGroup = cEl("div").attr("class", "tabs tabs-top left tab-container").attr("data-easytabs", "true");
    var tabs = cEl("ul").attr("class", "etabs")
        .append(cEl("li").attr("class", "tab active").append(cEl("a").listener("click", switchChatTab).wr({ Tab: "create", ChatroomId: cuser.Chatrooms[0].Id })
            .tEl("Global")));
    if (cuser.Chatrooms.length === 2) 
            tabs.append(cEl("li").attr("class", "tab").append(cEl("a").listener("click", switchChatTab).wr({ Tab: "join", ChatroomId: cuser.Chatrooms[1].Id })
                  .attr("class", "active").tEl("Clan")));

    tabGroup.append(tabs);

    var tabContainer = cEl("div").attr("id", "chatTab").attr("class", "chatcontainer panel-container");

    //TODO : Mbush Tabet
    var globalTab = genChatArea(cuser.Chatrooms[0]);

    //Set Refresh Interval
    currentChatroomId = cuser.Chatrooms[0].Id;
    console.log(currentChatroomId);
    chatRefreshInterval = setInterval(refreshCurrentTab, 10000);

    tabContainer.append(globalTab);

    var mainC = document.getElementById("mainContainer");


    //appends
    tabGroup.append(tabContainer);
    mainC.appendChild(tabGroup).appendChild(cEl("a").attr("href","#").attr("id","scroll-to-top-msg").tEl("Scroll to top"));

    scrolltoend();
}

function scrolltoend() {
    var objDiv = document.getElementsByClassName("chatcontainer")[0];
    objDiv.scrollTop = objDiv.scrollHeight;
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
    var cmsg = cEl("div").attr("id","1x"+room.Id);

    for (var i = 0; i < messages.length; i++) {
        cmsg.append(genMessageArea(messages[i]));
    }

    var r = cEl("div").attr("class", "row-fluid")
        .append(cEl("div").attr("class", "span12").attr("id", "0x" + name)
            .append(cmsg)
        ).append(cEl("div").attr("class", "span10 offset1").append(cEl("input").attr("type", "text").attr("id","ixinput" + room.Id).wr({ roomid: room.Id, roomelement: "0x" + name }).listener("keyup", sendMessage)));

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
    var avatar = cEl("div").attr("class", "avatar pull-left").append(cEl("img").attr("class", "chatimg").attr("src", "https://ssl.gstatic.com/accounts/ui/avatar_2x.png"));
    var userdetails = cEl("div").attr("class", "user-detail").append(cEl("h5").tEl(m.From)).append(cEl("div").attr("class", "pull-right").tEl(m.TimeStamp));
    messhead.append(avatar).append(userdetails);
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
        console.log(e.target.wrapper);
        var chatroomid = e.target.wrapper.roomid;
        $.post("Actions/User.aspx", { type: "SND", chatroomid:chatroomid, message:e.target.value },
        function (r) {
            if (r !== 0) {
                getChat("noparse", chatroomid);
                e.target.value = "";
            }
        });
    }
}
