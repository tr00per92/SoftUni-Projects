function sortArray(input) {
    var result = [];
    for (var i = 0; i < input.length; i++) {
        var min = Math.min.apply(Math, input);
        result.push(min);
        input[input.indexOf(min)] = Number.MAX_VALUE;
    }
    return result;
}
console.log(sortArray([5, 4, 3, 2, 1]));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]));