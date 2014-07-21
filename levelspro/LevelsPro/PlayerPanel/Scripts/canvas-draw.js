// JavaScript Document







$(document).ready(function () {



    $(window).resize(function () {
        var canvaswidth = $('.map').width();
        $("#myCanvas").width(canvaswidth);

        var rcolumn = $('.lof').height();
        $(".awpoints").height(rcolumn - 22);

        var secrh = $('.sec-right').height();
        $(".pd-desc").height(secrh - 38);

        var mpclm = $('.pd-mp').height();
        $(".pd-left-dt").height(mpclm - 32);


    });

    




    var mpclmm = $('.pd-mp').height();
    $(".pd-left-dt").height(mpclmm - 187);
    //alert(mpclmm);

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


    $("#myCanvas").attr("height", cheight);

    var rcolumn = $('.lof').height();
    $(".awpoints").height(rcolumn - 22);

    var secrh = $('.sec-right').height();
    $(".pd-desc").height(secrh - 38);


    var cirhalf = $('.orange-cir').outerWidth();
    var cirhalf = cirhalf / 2;

    var count = $('.map').children('div.mcr').length;

    var childs = $('.map').children('div.mcr');

    for (var i = 0; i < count; i++) {
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







});
