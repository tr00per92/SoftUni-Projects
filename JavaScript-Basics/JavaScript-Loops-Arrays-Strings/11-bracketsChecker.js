function checkBrackets(input) {
    var brackets = 0;
    for (var i = 0; i < input.length; i++) {
        if (input[i] === '(') {
            brackets++;
        } else if (input[i] === ')') {
            brackets--;
        }
    }
    console.log(brackets == 0 ? "correct" : "incorrect");
}
checkBrackets('( ( a + b ) / 5 – d )');
checkBrackets(') ( a + b ) )');
checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');