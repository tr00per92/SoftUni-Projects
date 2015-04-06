var app = app || {};

app.controller = (function () {
    function Main(dataPersister) {
        this.persister = dataPersister;
    }

    Main.prototype.load = function (selector) {
        var _this = this;
        $(function () {
            _this.loadBooks(selector);
            _this.attachEventHandlers();
        });
    };

    Main.prototype.loadBooks = function (selector) {
        this.persister.books.getAll(
            function (data) {
                selector = $(selector).html('');
                data.results.forEach(function(book) {
                    selector.append($('<div>')
                        .append($('<div>').text('Title: ' + (book.title || 'no title')))
                        .append($('<div>').text('Author: ' + (book.author || 'not specified')))
                        .append($('<div>').text('Isbn: ' + (book.isbn || 'not specified')))
                        .append($('<div>').text('Tags: ' + book.tags ))
                        .append('<button class="edit-book-btn">Edit</button>')
                        .append('<button class="remove-book-btn">Delete</button>')
                        .data('book', book));
                });
            });
    };

    Main.prototype.attachEventHandlers = function () {
        var _this = this;
        $('#add-book-btn').click(function () {
            var book = getBookFromInput();
            _this.persister.books.add(book, loadBooks);
        });

        var booksDiv = $('#books');
        booksDiv.on('click', '.remove-book-btn', function () {
            var bookData = $(this).parent().data('book');
            if (confirm('Are you sure you want to delete this book?')) {
                _this.persister.books.remove(bookData.objectId, loadBooks);
            }
        });

        booksDiv.on('click', '.edit-book-btn', function () {
            var bookData = $(this).parent().data('book');
            $('#book-title').val(bookData.title);
            $('#book-author').val(bookData.author);
            $('#book-isbn').val(bookData.isbn);
            $('#book-tags').val(bookData.tags);
            $('#add-book-btn').hide();
            $('#save-book-btn').show().unbind('click').click(function () {
                var book = getBookFromInput();
                _this.persister.books.edit(bookData.objectId, book, loadBooks);
            });
        });

        function loadBooks() {
            _this.loadBooks('#books');
            $('#book-title, #book-author, #book-isbn, #book-tags').val('');
            $('#add-book-btn').show();
            $('#save-book-btn').hide();
        }

        function getBookFromInput() {
            return {
                title: $('#book-title').val(),
                author: $('#book-author').val(),
                isbn: $('#book-isbn').val(),
                tags: $('#book-tags').val().split(/\s*,\s*/)
            }
        }
    };

    return {
        get: function(dataPersister) {
            return new Main(dataPersister);
        }
    }
}());
