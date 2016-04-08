var Container = (function () {
    'use strict';

    function Container() {
        this.clearSections();
    }

    Container.prototype.getSections = function() {
        return this._sections;
    };

    Container.prototype.addSection = function(section) {
        if (! (section instanceof Section)) {
            throw new Error('The container can contain only sections');
        }

        this._sections.forEach(function(existingSection){
            if (existingSection.getTitle() === section.getTitle()){
                throw new Error('A section with the same title already exists.');
            }
        });

        this._sections.push(section);
    };

    Container.prototype.clearSections = function() {
        this._sections = [];
    };

    Container.prototype.addToDom = function() {
        var container = document.createElement('div');
        container.id = 'container';
        container.innerHTML =
            '<h1>Today\'s To Do List</h1>' +
            '<input type="text" id="newSectionTitle" placeholder="Title"/>' +
            '<button type="button" id="addSectionBtn">New Section</button>';
        document.getElementsByTagName('body')[0].appendChild(container);
    };

    return Container;
}());
