app.controller('ListVideosCtrl', function ($scope, data) {
    $scope.videos = data.getVideos();
    $scope.orderByProp = 'title';
});
