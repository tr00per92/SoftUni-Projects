app.factory('data', function () {
    function getVideos() {
        if (!localStorage['videoList']) {
            var defaultEntries = [{
                title: 'Course introduction',
                pictureUrl: 'https://lh5.googleusercontent.com/-C9b5lmpsJ0s/AAAAAAAAAAI/AAAAAAAAAC0/CrfdAyUoPhs/photo.jpg',
                length: '03:32',
                category: 'IT',
                subscribers: 3,
                date: new Date(2014, 11, 15),
                haveSubtitles: false
            },{
                title: 'Tiger Forever',
                pictureUrl: 'http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg',
                length: '02:35',
                category: 'Animals',
                subscribers: 13,
                date: new Date(2015, 2, 15),
                haveSubtitles: true
            }];

            localStorage['videoList'] = JSON.stringify(defaultEntries);
        }

        return JSON.parse(localStorage['videoList']);
    }

    function addVideo(video) {
        var videos = getVideos();
        videos.push(video);
        localStorage['videoList'] = JSON.stringify(videos);
    }

    return {
        getVideos: getVideos,
        addVideo: addVideo
    }
});
