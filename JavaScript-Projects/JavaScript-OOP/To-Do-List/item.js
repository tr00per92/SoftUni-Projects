var Item = (function () {
    'use strict';

    function Item(content) {
        this.setContent(content);
        this.setIsCompleted(false);
    }

    Item.prototype.getContent = function() {
        return this._content;
    };

    Item.prototype.setContent = function(content) {
        if (typeof(content) != 'string' || !content) {
            throw new Error('The content must be a non-empty string');
        }

        this._content = content;
    };

    Item.prototype.getIsCompleted = function() {
        return this._isCompleted;
    };

    Item.prototype.setIsCompleted = function(isCompleted) {
        if (typeof(isCompleted) != 'boolean') {
            throw new Error('The completed status must be a boolean');
        }

        this._isCompleted = isCompleted;
    };

    return Item;
}());
