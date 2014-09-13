function solve(input) {
//    input.splice(0, 1);
    var result = [];
    for (var i = 1; i <= input[0]; i++) {
        var current = input[i].split(' ');
        var person = current[1];
        var duration = Number(current[2]);
        var ip = current[0];
        if (result[person]) {
            result[person][0] += duration;
            if (result[person][1].indexOf(ip) < 0) {
                result[person][1].push(ip);
            }
        } else {
            result[person] = [duration, [ip]];
        }
        result[person][1].sort();
    }
    var sortedNames = [];
    for (var key in result) {
        sortedNames.push(key);
    }
    sortedNames.sort();
    var print = '';
    for (var j = 0; j < sortedNames.length; j++) {
        print += sortedNames[j] + ': ' + result[sortedNames[j]][0] + ' ';
        print += '[' + result[sortedNames[j]][1].join(', ') + ']' + '\n';
    }
    console.log(print.trim());
}
solve(['7',
    '192.168.0.11 peter 33',
    '10.10.17.33 alex 12',
    '10.10.17.35 peter 30',
    '10.10.17.34 peter 120',
    '10.10.17.34 peter 120',
    '212.50.118.81 alex 46',
    '212.50.118.81 alex 4']);
solve(['2',
    '84.238.140.178 nakov 25',
    '84.238.140.178 nakov 35']);
solve(['4',
    '10.10.10.10 root 46',
    '8.8.8.8 root 167',
    '1.2.3.4 root 120',
    '5.6.7.8 root 970',
    '192.168.0.11 root 55']);