function calcArea() {
    var r = document.getElementById('radius').value;
    document.getElementById('result').innerHTML = 'The area of the circle is: ' + Math.PI * r * r;
}
