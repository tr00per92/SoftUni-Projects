function createArray () {
    var result = [];
    for (var i = 0; i < 20; i++) {
        result[i] = i * 5;
    }
    return result;
}
console.log(createArray());