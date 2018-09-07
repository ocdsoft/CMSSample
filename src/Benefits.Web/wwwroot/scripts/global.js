// Call Facebook news feed API *if* script is loaded & page includes method.
$(window).on('load', function () {
    if (typeof queryNewsFeed !== 'undefined') {
        queryNewsFeed(5);
    }
});