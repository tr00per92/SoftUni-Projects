$(function () {
    if (!localStorage['count']) {
        localStorage['count'] = 0;
    }
    if (!sessionStorage['count']) {
        sessionStorage['count'] = 0;
    }
    if (!localStorage['name']) {
        $('#submit-btn').click(function () {
            localStorage['name'] = $('#name').val();
            location.reload();
        });
        return;
    }

    localStorage['count']++;
    sessionStorage['count']++;
    $('#wrapper')
        .empty()
        .append($('<p>').text('Hello ' + localStorage['name'] + '! ')
            .append($('<a>').attr('href', '#').text('[logout]').click(logout)))
        .append($('<p>').text('You have visited this page ' + localStorage['count'] + ' times.'))
        .append($('<p>').text('From which ' + sessionStorage['count'] + ' in this session.'));

    function logout() {
        localStorage.clear();
        sessionStorage.clear();
        location.reload();
    }
});
