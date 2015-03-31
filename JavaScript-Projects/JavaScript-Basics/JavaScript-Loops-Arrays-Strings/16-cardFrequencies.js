function findCardFrequency(input) {
    var cards = input.split(' ');
    var result = [];
    // I use associative array -> the key is the card and the value is the card's count
    for (var i = 0; i < cards.length; i++) {
        var card = cards[i].substring(0, cards[i].length - 1);
        if (result[card]) {
            result[card]++;
        } else {
            result[card] = 1;
        }
    }
    // with for-in loop the results don't appear in the same order as in the input
    // so I loop through the initial array and print every element only once
    var printed = [];
    for (var j = 0; j < cards.length; j++) {
        var current = cards[j].substring(0, cards[j].length - 1);
        if (printed.indexOf(current) < 0) {
            printed.push(current);
            console.log("%s -> %s%", current, (result[current] / cards.length * 100).toFixed(2));
        }
    }
}
findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findCardFrequency('10♣ 10♥');