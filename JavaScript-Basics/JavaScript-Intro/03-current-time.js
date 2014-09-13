var now = new Date();
var h = now.getHours();
var min = now.getMinutes();
if (min < 10) {
    min = "0" + min;
}
console.log("%d:%d", h, min);