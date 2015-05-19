app.controller('AddVideoCtrl', function ($scope, data) {
    $scope.newVideo = {
        haveSubtitles: false,
        date: new Date(),
        subscribers: 0,
        length: new Date(0)
    };

    $scope.addVideo = function () {
        $scope.newVideo.length = lengthToString($scope.newVideo.length);
        data.addVideo($scope.newVideo);
        location.href = '#/';
    };

    function lengthToString(length) {
        var mins = length.getHours();
        if (mins < 10) {
            mins = '0' + mins;
        }
        var secs = length.getMinutes();
        if (secs < 10) {
            secs = '0' + secs;
        }
        return mins + ':' + secs;
    }
});
