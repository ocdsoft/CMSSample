declare var FB: any;
declare var ko: any;

class Post {
    description: string
    imageSrc: string
    title: string
    link: string
}

class NewsFeed {
    post: Array<Post>
};

function queryNewsFeed(numPosts: number): any {
    let vm: NewsFeed = new NewsFeed();
    vm.post = new Array<Post>();

    const pageID = '650789144956092';
    const pageAccessToken = 'EAATLnx5HvHQBALyhwOEdgjbQhjo76kcJtJwJ0dPhlqzlQZCs3nRwgMrHfpX3ndrJKjbPRs4LGnpMV7UpDCbEYKolplIvLcpJRaAYTbglEf9ooUqUqlLixT0acb5GxYAZBl7b3hhyx2F7dB7g1Hxolt1IMqyHgZD';
    const pageEndpoint = `/${pageID}/posts?limit=${numPosts}&access_token=${pageAccessToken}`;

    FB.api(pageEndpoint, (page: any) => {
        if (page && !page.error) {
            let processed = 0;

            page.data.forEach((post: any) => {
                let postEndpoint = `/${post.id}/?fields=description,picture,story,link&access_token=${pageAccessToken}`;
                FB.api(postEndpoint, (postItem: any) => {
                    if (postItem && !postItem.error) {
                        let post: Post = {
                            description: postItem.description,
                            imageSrc: postItem.picture,
                            title: postItem.story,
                            link: postItem.link
                        }

                        vm.post.push(post);
                        processed++;

                        if (processed === page.data.length)
                            ko.applyBindings(vm);
                    }
                });
            });
        }
    });
};