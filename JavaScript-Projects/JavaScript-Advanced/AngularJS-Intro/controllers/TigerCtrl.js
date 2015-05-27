app.controller('TigerCtrl', function ($scope) {
    $scope.tiger = {
        "Name": "Pesho",
        "Photo": "http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg",
        "Born": "Asia",
        "BirthDate": 2006,
        "Live": "Sofia Zoo"
    };

    $scope.commonStyle = {
        'background-color': '#CACACA',
        'color': '#2C3E50',
        'width': '50%',
        'padding': '40px'
    };

    $scope.imgStyle = {
        'display': 'inline-block',
        'max-width': '35%',
        'margin-left': '120px'
    };

    $scope.infoStyle = {
        'display': 'inline-block',
        'vertical-align': 'top'
    }
});
