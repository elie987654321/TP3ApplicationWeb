$(document).ready(function () {
    $('#carouselExampleIndicators').carousel({
        interval: 4500
    });
});

$(document).ready(function () {
    var small = { width: "60%" };
    var large = { width: "100%" };
    var count = 1;
    $(".fiche").css(small).on('click', function () {
        $(this).animate((count == 1) ? large : small);
        count = 1 - count;
    });
});


$('.ajouteFavori').on('click', function () {

});

$(window).load(function () {
    Response.Cache.SetCacheability(HttpCacheability.NoCache)
});