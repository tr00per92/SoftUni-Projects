$(function() {
    $('#StartTime').datetimepicker({
        format: 'DD-MMM-YYYY HH:mm',
        sideBySide: true,
        showTodayButton: true
    });

    var date = new Date();
    date.setHours(1);
    date.setMinutes(0);
    $('#Duration').datetimepicker({
        format: 'HH:mm',
        defaultDate: date,
        showClear: true
    });
});