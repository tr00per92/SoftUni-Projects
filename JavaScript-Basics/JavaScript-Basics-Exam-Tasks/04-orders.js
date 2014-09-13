function solve(args) {
    args.splice(0, 1);
    var result = [];
    for (var i = 0; i < args.length; i++) {
        var current = args[i].split(" ");
        var person = current[0];
        var num = Number(current[1]);
        var fruit = current[2];
        if (result[fruit]) {
            if (result[fruit][person]) {
                result[fruit][person] += num;
            } else {
                result[fruit][person] = num;
            }
        } else {
            result[fruit] = [];
            result[fruit][person] = num;
        }
    }
    var print = '';
    for (var plod in result) {
        print += plod + ': ';
        var sortedNames = [];
        for (var human in result[plod]) {
            sortedNames.push(human);
        }
        sortedNames.sort();
        for (var j = 0; j < sortedNames.length; j++) {
            print += sortedNames[j] + " " + result[plod][sortedNames[j]] + ", ";
        }
        print = print.trim().slice(0, -1) + "\n";
    }
    return print;
}

//console.log(solve( ['steve 8 apples',
//                    'maria 3 bananas',
//                    'kiro 3 bananas',
//                    'kiro 9 apples',
//                    'maria 2 apples',
//                    'steve 4 apples',
//                    'kiro 1 bananas',
//                    'kiro 1 apples']));
//console.log(solve(['bob 3 whiskeys',
//                'kiro 1 beers',
//                'mimi 2 beers',
//                'alex 4 beers',
//                'alex 1 beers',
//                'kiro 1 vodkas',
//                'bob 10 beers']));