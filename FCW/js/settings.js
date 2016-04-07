var site = "play";

if (document.location.href.indexOf("game") > -1) {
    site = "game";
}
if (document.location.href.indexOf("game") > -1) {
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
      (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
      m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

    ga('create', 'UA-73117693-2', 'auto');
    ga('send', 'pageview');

    
}
else {
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
      (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
      m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

    ga('create', 'UA-73117693-3', 'auto');
    ga('send', 'pageview');

}

var cuser = "";
var state = true;
var mObjs = new Array();
var username = "";
var mode = "";
var matches = "";
var unlocks = "";
var leagueBadges = [{ type: "msl" }, { type: "scc" }, { type: "wsl" }, { type: "ycc" }, { type: "ysl" }];