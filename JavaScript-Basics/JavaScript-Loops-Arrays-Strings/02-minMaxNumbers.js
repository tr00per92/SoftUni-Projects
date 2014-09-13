function findMinAndMax(input) {
    var min = Number.MAX_VALUE;
    var max = -Number.MAX_VALUE;
    for (var i = 0; i < input.length; i++) {
        var currentNum = input[i];
        if (currentNum > max) {
            max = currentNum;
        } else if (currentNum < min) {
            min = currentNum;
        }
    }
    console.log("Min -> %s", min);
    console.log("Max -> %s", max);
}
findMinAndMax([1,2,1,15,20,5,7,31]);
findMinAndMax([2,2,2,2,2]);
findMinAndMax([500,1,-23,0,-300,28,35,12]);