var app = app || {};

app.data = (function() {
    function Data(rootUrl) {
        this.rootUrl = rootUrl;
        this.books = new Base(rootUrl + 'Book/');
    }

    var Base = (function () {
        function Base(serviceUrl) {
            this.serviceUrl = serviceUrl;
        }

        Base.prototype.getAll = function(success) {
            return app.ajaxRequester.get(this.serviceUrl, success);
        };

        Base.prototype.add = function(data, success) {
            return app.ajaxRequester.post(this.serviceUrl, data, success);
        };

        Base.prototype.edit = function(id, data, success) {
            return app.ajaxRequester.put(this.serviceUrl + id, data, success);
        };

        Base.prototype.remove = function(id, success) {
            return app.ajaxRequester.delete(this.serviceUrl + id, success);
        };

        return Base;
    }());

    return {
        get: function(rootUrl) {
            return new Data(rootUrl);
        }
    }
}());
