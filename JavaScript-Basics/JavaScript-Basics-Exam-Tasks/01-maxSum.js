function solve(args) {
    args.splice(0, 1);
    var maxSum = -Number.MAX_VALUE;
    for (var i = 0; i < args.length; i++) {
        var sum = 0;
        for (var j = i; j < args.length; j++) {
            sum += Number(args[j]);
            maxSum = Math.max(sum, maxSum);
        }
    }
    return maxSum;
}
console.log(solve(['8','1','6','-9','4','4','-2','10','-1']));