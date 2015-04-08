var app = app || {};

app.userSession = (function () {
    function login(data) {
        sessionStorage['currentUser'] = JSON.stringify(data);
    }

    function getCurrentUser() {
        var userData = sessionStorage['currentUser'];
        if (userData) {
            return JSON.parse(sessionStorage['currentUser']);
        }
    }

    function updateCurrentUser(username, fullName) {
        var userData = getCurrentUser();
        if (userData) {
            userData.username = username;
            userData.fullName = fullName;
            sessionStorage['currentUser'] = JSON.stringify(userData);
        }
    }

    function logout() {
        delete sessionStorage['currentUser'];
    }

    return {
        login: login,
        getCurrentUser: getCurrentUser,
        updateCurrentUser: updateCurrentUser,
        logout: logout
    }
})();
