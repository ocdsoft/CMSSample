var Post = /** @class */ (function () {
    function Post() {
    }
    return Post;
}());
var NewsFeed = /** @class */ (function () {
    function NewsFeed() {
    }
    return NewsFeed;
}());
;
function queryNewsFeed(numPosts) {
    var vm = new NewsFeed();
    vm.post = new Array();
    var pageID = '650789144956092';
    var pageAccessToken = 'EAATLnx5HvHQBALyhwOEdgjbQhjo76kcJtJwJ0dPhlqzlQZCs3nRwgMrHfpX3ndrJKjbPRs4LGnpMV7UpDCbEYKolplIvLcpJRaAYTbglEf9ooUqUqlLixT0acb5GxYAZBl7b3hhyx2F7dB7g1Hxolt1IMqyHgZD';
    var pageEndpoint = "/" + pageID + "/posts?limit=" + numPosts + "&access_token=" + pageAccessToken;
    FB.api(pageEndpoint, function (page) {
        if (page && !page.error) {
            var processed_1 = 0;
            page.data.forEach(function (post) {
                var postEndpoint = "/" + post.id + "/?fields=description,picture,story,link&access_token=" + pageAccessToken;
                FB.api(postEndpoint, function (postItem) {
                    if (postItem && !postItem.error) {
                        var post_1 = {
                            description: postItem.description,
                            imageSrc: postItem.picture,
                            title: postItem.story,
                            link: postItem.link
                        };
                        vm.post.push(post_1);
                        processed_1++;
                        if (processed_1 === page.data.length)
                            ko.applyBindings(vm);
                    }
                });
            });
        }
    });
}
;
//# sourceMappingURL=facebookApi.js.map