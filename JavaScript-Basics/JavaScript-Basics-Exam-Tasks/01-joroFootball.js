function solve(args) {
    var result = Number(args[2]) + (52 - Number(args[2])) * (2 / 3) + Number(args[1] * 0.5);
    if (args[0] == 't') result += 3;
    return Math.floor(result);
}