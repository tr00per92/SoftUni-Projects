function solve(args) {
    var n = Number(args[0]);
    var lett = 0, num = 0, symb = 0;
    for (var i = 1; i <= n; i++) {
        var current = args[i].toUpperCase();
        for (var j = 0; j < current.length; j++) {
            if (current[j] == 0) {
                continue;
            }
            var char = current.charCodeAt(j);
            if (char >= 65 && char <= 90) {
                lett += (char - 64) * 10;
            } else if (char >= 48 && char <= 57) {
                num += Number(current[j]) * 20;
            } else {
                symb += 200;
            }
        }
    }
    console.log(lett);
    console.log(num);
    console.log(symb);
}
solve(['1', 'HIHIHIHHIHIHI  hihihihih HIHIHIHIHI ..............  8888	!!-=+__+888888']);