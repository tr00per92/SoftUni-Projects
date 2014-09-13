function solve(args) {
    var nums = [];
    var brackets = false;
    for (var i = 0; i < args.length; i++) {
        if (args[i] == '(') {
            brackets = true;
            var current = '';
        } else if (args[i] == ')') {
            brackets = false;
            nums.push(Number(current));
        } else if (brackets) {
            current += args[i];
        }
    }
    var result = 1;
    var seq = 0;
    var nextOdd = nums[0] % 2 != 0;
    for (var j = 0; j < nums.length; j++) {
        var odd = nums[j] % 2 != 0;
        if (odd == nextOdd || nums[j] == 0) {
            seq++;
        } else {
            nextOdd = odd;
            seq = 1;
        }
        nextOdd = !nextOdd;
        result = Math.max(result, seq);
    }
    console.log(result);
    return result;
}
solve('(3) (22) (-18) (55) (44) (3) (21)');
solve('(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)');
solve('  ( 2 )  ( 33 ) (1) (4)   (  -1  ) ');
solve('(102)(103)(0)(105)  (107)(1)');
solve('(2) (2) (2) (2) (2)');