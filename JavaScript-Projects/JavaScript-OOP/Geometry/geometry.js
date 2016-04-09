'use strict';

var allShapes = [];

function drawShapes() {
    document.getElementById('myCanvas').getContext('2d').clearRect(-100, -100, 1000, 1000);
    var infoContent = '';

    for (var i = 0; i < allShapes.length; i++) {
        infoContent += '<p>' + allShapes[i].toString() +
            ' <button type="button" onclick=removeShape(' + i + ')>-</button></p>';

        allShapes[i].draw();
    }

    document.getElementById('shapesInfo').innerHTML = infoContent;
}

function removeShape(id) {
    allShapes.splice(id, 1);
    drawShapes();
}

var shapeSelector = document.getElementById('shapeSelector');
shapeSelector.onchange = function () {
    var attributesDiv = document.getElementById('shapeAttributes');
    var shape = shapeSelector.options[shapeSelector.selectedIndex].value;
    switch (shape) {
        case 'circle':
            attributesDiv.innerHTML =
                '<label for="r">Radius: </label><input type="number" min="0" max="550" id="r"/>';
            break;
        case 'rectangle':
            attributesDiv.innerHTML =
                '<label for="width">Width: </label><input type="number" min="0" max="550" id="width"/>' +
                '<label for="height">Height: </label><input type="number" min="0" max="550" id="height"/>';
            break;
        case 'triangle':
            attributesDiv.innerHTML =
                '<label for="x2">X2: </label><input type="number" min="0" max="550" id="x2"/>' +
                '<label for="y2">Y2: </label><input type="number" min="0" max="550" id="y2"/><br>' +
                '<label for="x3">X3: </label><input type="number" min="0" max="550" id="x3"/>' +
                '<label for="y3">Y3: </label><input type="number" min="0" max="550" id="y3"/>';
            break;
        case 'segment':
            attributesDiv.innerHTML =
                '<label for="x2">X2: </label><input type="number" min="0" max="550" id="x2"/>' +
                '<label for="y2">Y2: </label><input type="number" min="0" max="550" id="y2"/>';
            break;
        default:
            attributesDiv.innerHTML = '';
            break;
    }
};

document.getElementById('addButton').onclick = function () {
    var shape = shapeSelector.options[shapeSelector.selectedIndex].value;
    var currentShape;
    var x = Number(document.getElementById('x').value);
    var y = Number(document.getElementById('y').value);
    var color = document.getElementById('color').value;
    switch (shape) {
        case 'circle':
            var r = Number(document.getElementById('r').value);
            currentShape = new Shapes.Circle(x, y, color, r);
            break;
        case 'rectangle':
            var width = Number(document.getElementById('width').value);
            var height = Number(document.getElementById('height').value);
            currentShape = new Shapes.Rectangle(x, y, color, width, height);
            break;
        case 'triangle':
            var x1 = Number(document.getElementById('x2').value);
            var y1 = Number(document.getElementById('y2').value);
            var x2 = Number(document.getElementById('x3').value);
            var y2 = Number(document.getElementById('y3').value);
            currentShape = new Shapes.Triangle(x, y, color, x1, y1, x2, y2);
            break;
        case 'segment':
            var x3 = Number(document.getElementById('x2').value);
            var y3 = Number(document.getElementById('y2').value);
            currentShape = new Shapes.Segment(x, y, color, x3, y3);
            break;
        case 'point':
            currentShape = new Shapes.Point(x, y, color);
            break;
        default:
            break;
    }

    allShapes.push(currentShape);
    drawShapes();
};
