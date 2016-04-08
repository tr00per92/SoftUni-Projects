var Section = (function () {
    'use strict';

    function Section(title) {
        this.setTitle(title);
        this.clearItems();
    }

    Section.prototype.getTitle = function() {
        return this._title;
    };

    Section.prototype.setTitle = function(title) {
        if (typeof(title) != 'string' || !title) {
            throw new Error('The title must be a non-empty string');
        }

        this._title = title;
    };

    Section.prototype.getItems = function() {
        return this._items;
    };

    Section.prototype.addItem = function(item) {
        if (! (item instanceof Item)) {
            throw new Error('The section can contain only items');
        }

        this._items.forEach(function(existingItem){
            if (existingItem.getContent() === item.getContent()) {
                throw new Error('The same item already exists.');
            }
        });

        this._items.push(item);
    };

    Section.prototype.clearItems = function() {
        this._items = [];
    };

    Section.prototype.addToDom = function () {
        var section = this;
        var sectionElement = document.createElement('section');
        sectionElement.id = this._title;
        sectionElement.innerHTML =
            '<h3>' + this._title + '</h3><input type="text" placeholder="Add item..."/>';
        var buttonElement = document.createElement('button');
        buttonElement.type = 'button';
        buttonElement.innerHTML = '+';
        buttonElement.onclick = function () {
            var itemContent = sectionElement.lastChild.previousSibling.value;
            var item = new Item(itemContent);
            section.addItem(item);
            var itemElement = document.createElement('div');
            itemElement.className = 'uncompleted';
            itemElement.innerHTML = '<input type="checkbox"/>' + item.getContent();
            itemElement.onclick = function () {
                item.setIsCompleted(!item.getIsCompleted());
                if (item.getIsCompleted()) {
                    itemElement.className = 'completed';
                    itemElement.firstChild.checked = true;
                } else {
                    itemElement.className = 'uncompleted';
                    itemElement.firstChild.checked = false;
                }
            };

            sectionElement.insertBefore(itemElement, sectionElement.firstChild.nextSibling);
        };

        sectionElement.appendChild(buttonElement);
        var containerElement =  document.getElementById('container');
        containerElement.insertBefore(sectionElement, document.getElementById('newSectionTitle'));
    };

    return Section;
}());
