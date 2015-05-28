(function() {
    var $grid;

    $(function() {
        $('button:first-of-type').click(function() {
            $grid = $(this).siblings('table');
            setHeader();
        });
        $('button:nth-of-type(2)').click(function() {
            $grid = $(this).siblings('table');
            addRow();
        });
        $('button:last-of-type').click(function() {
            $grid = $(this).siblings('table');
            addGrid();
        });
    });

    function setHeader() {
        var inputs = $grid.siblings('input'),
            header = $('<tr>');
        inputs.each(function(_, input) {
            header.append($('<th>').text(input.value));
        });
        $grid.children().children().children('th').parent().remove();
        $grid.prepend(header);
    }

    function addRow() {
        var inputs = $grid.siblings('input'),
            row = $('<tr>');
        inputs.each(function(_, input) {
            row.append($('<td>').text(input.value));
        });
        $grid.append(row);
    }

    function addGrid() {
        var newGrid = $('<tr>')
            .append($('<td>')
                .attr('colspan', 4)
                .append($('<div>')
                    .html($('#grid-controls').html())));
        newGrid.find('table').html('');
        newGrid.find('button:first-of-type').click(function() {
            $grid = newGrid.children().children().children('table');
            setHeader();
        });
        newGrid.find('button:nth-of-type(2)').click(function() {
            $grid = newGrid.children().children().children('table');
            addRow();
        });
        newGrid.find('button:last-of-type').click(function() {
            $grid = newGrid.children().children().children('table');
            addGrid();
        });
        $grid.append(newGrid);
    }
})();
