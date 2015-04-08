var app = app || {};

app.ajaxRequester = (function () {
    var baseUrl = 'https://api.parse.com/1/',
        headers = {
        'X-Parse-Application-Id': 'GgR0jhqhySNaX7SvRE80IGZfhxFVvUv1G2KYsVnu',
        'X-Parse-REST-API-Key': 'VbocorPBC2TtZ8aanTjLDGiO8PihwfkvOWM5meJ2'
    };

    function getHeadersWithSessionToken(sessionToken) {
        var headersWithToken = JSON.parse(JSON.stringify(headers));
        headersWithToken['X-Parse-Session-Token'] = sessionToken;
        return headersWithToken;
    }

    function login(username, password, success, error) {
        $.ajax({
            method: 'GET',
            headers: headers,
            url: baseUrl + 'login',
            data: {
                username: username,
                password: password
            },
            success: success,
            error: error
        });
    }

    function register(username, password, fullName, success, error) {
        var user = {
            username: username,
            password: password,
            fullName: fullName
        };
        $.ajax({
            method: 'POST',
            headers: headers,
            url: baseUrl + 'users',
            data: JSON.stringify(user),
            success: success,
            error: error
        });
    }

    function editUser(sessionToken, userId, username, password, fullName, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken),
            user = {
            username: username,
            password: password,
            fullName: fullName
        };
        $.ajax({
            method: 'PUT',
            headers: headersWithToken,
            url: baseUrl + 'users/' + userId,
            data: JSON.stringify(user),
            success: success,
            error: error
        });
    }

    function getPhones(sessionToken, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        $.ajax({
            method: 'GET',
            headers: headersWithToken,
            url: baseUrl + 'classes/Phone',
            success: success,
            error: error
        });
    }

    function addPhone(person, number, userId, success, error) {
        var phone = {
            person: person,
            number: number,
            ACL : {}
        };
        phone.ACL[userId] = {'write': true, 'read': true};
        $.ajax({
            method: 'POST',
            headers: headers,
            url: baseUrl + 'classes/Phone',
            data: JSON.stringify(phone),
            success: success,
            error: error
        });
    }

    function deletePhone(sessionToken, phoneId, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        $.ajax({
            method: 'DELETE',
            headers: headersWithToken,
            url: baseUrl + 'classes/Phone/' + phoneId,
            success: success,
            error: error
        });
    }

    function editPhone(sessionToken, phoneId, person, number, success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken),
            phone = {
            person: person,
            number: number
        };
        $.ajax({
            method: 'PUT',
            headers: headersWithToken,
            url: baseUrl + 'classes/Phone/' + phoneId,
            data: JSON.stringify(phone),
            success: success,
            error: error
        });
    }

    return {
        login: login,
        register: register,
        editUser: editUser,
        getPhones: getPhones,
        addPhone: addPhone,
        deletePhone: deletePhone,
        editPhone: editPhone
    };
})();
