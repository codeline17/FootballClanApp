var width = $(window).width();
var open = 1;
var allow = 1;
var dritarja = 0;
$(document).ready(function () {
    window.addEventListener('resize', resize);

    $('.logo img').click(function () {
        if (width < 1140 && allow == 1) {
            animate();
        }
    });

    $('.menu ul li a').click(function () {
        if (width > 1140) {
            return;
        }
        animate();
    });

});

function animate() {
    if (open == 1) {
        $('.menu').animate({ left: 0 });
        $('.box').fadeOut();
        open = 0;
    } else if (open == 0) {
        open = 1;
        $('.menu').animate({ left: '-100%' });
        $('.box').fadeIn();
    }

}
function resize() {
    width = $(window).width();
    if (width < 1140) {
        allow = 1;
        if (dritarja == 1) {
            $('.menu').animate({ left: '-100%' },10);
            $('.box').fadeIn();
            open = 1;
        } else if (open == 0 && dritarja == 0) {
            $('.menu').animate({ left: '-100%' });
            $('.box').fadeIn();

            open = 1;
        }

    } else {
        allow = 0;
        if (width > 1140 && open == 1) {

            $('.menu').animate({ left: 0 },10);
            $('.box').fadeIn();
            open = 0;
            dritarja = 1;
        } else if (width > 1140 && open == 0) {
            $('.box').fadeIn(10);
        }
    }
}
