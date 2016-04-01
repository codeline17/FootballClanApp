var windowwidth = $(window).width();
var menuopen = 1;
var allowresize = 1;
var dritarja = 0;
$(document).ready(function () {
    window.addEventListener('resize', resize);

    $('.logo img').click(function () {
        if (windowwidth < 1140 && allowresize == 1) {
            animate();
        }
    });

    $('.menu ul li a').click(function () {
        if (windowwidth > 1140) {
            return;
        }
        animate();
    });

});

function animate() {
    if (menuopen == 1) {
        $('.menu').animate({ left: 0 });
        $('.box').fadeOut();
        menuopen = 0;
    } else if (menuopen == 0) {
        menuopen = 1;
        $('.menu').animate({ left: '-100%' });
        $('.box').fadeIn();
    }

}
function resize() {
    windowwidth = $(window).width();
    if (windowwidth < 1140) {
        allowresize = 1;
        if (dritarja == 1 && menuopen == 1) {
            $('.menu').animate({ left: '-100%' },10);
            $('.box').fadeIn();
            menuopen = 1;
        } 

    } else {
        allowresize = 0;
        if (windowwidth > 1140 && menuopen == 1) {

            $('.menu').animate({ left: 0 },10);
            $('.box').fadeIn();
            menuopen = 0;
            dritarja = 1;
        } else if (windowwidth > 1140 && menuopen == 0) {
            $('.box').fadeIn(10);
        }
    }
}
