/*
function expandMatch(e) {
    var el = e.target.parentElement;
    if (document.getElementById("exp") && el.className.indexOf("exp") > -1) {
        el.className = el.className.trim().replace("exp", "");
        e.target.parentElement.parentElement.removeChild(document.getElementById("exp"));
    } else {
        if (document.getElementById("exp")) {
            e.target.parentElement.parentElement.removeChild(document.getElementById("exp"));
            var exps = document.getElementsByClassName("exp");
            for (var i = 0; i < exps.length; i++) {
                exps[i].className = exps[i].className.trim().replace("exp", "");
            }
        }
        var sealed = e.target.parentElement.wrapper.Sealed;
        el.className += " exp";
        var panel = createMatchPanel(e.target.parentElement.wrapper).attr("class", "mDetails");
        panel.className += sealed ? " mSealed" : "";

        var expand = cEl("tr").attr("id", "exp").append(cEl("td").attr("colspan", 6).append(panel));

        if (el.nextSibling) {
            el.parentNode.insertBefore(expand, el.nextSibling);
        } else {
            el.parentNode.appendChild(expand);
        }
    }
}

*/


function expandMyDetails(e) {
    var el = e.target.parentElement;
    //alert(el.rowIndex);
}
function testisfirstlogin() {
    $.post("Actions/User.aspx", { type: "RFR" },
     function (e) {
         var e = JSON.parse(e);
         var isfirstlogin = e.IsFirstLogin;
         if (isfirstlogin) {
             tutorial();
             
         } else {
             return;
         }
     });  
}

function tutorial() {
    var slider = ["1", "2","3","4","5","6","7","8"];
    

    var modalHeader = cEl("div").attr("class", "modal-header").attr("id","tutorial-header").append(cEl("h4").tEl("Welcome to Football Clans"));
   
    var modalBody = cEl("div").attr("class", "modal-body").attr("id", "tutorial-body");

    var sliderdiv = cEl("div").attr("class", "slider");

    var row1 = cEl("div").attr("class", "slide active-slide").attr("id", "test")
                .append(cEl("div").attr("class", "images"))
                    .append(cEl("img").attr("src", "style/images/tutorial/" + slider[0] + ".png").attr("width", "99%"));
    sliderdiv.append(row1);
    for (var i = 1; i < slider.length; i++) {

    var row = cEl("div").attr("class", "slide")
                .append(cEl("div").attr("class", "images"))
                    .append(cEl("img").attr("src", "style/images/tutorial/" + slider[i] + ".png").attr("width", "99%"));
    sliderdiv.append(row);
    }


    var modalFooter = cEl("div").attr("class", "button-div").append(cEl("a").attr("href", "#").attr("class", "skip-btn").attr("data-dismiss", "modal").attr("aria-label", "Close").tEl("Skip"))
        .append(cEl("a").attr("href", "#").attr("class", "next-btn").tEl("Next"));

    var modalProgress = cEl("div").attr("class", "footer-tutorial")
    var progressOl = cEl("ol").attr("class", "progress-tutorial progress--large");



    var liElement1 = cEl("li").attr("class", "is-active").attr("data-step", "1").append(cEl("p").tEl(""));
    

    var liElement2 = cEl("li").attr("data-step","2" ).append(cEl("p").attr("class", "hidden").tEl(""));
    var liElement3 = cEl("li").attr("data-step","3" ).append(cEl("p").attr("class", "hidden").tEl(""));
    var liElement4 = cEl("li").attr("data-step","4" ).append(cEl("p").attr("class", "hidden").tEl(""));
    var liElement5 = cEl("li").attr("data-step","5" ).append(cEl("p").attr("class", "hidden").tEl(""));
    var liElement6 = cEl("li").attr("data-step","6" ).append(cEl("p").attr("class", "hidden").tEl(""));
    var liElement7 = cEl("li").attr("data-step","progress-last" ).append(cEl("p").attr("class", "hidden").tEl(""));
    
    progressOl.append(liElement1).append(liElement2).append(liElement3).append(liElement4).append(liElement5).append(liElement6).append(liElement7);
    modalProgress.append(progressOl);
    modalBody.append(sliderdiv);
    var modalMain = cEl("div").attr("class", "modal fade").attr("id", "memberModal").attr("tabindex", "-1").attr("role", "dialog")
        .append(cEl("div").attr("class", "modal-dialog").attr("role", "document")
            .append(cEl("div").attr("class", "modal-content").append(modalHeader).append(modalBody).append(modalFooter).append(modalProgress)));
    
    document.body.append(modalMain);
    $("#memberModal").modal("show");
    var i = 0;
     // click event for next button
    $('.next-btn').click(function () {
        i++;
        var currentSlide = $('.active-slide');
        var nextSlide = currentSlide.next();
        var currentP = $('.is-active p');
        var currentProgress = $('.is-active');
        var nextProgress = currentProgress.next();
        var nextP = nextProgress.children();

        if ($(".next-btn").text() === "Finish") {
            $("#memberModal").modal("hide");
        }
        if (i == 7) {
            $(".next-btn").text("Finish");
            $(".skip-btn").hide();
        }


        $(currentSlide).fadeOut(600);
        $(currentSlide).removeClass('active-slide');


        $(currentProgress).removeClass('is-active');
        //$(currentProgress).removeClass('progtrckr-todo');
        $(currentProgress).addClass('is-complete');
        $(currentP).addClass("hidden");
        $(nextP).removeClass("hidden");



        $(nextSlide).fadeIn(600);
        $(nextSlide).addClass('active-slide');

        $(nextProgress).addClass('is-active');

    });
}
