function printNumbers(n) {
    var result = [];
    for (var i = 1; i <= n; i++) {
        if (i % 4 !== 0 && i % 5 !== 0) {
            result.push(i);
        }
    }
    console.log(result.length != 0 ? result.join(', ') : "no");
}
printNumbers(20);
printNumbers(1);
printNumbers(13);