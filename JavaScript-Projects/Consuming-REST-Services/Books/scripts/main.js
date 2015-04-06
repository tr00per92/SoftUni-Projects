(function () {
    var serviceRootUrl = 'https://api.parse.com/1/classes/',
        persister = app.data.get(serviceRootUrl),
        controller = app.controller.get(persister);

    controller.load('#books');
}());
