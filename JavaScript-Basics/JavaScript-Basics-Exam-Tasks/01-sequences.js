function solve(args) {
    args.splice(0, 1);
    var result = 1;
    for (var i = 1; i < args.length; i++) {
        if (Number(args[i]) < Number(args[i - 1])) {
            result++;
        }
    }
    return result;
}