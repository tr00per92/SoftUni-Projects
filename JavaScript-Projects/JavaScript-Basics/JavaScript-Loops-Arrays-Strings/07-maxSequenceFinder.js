function findMaxSequence(input) {
    var result = [];
    var temp = [input[0]];
    for (var i = 1; i < input.length; i++) {
        if (input[i] > input[i - 1]) {
            temp.push(input[i]);
            if (temp.length >= result.length) {
                result = temp;
            }
        } else {
            temp = [input[i]];
        }
    }
    return result.length != 0 ? result : "no";
}
console.log(findMaxSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]));
console.log(findMaxSequence([3, 2, 1]));