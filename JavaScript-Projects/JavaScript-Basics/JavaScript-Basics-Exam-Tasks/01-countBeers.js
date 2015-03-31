function solve(args) {
    var stacks = 0;
    var beers = 0;
    for (var i = 0; i < args.length - 1; i++) {
        var current = args[i].split(" ");
        switch (current[1]) {
            case "beers": beers += Number(current[0]); break;
            case "stacks": stacks += Number(current[0]); break;
        }
    }
    while (beers >= 20) {
        stacks += 1;
        beers -= 20;
    }
    return stacks + " stacks + " + beers + " beers";
}