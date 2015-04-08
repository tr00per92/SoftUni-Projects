(function() {
    $(function() {
        registerEventHandlers();
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            showUserHomeView();
        } else {
            showWelcomeView();
        }
    });

    function registerEventHandlers() {
        $('#show-login-btn, #show-login-link').click(showLoginView);
        $('#show-register-btn, #show-register-link').click(showRegisterView);
        $('#show-home-link, #cancel-edit-btn').click(showUserHomeView);
        $('#show-phonebook-link, .cancel-button').click(showPhoneListView);
        $('#add-phone-link').click(showAddPhoneView);
        $('#edit-profile-link').click(showEditProfileView);

        $('#login-btn').click(loginClicked);
        $('#register-btn').click(registerClicked);
        $('#logout-btn').click(logoutClicked);
        $('#add-phone-btn').click(addPhoneClicked);
        $('#edit-user-btn').click(editUserClicked);
    }

    function showWelcomeView() {
        setHeader('Welcome');
        $('#main-content').children().hide();
        $('#welcome-screen').show();
    }

    function showLoginView() {
        setHeader('Login');
        $('#main-content').children().hide();
        $('#login-form').show();
        $('#login-username, #login-password').val('');
    }

    function showRegisterView() {
        setHeader('Registration');
        $('#main-content').children().hide();
        $('#register-form').show();
        $('#reg-username, #reg-password, #reg-fullName').val('');
    }

    function showUserHomeView() {
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            setHeader('Home');
            $('#main-content').children().hide();
            $('#menu, #home-screen').show();
            $('#reg-username, #reg-password, #reg-fullName').val('');
            $('#home-screen').children('h1').text('Welcome, ' + currentUser.fullName + ' (' + currentUser.username + ')');
        } else {
            showWelcomeView();
        }
    }

    function showPhoneListView() {
        var currentUser = app.userSession.getCurrentUser(),
            sessionToken = currentUser.sessionToken;

        if (currentUser) {
            setHeader('List');
            app.ajaxRequester.getPhones(sessionToken, phonesLoaded, loadPhonesError);
        } else {
            showWelcomeView();
        }

        function phonesLoaded(data) {
            $('#phones').find('tr').not('#phones-header').remove();

            data.results.forEach(function (phone) {
                $('#phones-header')
                    .parent()
                    .append($('<tr>')
                        .data('phone', phone)
                        .append($('<td>').text(phone.person))
                        .append($('<td>').text(phone.number))
                        .append($('<td>')
                            .append($('<a>')
                                .attr('href', '#')
                                .addClass('link')
                                .click(showEditPhoneView)
                                .text('Edit '))
                            .append($('<a>')
                                .attr('href', '#')
                                .addClass('link')
                                .click(showDeletePhoneView)
                                .text(' Delete'))));
            });

            $('#main-content').children().hide();
            $('#menu, #phones').show();
        }

        function loadPhonesError() {
            showErrorMessage('Phones cannot be loaded!');
        }
    }

    function showAddPhoneView() {
        var currentUser = app.userSession.getCurrentUser();
        if (currentUser) {
            setHeader('Add Phone');
            $('#main-content').children().hide();
            $('#add-personName, #add-phoneNumber').val('');
            $('#menu, #add-phone-form').show();
        } else {
            showWelcomeView();
        }
    }

    function showEditPhoneView() {
        var phone = $(this).closest('tr').data('phone'),
            currentUser = app.userSession.getCurrentUser(),
            sessionToken = currentUser.sessionToken;

        if (currentUser) {
            setHeader('Edit Phone');
            $('#edit-personName').val(phone.person);
            $('#edit-phoneNumber').val(phone.number);
            $('#edit-phone-btn').unbind('click').click(editConfirmed);
            $('#main-content').children().hide();
            $('#menu, #edit-phone-form').show();
        } else {
            showWelcomeView();
        }

        function editConfirmed() {
            var name = $('#edit-personName').val(),
                number = $('#edit-phoneNumber').val();
            app.ajaxRequester.editPhone(sessionToken, phone.objectId, name, number, editSuccessful, editError);
        }

        function editSuccessful() {
            showPhoneListView();
            showSuccessMessage('Phone edited successfully!');
        }

        function editError() {
            showErrorMessage('Edit failed!');
        }
    }

    function showDeletePhoneView() {
        var phone = $(this).closest('tr').data('phone'),
            currentUser = app.userSession.getCurrentUser(),
            sessionToken = currentUser.sessionToken;

        if (currentUser) {
            setHeader('Delete Phone');
            $('#delete-personName').val(phone.person);
            $('#delete-phoneNumber').val(phone.number);
            $('#delete-phone-btn').unbind('click').click(deleteConfirmed);
            $('#main-content').children().hide();
            $('#menu, #delete-phone-form').show();
        } else {
            showWelcomeView();
        }

        function deleteConfirmed() {
            app.ajaxRequester.deletePhone(sessionToken, phone.objectId, deleteSuccessful, deleteError)
        }

        function deleteSuccessful() {
            showPhoneListView();
            showSuccessMessage('Delete successful!');
        }

        function deleteError() {
            showErrorMessage('Delete failed!');
        }
    }

    function showEditProfileView() {
        var currentUser = app.userSession.getCurrentUser();

        if (currentUser) {
            setHeader('Edit Profile');
            $('#edit-username').val(currentUser.username);
            $('#edit-password').val('');
            $('#edit-fullName').val(currentUser.fullName);
            $('#main-content').children().hide();
            $('#menu, #edit-profile-form').show();
        } else {
            showWelcomeView();
        }
    }

    function loginClicked() {
        var username = $('#login-username').val(),
            password = $('#login-password').val();

        app.ajaxRequester.login(username, password, loginSuccessful, loginError);

        function loginSuccessful(data) {
            app.userSession.login(data);
            showUserHomeView();
            showSuccessMessage('Login successful!')
        }

        function loginError() {
            showErrorMessage('Login failed!');
        }
    }

    function logoutClicked() {
        app.userSession.logout();
        showLoginView();
        showSuccessMessage('Logout Successful!');
    }

    function registerClicked() {
        var username = $('#reg-username').val(),
            password = $('#reg-password').val(),
            fullName = $('#reg-fullName').val();

        app.ajaxRequester.register(username, password, fullName, registerSuccessful, registerError);

        function registerSuccessful(data) {
            data.username = username;
            data.fullName = fullName;
            app.userSession.login(data);
            showUserHomeView();
            showSuccessMessage('Registration successful!')
        }

        function registerError() {
            showErrorMessage('Register failed');
        }
    }

    function editUserClicked() {
        var currentUser = app.userSession.getCurrentUser(),
            username = $('#edit-username').val(),
            password = $('#edit-password').val(),
            fullName = $('#edit-fullName').val();
        app.ajaxRequester.editUser(currentUser.sessionToken, currentUser.objectId,
                username, password, fullName, editUserSuccessful, editUserError);

        function editUserSuccessful() {
            app.userSession.updateCurrentUser(username, fullName);
            showUserHomeView();
            showSuccessMessage('User profile edited successfully!');
        }

        function editUserError() {
            showErrorMessage('User profile edit failed!');
        }
    }

    function addPhoneClicked() {
        var name = $('#add-personName').val(),
            number = $('#add-phoneNumber').val(),
            currentUser = app.userSession.getCurrentUser();

        app.ajaxRequester.addPhone(name, number, currentUser.objectId, addPhoneSuccess, addPhoneError);

        function addPhoneSuccess() {
            showSuccessMessage('Phone added successfully!');
            showPhoneListView()
        }

        function addPhoneError() {
            showErrorMessage('Phone adding failed!');
        }
    }

    function setHeader(text) {
        $('header').children('span').text(' - ' + text);
    }

    function showSuccessMessage(msg) {
        noty({
            text: msg,
            type: 'success',
            layout: 'topCenter',
            timeout: 2000,
            killer: true
        });
    }

    function showErrorMessage(msg) {
        noty({
            text: msg,
            type: 'error',
            layout: 'topCenter',
            timeout: 5000,
            killer: true
        });
    }
})();
