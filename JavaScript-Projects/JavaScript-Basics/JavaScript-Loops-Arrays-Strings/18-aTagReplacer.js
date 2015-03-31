function replaceATag(input) {
    // replacing the closing tag and the beginning of the opening one
    var result = input.replace("<a", "[URL").replace("</a>", "[/URL]");
    // finding the index of the first "<" character after the opening "URL" tag
    var index = result.indexOf(">", result.indexOf("[URL"));
    // replacing it with "]"
    result = result.substring(0, index) + "]" + result.substring(index + 1);
    return result;
}
console.log(replaceATag("<ul><li><a href='http://softuni.bg'>SoftUni</a></li></ul>"));