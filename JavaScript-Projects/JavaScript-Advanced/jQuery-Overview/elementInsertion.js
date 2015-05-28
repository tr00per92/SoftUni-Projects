(function() {
    $(function() {
        $('#before-btn').click(function () {
            var before = $('#before');
            $('<p>' + before.val() + '</p>').prependTo('#myDiv');
            before.val('');
        });

        $("#after-btn").click(function () {
            var after = $('#after');
            $('<p>' + after.val() + '</p>').appendTo('#myDiv');
            after.val('');
        });
    });
})();
