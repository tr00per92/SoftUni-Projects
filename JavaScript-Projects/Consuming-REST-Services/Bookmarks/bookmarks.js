(function () {
    var HEADERS = {
        'X-Parse-Application-Id': 'CwjA3WLryAQcajt9v0rESl7mZSLB5kMIRYBSEC3A',
        'X-Parse-REST-API-Key': 'oIhDO4ONJFgW2jESSJT1R8TpOGiVkYycrCcUPtep'
    };

    $(function () {
        $('#status-close').click(closeStatus);
        $('form > a').click(toggleRegisterAndLogin);
        $('#register-btn').click(registerUser);
        $('#login-btn').click(login);
        $('#add-btn').click(addBookmark);
    });

    function registerUser() {
        $.ajax({
            method: 'POST',
            headers: HEADERS,
            url: 'https://api.parse.com/1/classes/_User',
            data: JSON.stringify({
                'username': $('#username').val(),
                'password': $('#password').val()
            }),
            contentType: 'application/json',
            success: registrationSuccessful,
            error: registrationError
        });
    }

    function registrationSuccessful() {
        $('#status-message').text('User registered successfully.');
        operationSuccessful();
        $('#username, #password').val('');
        toggleRegisterAndLogin();
    }

    function registrationError() {
        $('#status-message').text('Registration error.');
        operationFailed();
    }

    function login() {
        $.ajax({
            method: 'GET',
            headers: HEADERS,
            url: 'https://api.parse.com/1/login?username=' + $('#username').val() + '&password=' + $('#password').val(),
            success: loginSuccessful,
            error: loginError
        })
    }

    function loginSuccessful(data) {
        HEADERS['X-Parse-Session-Token'] = data.sessionToken;
        $('header > h1')
            .text('Bookmarks - ' + data.username)
            .append($('<a>')
                .attr('href', '#')
                .text('Logout')
                .click(logout));
        $('#status-message').text('Login successful.');
        operationSuccessful();
        loadBookmarks();
    }

    function loginError() {
        $('#status-message').text('Login error. Please try again.');
        operationFailed();
    }

    function logout() {
        HEADERS['X-Parse-Session-Token'] = undefined;
        $('form').show();
        $('#bookmarks-container').hide();
        $('#username, #password').val('');
        $('#status-message').text('Logout successful.');
        operationSuccessful();
    }

    function loadBookmarks() {
        $.ajax({
            method: 'GET',
            headers: HEADERS,
            url: 'https://api.parse.com/1/classes/Bookmark',
            success: bookmarksLoaded,
            error: bookmarksError
        })
    }

    function bookmarksLoaded(data) {
        $('#bookmarks-container').children().not('#add-bookmark').remove();
        data.results.forEach(function(bookmark) {
            $('#bookmarks-container')
                .prepend($('<section>')
                    .text(bookmark.title)
                    .append($('<div>')
                        .addClass('delete-btn')
                        .text('X')
                        .data('bookmark', bookmark)
                        .click(deleteBookmark))
                    .append('<br>')
                    .append($('<a>')
                        .attr('href', bookmark.url)
                        .text(bookmark.url)));
        });
        showBookmarks();
    }

    function bookmarksError() {
        $('#status-message').text('Could not load bookmarks. Please try again.');
        operationFailed();
    }

    function addBookmark() {
        $.ajax({
            method: 'GET',
            headers: HEADERS,
            url: 'https://api.parse.com/1/users/me',
            success: function (user) {
                $.ajax({
                    method: 'POST',
                    headers: HEADERS,
                    url: 'https://api.parse.com/1/classes/Bookmark',
                    data: JSON.stringify({
                        'title': $('#add-title').val(),
                        'url': $('#add-url').val(),
                        'ACL': JSON.parse('{"' + user.objectId + '": { "write": true, "read": true } }')
                    }),
                    contentType: 'application/json',
                    success: bookmarkAdded,
                    error: addFailed
                });
            }, error: addFailed
        });
    }

    function bookmarkAdded() {
        $('#status-message').text('Bookmark added successfully.');
        $('#add-title, #add-url').val('');
        operationSuccessful();
        loadBookmarks();
    }

    function addFailed() {
        $('#status-message').text('Could not add bookmark. Please try again.');
        operationFailed();
    }

    function deleteBookmark() {
        if (confirm('Confirm delete.')) {
            $.ajax({
                method: 'DELETE',
                headers: HEADERS,
                url: 'https://api.parse.com/1/classes/Bookmark/' +  $(this).data('bookmark').objectId,
                success: bookmarkDeleted,
                error: deleteFailed
            });
        }
    }

    function bookmarkDeleted() {
        $('#status-message').text('Bookmark deleted successfully.');
        operationSuccessful();
        loadBookmarks();
    }

    function deleteFailed() {
        $('#status-message').text('Could not delete bookmark. Please try again.');
        operationFailed();
    }

    function operationSuccessful() {
        $('#status-close').css('border-color', '#5C732F').css('color', '#5C732F');
        $('#status-container')
            .css('background', '#88A945')
            .css('border-color', '#5C732F')
            .show(400)
            .delay(5000)
            .hide(400);
    }

    function operationFailed() {
        $('#status-close').css('border-color', '#C0504D').css('color', '#C0504D');
        $('#status-container')
            .css('background', '#EC795A')
            .css('border-color', '#C0504D')
            .show(400);
    }

    function toggleRegisterAndLogin() {
        $('form').children('h1, button, a').toggle();
        $('#username, #password').val('');
    }

    function showBookmarks() {
        $('form').hide();
        $('#bookmarks-container').show();
    }

    function closeStatus() {
        $('#status-container').hide(400);
    }
})();
