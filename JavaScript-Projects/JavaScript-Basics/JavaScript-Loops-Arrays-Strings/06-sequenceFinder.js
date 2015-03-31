function findMaxSequence(input) {
    var result = [];
    var temp = [];
    for (var i = 0; i < input.length; i++) {
        temp.push(input[i]);
        if (input[i] !== input[i + 1]) {
            if (temp.length >= result.length) {
                result = temp;
            }
            temp = [];
        }
    }
    return result;
}
console.log(findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]));
console.log(findMaxSequence(['happy']));
console.log(findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']));
console.log(findMaxSequence([2, 3, 5, 6, 7, 9]));