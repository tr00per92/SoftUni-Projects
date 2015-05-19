var app = angular.module('videoSystem', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/add', {
                templateUrl: 'views/add-video.html',
                controller: 'AddVideoCtrl'
            })
            .when('/', {
                templateUrl: 'views/list-videos.html',
                controller: 'ListVideosCtrl'
            })
            .otherwise({ redirectTo: '/' });
    });
