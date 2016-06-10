function tutorial() {
    var videos = ["1", "2", "3", "4", "5"];
    var content = cEl("div").attr("id", "videoContainer").attr("class","row");
    var video0 = cEl("div").attr("class", "description").tEl("How to play #1");
    var video1 = cEl("div").attr("class", "description").tEl("How To Predict");
    var video2 = cEl("div").attr("class", "description").tEl("How To Unlock");
    var video3 = cEl("div").attr("class", "description").tEl("How To Join Another Clan");
    var video4 = cEl("div").attr("class", "description").tEl("How To Use Clan & Global Chat");
    for (var i = 0; i < videos.length; i++) {
        var row = cEl("div").attr("class", "span5").attr("style","display:inline-block");
        var video = cEl("video").attr("width","100%").attr("height","100%").attr("controls");
        video.append(cEl("source").attr("src", "../style/videos/" + videos[i] + ".webm").attr("type", "video/mp4"))
        .append(cEl("source").attr("src", "../style/videos/" + videos[i] + ".mp4").attr("type", "video/mp4"));
        row.append(video);

        if (i == 0) {
            row.append(video0);
        }else if(i == 1){
            row.append(video1);
        }else if(i == 2){
            row.append(video2);
        } else if (i == 3) {
            row.append(video3);
        }else {
            row.append(video4);
       }
        content.append(row);
        

    }
    var mainC = document.getElementById("mainContainer");
    mainC.append(content);
}