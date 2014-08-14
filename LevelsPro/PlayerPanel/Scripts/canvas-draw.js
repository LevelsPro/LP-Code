// JavaScript Document







$(document).ready(function () {



    $(window).resize(function () {

//        var canvas = document.getElementById('myCanvas');
//        var context = canvas.getContext('2d');
//        context.clearRect(0, 0, canvas.width, canvas.height);
        $("#myCanvas").width(0);
        var canvaswidth = $('.map').width();
        $("#myCanvas").width(canvaswidth);

        setTimeout(function () {
            var canvaswidth = $('.map').width();
            $("#myCanvas").width(canvaswidth);
        }, 20);



        if (window.console) console.log(canvaswidth);

        var rcolumn = $('.lof').height();
        $(".awpoints").height(rcolumn - 22);

        var secrh = $('.sec-right').height();
        $(".pd-desc").height(secrh - 38);

        



    });






    

    var canvaswidth = $('.my-map').width();
    //alert(canvaswidth);
    $("#myCanvas").attr("width", canvaswidth);


    var mapbg = $('.my-map').attr("src");
    //  alert(mapbg);
    $("#myCanvas").css('background-image', 'url("' + mapbg + '")');

    var cheight = $('.my-map').show().height();
    $('.my-map').hide();

    var b2 = $('.b2').height();
    $(".b1").height(b2);

    var kheight = Math.round((canvaswidth / 216) * 85);

    $("#myCanvas").attr("height", kheight);

    var mpclmm = $('.pd-mp').height();
    $(".pd-left-dt").height(mpclmm - 187);
    //alert(mpclmm);

    var rcolumn = $('.lof').height();
    $(".awpoints").height(rcolumn - 22);

    var secrh = $('.sec-right').height();
    $(".pd-desc").height(secrh - 38);


    var cirhalf = $('.orange-cir').outerWidth();
    var cirhalf = cirhalf / 2;

    var count = $('.map').children('div.mcr').length;

    var childs = $('.map').children('div.mcr');


    var pos = $('.pic-holder').prev().position();
    $('.pic-holder').css({ 'top': pos.top - 88, 'left': pos.left - 19 });

    var stripw = $('.profile-cont').width();
    $('.block1').width(stripw - 92);

    $(window).resize(function () {

        var mcr = $('.pic-holder').prev().position();


        $('.pic-holder').css({ 'top': mcr.top - 88, 'left': mcr.left - 19 });
        //$('.pic-holder').css({ 'top': top, 'left': left });
        //alert("pos");

        var stripw = $('.profile-cont').width();
        $('.block1').width(stripw - 92);


    });



    $(window).resize(function () {





        // drawStuff();
       

//        for (var i = 0; i < count - 1; i++) {

//            var ele1 = childs[i];
//            var ele2 = childs[i + 1];



//            var left = $(ele1).position().left + cirhalf;
//           // var left = Math.round((left * 2) - (left/2)+3);
//            var top = $(ele1).position().top + cirhalf;
//           // var top = Math.round((top * 2) - (top/ 2)+3);

//            var left2 = $(ele2).position().left;
//            var left2 = left2 + cirhalf;
//           // var left2 = Math.round((left2 * 2) - (left2/ 2)+3);

//            var top2 = $(ele2).position().top;
//            var top2 = top2 + cirhalf;
//          //  var top2 = Math.round((top2 * 2) - (top2 / 2));
//            //alert(left + ' left ' + top + ' top ' + top2);

//            //salert(' St x ' + left + ' St y ' + top +  ' En x2 ' + left2 + ' En y2 ' + top2);

//            var canvas = document.getElementById('myCanvas');
//            var tline = canvas.getContext('2d');
//            tline.beginPath();
//            tline.lineWidth = 15;
//            if ($(ele2).hasClass('orange-cir')) {
//                tline.strokeStyle = '#ffff29';
//            }

//            else {
//                tline.strokeStyle = '#b2be76';
//            }

//            tline.moveTo(left2, top2);
//            tline.lineTo(left, top);
//            tline.stroke();


//        }


        var mpclm = $('.pd-mp').height();
        $(".pd-left-dt").height(mpclm - 32);
    });

    drawStuff();
    


    function drawStuff() {

        //tline.clearRect(0, 0, 0, 0);

        for (var i = 0; i < count - 1; i++) {

            var ele1 = childs[i];
            var ele2 = childs[i + 1];



            var left = $(ele1).position().left + cirhalf;
            var left = left;
            var top = $(ele1).position().top + cirhalf;
            var top = top;

            var left2 = $(ele2).position().left;
            var left2 = left2 + cirhalf;
            var top2 = $(ele2).position().top;
            var top2 = top2 + cirhalf;

            //alert(left + ' left ' + top + ' top ' + top2);

            //salert(' St x ' + left + ' St y ' + top +  ' En x2 ' + left2 + ' En y2 ' + top2);

            var canvas = document.getElementById('myCanvas');
            var tline = canvas.getContext('2d');
            tline.beginPath();
            tline.lineWidth = 15;
            if ($(ele2).hasClass('orange-cir')) {
                tline.strokeStyle = '#ffff29';
            }

            else {
                tline.strokeStyle = '#b2be76';
            }

            tline.moveTo(left2, top2);
            tline.lineTo(left, top);
            tline.stroke();


        }

    }







});





(function () {
    var 
    // Obtain a reference to the canvas element
    // using its id.
                htmlCanvas = document.getElementById('myCanvas'),

    // Obtain a graphics context on the
    // canvas element for drawing.
                  context = htmlCanvas.getContext('2d');

    // Start listening to resize events and
    // draw canvas.
    initialize();

    function initialize() {
        // Register an event listener to
        // call the resizeCanvas() function each time 
        // the window is resized.
        window.addEventListener('resize', resizeCanvas, false);

        // Draw canvas border for the first time.
        resizeCanvas();
    }

    // Display custom canvas.
    // In this case it's a blue, 5 pixel border that 
    // resizes along with the browser window.                    
    function redraw() {
        context.strokeStyle = 'blue';
        context.lineWidth = '5';
        context.strokeRect(0, 0, window.innerWidth, window.innerHeight);
    }

    // Runs each time the DOM window resize event fires.
    // Resets the canvas dimensions to match window,
    // then draws the new borders accordingly.
    function resizeCanvas() {
        htmlCanvas.width = window.innerWidth;
        htmlCanvas.height = window.innerHeight;
        redraw();
    }

})();