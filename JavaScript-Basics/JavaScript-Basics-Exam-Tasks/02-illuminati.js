function solve(args) {
    var count = 0;
    var sum = 0;
    var input = args.toString().toUpperCase();
    for (var i = 0; i < input.length; i++) {
        switch (input[i]) {
            case 'A': count++; sum += 65; break;
            case 'E': count++; sum += 69; break;
            case 'I': count++; sum += 73; break;
            case 'O': count++; sum += 79; break;
            case 'U': count++; sum += 85; break;
        }
    }
    return count + '\n' + sum;
}