(function() {
    $(function() {
        $('#paint-btn').click(paint);
    });

    function paint() {
        var classSelector = '.' + $('#className').val();
        var color = $('#color').val();
        $(classSelector).css('background', color);
    }
})();
