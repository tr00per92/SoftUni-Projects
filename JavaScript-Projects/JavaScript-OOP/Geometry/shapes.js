'use strict';

var Shapes = (function () {

    var ctx = document.getElementById('myCanvas').getContext('2d');

    Object.prototype.inherits = function(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    var Shape = (function () {
        function Shape(x, y, color) {
            this.setX(x);
            this.setY(y);
            this.setColor(color);
        }

        Shape.prototype._type = 'Shape';

        Shape.prototype.getType = function() {
            return this._type;
        };

        Shape.prototype.getX = function() {
            return this._x;
        };

        Shape.prototype.setX = function(x) {
            if (typeof(x) != 'number') {
                throw new Error('X must be a number');
            }

            this._x = x;
        };

        Shape.prototype.getY = function() {
            return this._y;
        };

        Shape.prototype.setY = function(y) {
            if (typeof(y) != 'number') {
                throw new Error('Y must be a number');
            }

            this._y = y;
        };

        Shape.prototype.getColor = function() {
            return this._color;
        };

        Shape.prototype.setColor = function(color) {
            if (!color || !color.match(/\b[0-9a-fA-F]{6}\b/g)) {
                throw new Error('You must enter a color in hexadecimal format');
            }

            this._color = color;
        };
        
        Shape.prototype.toString = function () {
            return this._type + ' - X: ' + this._x + ', Y: ' + this._y + ', Color: ' + this._color.toUpperCase();
        };
        
        return Shape;
    }());
    
    var Circle = (function () {
        function Circle(x, y, color, radius) {
            Shape.apply(this, arguments);
            this.setRadius(radius);
        }
        
        Circle.inherits(Shape);

        Circle.prototype._type = 'Circle';

        Circle.prototype.getRadius = function() {
            return this._radius;
        };

        Circle.prototype.setRadius = function(radius) {
            if (typeof(radius) != 'number' || radius <= 0) {
                throw new Error('The radius must be a positive number');
            }

            this._radius = radius;
        };
        
        Circle.prototype.draw = function () {
            ctx.beginPath();
            ctx.arc(this._x, this._y, this._radius, 0, 2 * Math.PI);
            ctx.fillStyle = this._color;
            ctx.fill();
        };

        Circle.prototype.toString = function () {
            return Shape.prototype.toString.call(this) + ', Radius: ' + this._radius;
        };
        
        return Circle;
    }());
    
    var Rectangle = (function () {
        function Rectangle(x, y, color, width, height) {
            Shape.apply(this, arguments);
            this.setWidth(width);
            this.setHeight(height);
        }
        
        Rectangle.inherits(Shape);

        Rectangle.prototype._type = 'Rectangle';

        Rectangle.prototype.getWidth = function() {
            return this._width;
        };

        Rectangle.prototype.setWidth = function(width) {
            if (typeof(width) != 'number' || width <= 0) {
                throw new Error('The width must be a positive number');
            }

            this._width = width;
        };

        Rectangle.prototype.getHeight = function() {
            return this._height;
        };

        Rectangle.prototype.setHeight = function(height) {
            if (typeof(height) != 'number' || height <= 0) {
                throw new Error('The height must be a positive number');
            }

            this._height = height;
        };
        
        Rectangle.prototype.draw = function () {
            ctx.fillStyle = this._color;
            ctx.fillRect(this._x, this._y, this._width, this._height);
        };

        Rectangle.prototype.toString = function () {
            return Shape.prototype.toString.call(this) + ', Width: ' + this._width + ', Height: ' + this._height;
        };


        return Rectangle;
    }());
    
    var Triangle = (function () {
        function Triangle(x, y, color, x2, y2, x3, y3) {
            Shape.apply(this, arguments);
            this.setX2(x2);
            this.setY2(y2);
            this.setX3(x3);
            this.setY3(y3);
        }

        Triangle.inherits(Shape);

        Triangle.prototype._type = 'Triangle';

        Triangle.prototype.getX2 = function() {
            return this._x2;
        };

        Triangle.prototype.setX2 = function(x2) {
            if (typeof(x2) != 'number') {
                throw new Error('X2 must be a number');
            }

            this._x2 = x2;
        };

        Triangle.prototype.getY2 = function() {
            return this._y2;
        };

        Triangle.prototype.setY2 = function(y2) {
            if (typeof(y2) != 'number') {
                throw new Error('Y2 must be a number');
            }

            this._y2 = y2;
        };

        Triangle.prototype.getX3 = function() {
            return this._x3;
        };

        Triangle.prototype.setX3 = function(x3) {
            if (typeof(x3) != 'number') {
                throw new Error('X3 must be a number');
            }

            this._x3 = x3;
        };

        Triangle.prototype.getY3 = function() {
            return this._y3;
        };

        Triangle.prototype.setY3 = function(y3) {
            if (typeof(y3) != 'number') {
                throw new Error('Y3 must be a number');
            }

            this._y3 = y3;
        };

        Triangle.prototype.draw = function () {
            ctx.moveTo(this._x, this._y);
            ctx.lineTo(this._x2, this._y2);
            ctx.lineTo(this._x3, this._y3);
            ctx.lineTo(this._x, this._y);
            ctx.fillStyle = this._color;
            ctx.fill();
        };
        
        Triangle.prototype.toString = function () {
            return Shape.prototype.toString.call(this) + ', X2: ' + this._x2 + ', Y2: ' + this._y2 +
                ', X3: ' + this._x3 + ', Y3: ' + this._y3;
        };
        
        return Triangle;
    }());
    
    var Segment = (function () {
        function Segment(x, y, color, x2, y2) {
            Shape.apply(this, arguments);
            this.setX2(x2);
            this.setY2(y2);
        }

        Segment.inherits(Shape);

        Segment.prototype._type = 'Segment';

        Segment.prototype.getX2 = function() {
            return this._x2;
        };

        Segment.prototype.setX2 = function(x2) {
            if (typeof(x2) != 'number') {
                throw new Error('X2 must be a number');
            }

            this._x2 = x2;
        };

        Segment.prototype.getY2 = function() {
            return this._y2;
        };

        Segment.prototype.setY2 = function(y2) {
            if (typeof(y2) != 'number') {
                throw new Error('Y2 must be a number');
            }

            this._y2 = y2;
        };
        
        Segment.prototype.draw = function () {
            ctx.moveTo(this._x, this._y);
            ctx.lineTo(this._x2, this._y2);
            ctx.strokeStyle = this._color;
            ctx.stroke();
        };

        Segment.prototype.toString = function () {
            return Shape.prototype.toString.call(this) + ', X2: ' + this._x2 + ', Y2: ' + this._y2;
        };
        
        return Segment;
    }());
    
    var Point = (function () {
        function Point(x, y, color) {
            Shape.apply(this, arguments);
        }
        
        Point.inherits(Shape);

        Point.prototype._type = 'Point';
        
        Point.prototype.draw = function () {
            ctx.strokeStyle = this._color;
            ctx.strokeRect(this._x, this._y, 1, 1);
        };
        
        return Point;
    }());
    
    return {
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Segment: Segment,
        Point: Point
    };
}());
