function solve(args) {
    var result = [];
    var words = [];
//    words = args.match(/[A-Za-z]+/g);
    words = args.split(/[^A-Za-z]+/);
    console.log(words);
    for (var i = 0; i < words.length; i++) {
        for (var j = 0; j < words.length; j++) {
            if (i == j) continue;
            for (var k = 0; k < words.length; k++) {
                if (k == j || k == i) continue;
                if (words[i] + words[j] == words[k]) {
                    var curr = words[i] + '|' + words[j] + '=' + words[k];
                    if (result.indexOf(curr) < 0) {
                        result.push(curr);
                    }
                }
            }
        }
    }
    if (result.length == 0) return 'No';
    return result.join('\n');
}
solve('java..?|basics/*-+=javabasics');
solve('Hi, Hi, Hihi');
solve('Uni(lo,.ve=I love SoftUni (Soft)');
solve('a a aa a');
solve('x a ab b aba a hello+java a b aaaaa');
solve('aa bb bbaa');
solve('То""ва е Ки ри ли ца + Това това еКи Рили лица');