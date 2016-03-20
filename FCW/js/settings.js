var site = "play";

if (document.location.href.indexOf("game") > -1) {
    site = "game";
}

var cuser = "";
var state = true;
var mObjs = new Array();
var username = "";
var mode = "";
var matches = "";
var unlocks = "";
var leagueBadges = [{ type: "msl" }, { type: "scc" }, { type: "wsl" }, { type: "ycc" }, { type: "ysl" }];