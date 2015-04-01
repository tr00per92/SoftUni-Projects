var canvas = document.createElement('canvas');
var width = 950;
var height = 650;
canvas.width = width;
canvas.height = height;
var context = canvas.getContext('2d');

var animate = window.requestAnimationFrame || window.webkitRequestAnimationFrame ||
    window.mozRequestAnimationFrame || window.msRequestAnimationFrame;

window.onload = function() {
    document.body.appendChild(canvas);
    animate(frameChange);
	unloadScrollBars();
};

//remove window scrollbar 
function unloadScrollBars() {
    document.documentElement.style.overflow = 'hidden'; 
}

// main loop
var frameChange = function() {
    if (!waitingInput) {
        leftPlatform.move();
        rightPlatform.move();
        ball.move();
        renderField();
    } else {
        for (var key in keysPressed) {
            if (key != '') {
                waitingInput = false;
                if (gameover) {
                    bricks = initializeBricks();
                    gameInfo = new GameInfo(3);
                    gameover = false;
                }
            }
        }
    }
    animate(frameChange);
};

// creating objects
var leftPlatform = new Platform(0, 220, 10, 100);
var rightPlatform = new Platform(width - 10, 220, 10, 100);
var ball = new Ball(7, 800, 252);
var bricks = initializeBricks();
var gameInfo = new GameInfo(3);
var keysPressed = {};
var waitingInput = false;
var gameover = false;

// drawing all the stuff
var renderField = function() {
    context.fillStyle = "black";
    context.fillRect(0, 0, width, height);
    leftPlatform.render();
    rightPlatform.render();
    renderBricks(bricks);
    ball.render();
    gameInfo.render();
};

// platform "class"
function Platform(x, y, width, height) {
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
}
Platform.prototype.render = function() {
    context.fillStyle = 'red';
    context.fillRect(this.x, this.y, this.width, this.height);
};
Platform.prototype.move = function() {
    for (var key in keysPressed) {
        // up arrow
        if (key == '38') {
            this.y -= 7;
            if (this.y < 0) {
                this.y = 0;
            }
        }
        // down arrow
        else if (key == '40') {
            this.y += 7;
            if (this.y > height - this.height) {
                this.y = height - this.height;
            }
        }
    }
};

// gameinfo "class"
function GameInfo(lives) {
    this.points = 0;
    this.lives = lives;
}
GameInfo.prototype.render = function () {
    context.fillStyle = 'white';
    context.font = '22px Tahoma';
    context.fillText('Lives left: ' + this.lives, 820, 30);
    if (waitingInput) {
        context.font = '30px Tahoma';
        if (gameover) {
            context.fillText('Game Over. Press any key to play again.', 200, 50);
        } else {
            context.fillText('You Lost a Life. Press any key to continue.', 200, 50);
        }
    }
};
function loseLive() {
    gameInfo.lives--;
    if (gameInfo.lives <= 0) {
        gameover = true;
    }
    ball.x = 100;
    ball.y = leftPlatform.y + leftPlatform.height / 2;
    waitingInput = true;
}

// ball "class"
function Ball(radius, x, y) {
    this.radius = radius;
    this.x = x;
    this.y = y;
    this.movingRight = true;
    this.movingDown = true;
    this.xSpeed = 10;
    this.ySpeed = 0;
}
Ball.prototype.render = function() {
    context.fillStyle = 'white';
    context.beginPath();
    context.arc(this.x, this.y, this.radius, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
};
Ball.prototype.move = function() {
    if (this.movingRight) {
        if (this.x - this.radius <= width - this.xSpeed - this.radius * 2 - rightPlatform.width) {
            this.x += this.xSpeed;
        } else {
            if ((this.y + this.radius >= rightPlatform.y && this.y - this.radius <= rightPlatform.y + rightPlatform.height)) {
                this.movingRight = false;
                if ((this.y + this.radius >= rightPlatform.y && this.y - this.radius < rightPlatform.y + rightPlatform.height / 2)) {
                    if (this.movingDown) {
                        this.ySpeed--;
                    } else {
                        this.ySpeed++;
                    }
                } else {
                    if (this.movingDown) {
                        this.ySpeed++;
                    } else {
                        this.ySpeed--;
                    }
                }
            } else {
                loseLive();
            }
        }
        this.y += this.ySpeed;
        if (this.ySpeed < 0) {
            this.movingDown = false;
        } else {
            this.movingDown = true;
        }
        if (this.y <= 0) {
            this.movingDown = true;
            this.ySpeed *= -1;
        }
        if (this.y >= height) {
            this.movingDown = false;
            this.ySpeed *= -1;
        }
    } else {
        if (this.x > leftPlatform.width + this.xSpeed) {
            this.x -= this.xSpeed;
        } else {
            if ((this.y + this.radius >= leftPlatform.y && this.y - this.radius <= leftPlatform.y + leftPlatform.height)) {
                this.movingRight = true;
                if ((this.y + this.radius >= rightPlatform.y && this.y - this.radius < rightPlatform.y + rightPlatform.height / 2)) {
                    if (this.movingDown) {
                        this.ySpeed--;
                    } else {
                        this.ySpeed++;
                    }
                } else {
                    if (this.movingDown) {
                        this.ySpeed++;
                    } else {
                        this.ySpeed--;
                    }
                }
            } else {
                loseLive();
            }
        }
        this.y += this.ySpeed;
        if (this.ySpeed < 0) {
            this.movingDown = false;
        } else {
            this.movingDown = true;
        }
        if (this.y <= 0) {
            this.movingDown = true;
            this.ySpeed *= -1;
        }
        if (this.y >= height) {
            this.movingDown = false;
            this.ySpeed *= -1;
        }
    }
    brickCheck();
};
function brickCheck() {
    for (var k = 0; k < bricks.length; k++) {
        if (ball.x > bricks[k].x && ball.y > bricks[k].y && ball.x < bricks[k].x + bricks[k].width && ball.y < bricks[k].y + bricks[k].height) {
            ball.movingRight = !ball.movingRight;
            gameInfo.points++;
            bricks.splice(k, 1);
        }
    }
}

// bricks
function Brick(x, y, src) {
    this.x = x;
    this.y = y;
    this.width = 35;
    this.height = 35;
    this.src = src;
}
function initializeBricks() {
    var startX = (width - 350) / 2;
    var startY = (height - 490) / 2;
    var brickPositions = new Array(14);
    for (var k = 0; k < brickPositions.length; k++) {
        brickPositions[k] = new Array(10);
    }
    var num = 1;
    var bricks = [];
    for (var i = 0; i < brickPositions.length; i++) {
        for (var j = 0; j < brickPositions[i].length; j++) {
            var posX = startX + j * 35;
            var posY = startY + i * 35;
            var src = 'images/nakov/nakov (' + num + ').jpg';
            bricks.push(new Brick(posX, posY, src));
            num++;
        }
    }
    return bricks;
}
function renderBricks(bricks) {
    for (var i in bricks) {
        var currentImg = new Image();
        currentImg.src = bricks[i].src;
        context.drawImage(currentImg, bricks[i].x, bricks[i].y);
    }
}

// key listeners
window.addEventListener('keydown', function(event) {
    keysPressed[event.keyCode] = true;
});
window.addEventListener('keyup', function(event) {
    delete keysPressed[event.keyCode];
});
