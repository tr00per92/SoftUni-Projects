function extractContent(input) {
    var result = "";
    var isContent = true;
    for (var i = 0; i < input.length; i++) {
        if (input[i] === "<") {
            isContent = false;
        } else if (input[i] === ">") {
            isContent = true;
        } else if (isContent) {
            result += input[i];
        }
    }
    return result;
}
console.log(extractContent("<p>Hello</p><a href='http://w3c.org'>W3C</a>"));
console.log(extractContent("<ul><li><a href='http://softuni.bg'>SoftUni</a></li></ul>"));