var app = app || {};

app.ajaxRequester = (function () {
    var makeRequest = function(method, url, data, success) {
        $.ajax({
            headers: {
                'X-Parse-Application-Id': 'klqKfKJ6LmWFtxonJ5tpQfW86vja0LqgwVSdVgEf',
                'X-Parse-REST-API-Key': 'NrYZtCS9TMvDCD5UyecBsX7Uw8Ynl1JUlL0KP84P'
            },
            url: url,
            type: method,
            contentType: 'application/json',
            data: JSON.stringify(data) || undefined,
            success: success,
            error: ajaxError
        });
    };

    function ajaxError(error) {
        console.log(error);
    }

    var makeGetRequest = function(url, success) {
        return makeRequest('GET', url, null, success);
    };

    var makePostRequest = function(url, data, success) {
        return makeRequest('POST', url, data, success);
    };

    var makePutRequest = function(url, data, success) {
        return makeRequest('PUT', url, data, success);
    };

    var makeDeleteRequest = function(url, success) {
        return makeRequest('DELETE', url, null, success);
    };

    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest
    }
}());
