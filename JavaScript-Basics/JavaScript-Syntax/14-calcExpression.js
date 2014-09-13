function calcExpression() {
    var regex = /^[0-9 \-+/*.()]+$/;
    var expression = document.getElementById("expression").value;
    try {
        if (regex.test(expression)) {
            document.getElementById("result").innerHTML = eval(expression);
        } else {
            document.getElementById("result").innerHTML = "wrong input";
        }
    } catch (err) {
        document.getElementById("result").innerHTML = "wrong input";
    }
}