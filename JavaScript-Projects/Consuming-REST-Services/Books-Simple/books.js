(function () {
    var HEADERS = {
        'X-Parse-Application-Id': 'klqKfKJ6LmWFtxonJ5tpQfW86vja0LqgwVSdVgEf',
        'X-Parse-REST-API-Key': 'NrYZtCS9TMvDCD5UyecBsX7Uw8Ynl1JUlL0KP84P'
    };

    $.ajaxSetup({
        headers: HEADERS,
        error: ajaxError
    });

    $(function() {
        loadBooks();
        $('#add-book-btn').click(addBook);
        $('#cancel-edit-btn').click(loadBooks);
    });

    function loadBooks() {
        $.ajax({
            method: 'GET',
            url: 'https://api.parse.com/1/classes/Book',
            success: booksLoaded
        });
    }

    function booksLoaded(data) {
        $('#add-book-btn, #add-book-label').show();
        $('#edit-book-label, #save-edit-btn, #cancel-edit-btn').hide();
        $('#books').empty();
        $('#new-book-title').val('');
        $('#new-book-author').val('');
        $('#new-book-isbn').val('');
        $('#new-book-tags').val('');
        data.results.forEach(function(book) {
            $('<li>')
                .append($('<span>')
                    .text(book.title || 'No title')
                .append($('<span>')
                    .text(' | Author: ' + (book.author || 'Not specified'))
                    .css('color', 'blue'))
                .append($('<span>')
                    .text(' | Isbn: ' + (book.isbn || 'Not specified')))
                .append($('<span>')
                    .text(' | Tags: ' + (book.tags || 'No tags'))
                    .css('color', 'blue')))
                .append(' ')
                .append($('<button>')
                    .text('EDIT')
                    .click(editBook)
                    .data('book', book))
                .append(' ')
                .append($('<button>')
                    .text('DELETE')
                    .click(deleteBook)
                    .data('book', book))
                .attr('id', book.objectId)
                .appendTo($('#books'));
        });
    }

    function addBook() {
        $.ajax({
            method: 'POST',
            url: 'https://api.parse.com/1/classes/Book',
            data: JSON.stringify({
                'title':$('#new-book-title').val(),
                'author':$('#new-book-author').val(),
                'isbn':$('#new-book-isbn').val(),
                'tags':$('#new-book-tags').val().split(/\s*,\s*/)
            }),
            contentType: 'application/json',
            success: loadBooks
        });
    }

    function deleteBook() {
        var book = $(this).data('book');
        if (confirm('Are you sure you want to delete this book?')) {
            $.ajax({
                method: 'DELETE',
                url: 'https://api.parse.com/1/classes/Book/' + book.objectId,
                success: loadBooks
            });
        }
    }

    function editBook() {
        var book = $(this).data('book');

        $('#new-book-title').val(book.title);
        $('#new-book-author').val(book.author);
        $('#new-book-isbn').val(book.isbn);
        $('#new-book-tags').val(book.tags);
        $('#add-book-btn, #add-book-label').hide();
        $('#edit-book-label, #cancel-edit-btn').show();
        $('#save-edit-btn').show().unbind('click').click(saveEdit);

        function saveEdit() {
            $.ajax({
                method: 'PUT',
                url: 'https://api.parse.com/1/classes/Book/' + book.objectId,
                data: JSON.stringify({
                    'title':$('#new-book-title').val(),
                    'author':$('#new-book-author').val(),
                    'isbn':$('#new-book-isbn').val(),
                    'tags':$('#new-book-tags').val().split(/\s*,\s*/)
                }),
                contentType: 'application/json',
                success: loadBooks
            });
        }
    }

    function ajaxError() {
        alert('AJAX error.');
    }
})();
