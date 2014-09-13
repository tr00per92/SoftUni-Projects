function solve(words) {
    words = words[0].split(' ');
    var longest = 0;
    var result = '';
    var i, j;
    for (i = 0; i < words.length; i++) {
        longest = Math.max(longest, words[i].length)
    }
    for (i = 0; i < longest; i++) {
        for (j = 0; j < words.length; j++) {
            result += words[j].slice(-1);
            words[j] = words[j].slice(0, -1);
        }
    }
    for (i = 0; i < result.length; i++) {
        var position = result.toUpperCase().charCodeAt(i) - 64;
        while (position >= result.length - i) {
            position -= result.length;
        }
        position += i;
//        console.log(position);
        var current = result[i];
        result = result.slice(0, i) + result.slice(i + 1);
        result = result.slice(0, position) + current + result.slice(position);
//        console.log(result);
    }
    console.log(result);
}
solve(['Fun exam right']);
solve(['Hi exam']);