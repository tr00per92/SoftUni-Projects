(function() {
    $(function() {
        $('#generate-btn').click(generateTable);
    });

    function generateTable() {
        var table =	$(document.createElement("table"));
        table.append('<tr><th>Manufacturer</th><th>Model</th><th>Year</th><th>Price</th><th>Class</th></tr>');
        var json = JSON.parse($('#json-string').val());
        $(json).each(function(_, car) {
            var row = $(document.createElement('tr'));
            row.append('<td>' + car['manufacturer'] + '</td>');
            row.append('<td>' + car['model'] + '</td>');
            row.append('<td>' + car['year'] + '</td>');
            row.append('<td>' + car['price'] + '</td>');
            row.append('<td>' + car['class'] + '</td>');
            table.append(row);
        });

        $('#wrapper').append(table);
        $('th').css('background', 'lightgreen');
        $('th, td, table')
            .css('border', '1px solid black')
            .css('border-collapse', 'collapse')
            .css('padding', '5px')
            .css('margin-top', '10px');
    }
})();
