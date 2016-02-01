'use strict';

var domModule = function domModuleFunc() {
    function appendChild(child, parentSelector) {
        var parent = document.querySelector(parentSelector);
        parent.appendChild(child);
    }
    
    function removeChild(parentSelector, childSelector) {
        var parent = document.querySelector(parentSelector);
        var child = document.querySelector(childSelector);
        parent.removeChild(child);
    }
    
    function addHandler(elementSelector, handler, event) {
        var elements = document.querySelectorAll(elementSelector);
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(handler, event);
        }
    }
    
    function retrieveElements(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
}();

// Creates a list element
var liElement = document.createElement("li");

// Appends a list item to ul.birds-list
domModule.appendChild(liElement, ".birds-list");

// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");

// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function () { alert("I'm a bird!") });

// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");
console.log(elements);
