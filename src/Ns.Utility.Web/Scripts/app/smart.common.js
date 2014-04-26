var actualViewPort = 350;

$(document).ready(function () {

    var viewportHeight = $(window).height();
    var headerHeight = $(".navbar-fixed-top").height();
    var footerHeight = $(".footer-bar").height();
    viewPort = viewportHeight - headerHeight - footerHeight - 120;
    actualViewPort = actualViewPort > viewPort ? actualViewPort : viewPort;
});