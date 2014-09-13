function solve(a) {
    var result = 0;
    for (var count1 = 0; count1 <= (a / 4) + 1; count1++) {
        for (var count2 = 0; count2 <= (a / 10) + 1; count2++) {
            for (var count3 = 0; count3 <= (a / 3) + 1; count3++) {
                var all = (count1 * 4) + (count2 * 10) + (count3 * 3);
                if (all == a) {
//                    console.log(count1, count2, count3);
                    result++;
                }
            }
        }
    }
    return result;
}