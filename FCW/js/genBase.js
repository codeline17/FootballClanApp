 /*matches
 **predictions
 **clans
 **leagues
 **leadbord
 **livescore
 **account*/

window.onload = function (e) {
    console.log('kalova');
    var menus = $("li[content-type]");
    console.log(menus);
    for (i = 0; i < menus.length; i++) {
        console.log(menus[i]);
        menus[i].addEventListener("click", getContent);
    }
}

 function getContent(e){
     var type = this.getAttribute('content-type');
     console.log(type);
     switch (type) 
     {
         case "matches":
             genMatches();
             break;
         case "predictions":
            genPredictions();
             break;
         case "leagues":
            genLeagues();
             break;
         case "leadbord":
            genLeadBoard();
             break;
         case "livescore":
            genLiveScore();
             break;
         case "account":
            genAccount();
             break;
         default:
             break;
     }
 }

 function genMatches(){
     
 }

 function genPredictions(){
     
 }

 function genLeagues(){
     
 }

 function genLeadBoard(){
     
 }

 function genLiveScore(){
     
 }

 function genAccount(){
     
 }