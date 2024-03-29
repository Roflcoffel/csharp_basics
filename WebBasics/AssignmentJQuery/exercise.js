﻿/// <reference path="C:\Users\Deltagare\Documents\GitRepos\csharp_basics\WebBasics\AssignmentJQuery\scripts/jquery-3.2.1.min.js" />

//Exercise 1 - Change Listener
$(document).ready(function () {
    //Exercise 1 - Change Listener
    $("#inputListener").on("input", function () {
        $("#clText").html("<p>" + $(this).val() + "</p>")
    });

    //Exercise 2 - Show / Hide
    $("#hideImg").click(function () {
        $(this).hide();
    })

    $("#showImg").click(function () {
        $("#hideImg").show();
    })

    $("#toggle").click(function () {
        $("#hideImg").toggle();
    })

    //Exercise 3 - Change Style
    $("#addStyle").click(function() {
        $("#changeStyle").addClass("redText");
    })

    $("#remStyle").click(function () {
        $("#changeStyle").removeClass("redText");
    })

    $("#toggleStyle").click(function () {
        $("#changeStyle").toggleClass("redText");
    })

    //Exercise 4 - Key Press Listener
    $(document).keyup(function (e) {
        $("#keyLogText").html("Last Pressed: " + e.key);
    })

    $(document).keydown(function (e) {
        $("#keyLogText").html("Currently Down: " + e.key);
    })

    //Exercise 5 - Focus Events
    $("form input").focus(function () {
        $(this).addClass("highlight");
    })

    $("form input").blur(function () {
        $(this).removeClass("highlight");
    })

    $("form a").focus(function () {
        $(this).addClass("highlight");
    })

    $("form a").blur(function () {
        $(this).removeClass("highlight");
    })

    //Exercise 6 - Fading
    $("#fadeMe").mouseover(function () {
        $(this).fadeOut(2000);
        $(this).fadeIn(2000);
    })

    //Exercise 7 - Animation Fading
    $("div.box").mouseover(function () {
        $(this).animate({opacity: '1'})
    })

    $("div.box").mouseout(function () {
        $(this).animate({opacity: '0.5'})
    })

    //Exercise 8 - Animation Movement (feels unresponsive / a little laggy)
    var animating = false;

    $(window).on("mouseover", function (e) {

        if (animating) {
            return;
        }

        mPosition = e.clientX;

        if (mPosition <= 150) {

            animating = true;
            $("#sidenav").stop().animate(
                { width: "150px" },
                200, function () {
                    animating = false;
                }
            );
        }
        else {
            animating = true;
            $("#sidenav").stop().animate(
                { width: "0px" },
                200, function () {
                    animating = false;
                }
            );
            
        }
    })
});

