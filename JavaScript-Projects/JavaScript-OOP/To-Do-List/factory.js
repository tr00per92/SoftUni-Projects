define(['container', 'section', 'item'], function() {

    'use strict';

    var Factory = (function () {

        function Factory() {}

        Factory.prototype.createContainer = function() {
            return new Container();
        };

        Factory.prototype.createSection = function(title) {
            return new Section(title);
        };

        Factory.prototype.createItem = function(content) {
            return new Item(content);
        };

        var getInstance = function() {
            if (!factoryInstance) {
                var factoryInstance = new Factory();
            }
            return factoryInstance;
        };

        return {
            getInstance: getInstance
        };
    }());

    return Factory;
});
