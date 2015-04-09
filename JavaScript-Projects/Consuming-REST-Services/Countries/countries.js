(function() {
    var HEADERS = {
        'X-Parse-Application-Id': 'pGD8PmH4dJfHFV4cmHRtJ1QU14EkwhaA1ExbwdE0',
        'X-Parse-REST-API-Key': '8Y0pmC8L3soguGkiRaPSph0V6UMZtYlMzpY3jmBk'
    };

    $.ajaxSetup({
        headers: HEADERS,
        error: ajaxError
    });

    $(function() {
        loadCountries();
        $('#add-country').click(addCountry);
        $('#add-town').click(addTown);
    });

    function loadCountries() {
        $.ajax({
            method: 'GET',
            url: 'https://api.parse.com/1/classes/Country',
            success: countriesLoaded
        });
    }

    function countriesLoaded(data) {
        $('#countries').empty();
        $('#new-country-name').val('');
        $('#new-town-name').val('');
        $('#towns').hide();
        data.results.forEach(function(country) {
            $('<li>')
                .append($('<a>')
                    .text(country.name)
                    .attr('href', '#')
                    .css('color', 'green')
                    .click(loadTowns)
                    .data('country', country))
                .append(' ')
                .append($('<a>')
                    .text('[edit]')
                    .attr('href', '#')
                    .css('color', 'blue')
                    .click(editCountry)
                    .data('country', country))
                .append(' ')
                .append($('<a>')
                    .text('[remove]')
                    .attr('href', '#')
                    .css('color', 'red')
                    .click(removeCountry)
                    .data('country', country))
                .attr('id', country.objectId)
                .appendTo($('#countries'));
        });
    }

    function addCountry() {
        $.ajax({
            method: 'POST',
            data: JSON.stringify({
                'name':$('#new-country-name').val()
            }),
            contentType: 'application/json',
            url: 'https://api.parse.com/1/classes/Country',
            success: loadCountries
        });
    }

    function removeCountry() {
        var country = $(this).data('country');
        if (confirm('Are you sure you want to delete ' + country.name)) {
            $.ajax({
                method: 'DELETE',
                url: 'https://api.parse.com/1/classes/Country/' + country.objectId,
                success: findTowns
            });

            function findTowns() {
                $.ajax({
                    method: 'GET',
                    url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + country.objectId + '"}}',
                    success: removeTowns
                });

                function removeTowns(data) {
                    data.results.forEach(function(town) {
                        $.ajax({
                            method: 'DELETE',
                            url: 'https://api.parse.com/1/classes/Town/' + town.objectId
                        });
                    });
                    loadCountries();
                }
            }
        }
    }

    function editCountry() {
        var country = $(this).data('country');
        $('#' + country.objectId).replaceWith($('<li>')
            .append('<input type="text" placeholder="Enter the new name..." id="newName' + country.objectId + '"/>')
            .append($('<button>').text('Save').click(saveEdit))
            .append($('<button>').text('Cancel').click(loadCountries)));

        function saveEdit() {
            $.ajax({
                method: 'PUT',
                url: 'https://api.parse.com/1/classes/Country/' + country.objectId,
                data: JSON.stringify({
                    'name':$('#newName' + country.objectId).val()
                }),
                contentType: 'application/json',
                success: loadCountries
            });
        }
    }

    function loadTowns() {
        var country = $(this).data('country');
        $('#towns').hide().children('h3').text('Towns in ' + country.name);
        $('#add-town').data('country', country);
        $.ajax({
            method: 'GET',
            url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + country.objectId + '"}}',
            success: townsLoaded
        });
    }

    function townsLoaded(data) {
        $('#towns').show().children('ul').empty();
        data.results.forEach(function(town) {
            $('<li>')
                .text(town.name)
                .append(' ')
                .append($('<a>')
                    .text('[edit]')
                    .attr('href', '#')
                    .css('color', 'blue')
                    .click(editTown)
                    .data('town', town))
                .append(' ')
                .append($('<a>')
                    .text('[remove]')
                    .attr('href', '#')
                    .css('color', 'red')
                    .click(removeTown)
                    .data('town', town))
                .attr('id', town.objectId)
                .appendTo($('#towns').children('ul'));
        });
    }

    function addTown() {
        var country = $(this).data('country');
        $.ajax({
            method: 'POST',
            data: JSON.stringify({
                'name':$('#new-town-name').val(),
                'country':{'__type':'Pointer','className':'Country','objectId':country.objectId}
            }),
            contentType: 'application/json',
            url: 'https://api.parse.com/1/classes/Town',
            success: townAdded
        });

        function townAdded() {
            $('#' + country.objectId).children().first().click();
            $('#new-town-name').val('');
        }
    }

    function removeTown() {
        var town = $(this).data('town');
        if (confirm('Are you sure you want to delete ' + town.name)) {
            $.ajax({
                method: 'DELETE',
                url: 'https://api.parse.com/1/classes/Town/' + town.objectId,
                success: townRemoved
            });
        }

        function townRemoved() {
            $('#' + town.country.objectId).children().first().click();
        }
    }

    function editTown() {
        var town = $(this).data('town');
        $('#' + town.objectId).replaceWith($('<li>')
            .append('<input type="text" placeholder="Enter the new name..." id="newName' + town.objectId + '"/>')
            .append($('<button>').text('Save').click(saveEdit))
            .append($('<button>').text('Cancel').click(editFinished)));

        function saveEdit() {
            $.ajax({
                method: 'PUT',
                url: 'https://api.parse.com/1/classes/Town/' + town.objectId,
                data: JSON.stringify({
                    'name':$('#newName' + town.objectId).val()
                }),
                contentType: 'application/json',
                success: editFinished
            });
        }

        function editFinished() {
            $('#' + town.country.objectId).children().first().click();
        }
    }

    function ajaxError() {
        alert('Cannot load AJAX data.');
    }
})();
