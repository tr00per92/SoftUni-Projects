function solve(args) {
    args = args.map(Number);
    var s = args[0], d = args[1];
    var mel = 0, wat = 0;
    for (var i = 0; i < d; i++) {
        switch (s) {
            case 1: wat++; break;
            case 2: mel+=2; break;
            case 3: wat++; mel++; break;
            case 4: wat+=2; break;
            case 5: wat+=2; mel+=2; break;
            case 6: wat++; mel+=2; break;
        }
        s++;
        if (s > 7) s = 1;
    }
    if (mel == wat) {
        console.log('Equal amount: ' + mel);
    } else if (mel > wat) {
        console.log(mel-wat + ' more melons');
    }else if (wat > mel) {
        console.log(wat-mel + ' more watermelons');
    }
}
solve(['3', '3']);