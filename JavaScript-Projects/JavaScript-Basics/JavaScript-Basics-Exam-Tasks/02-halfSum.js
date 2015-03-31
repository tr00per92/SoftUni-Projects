function solve(args) {
    args.splice(0, 1);
    var sum1 = 0, sum2 = 0;
    for (var i = 0; i < args.length / 2; i++) {
        sum1 += Number(args[i]);
        sum2 += Number(args[args.length - 1 - i]);
    }
    if (sum1 == sum2) {
        return "Yes, sum=" + sum1;
    } else {
        return "No, diff=" + Math.abs(sum1 - sum2);
    }
}