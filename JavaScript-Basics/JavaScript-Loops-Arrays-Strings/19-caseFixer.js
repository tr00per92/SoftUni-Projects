function fixCasing(input) {
    var result = input.split("");
    var upcase = false;
    var lowcase = false;
    var mixcase = false;
    for (var i = 0; i < result.length; i++) {
        // checking for tags
        if (input.substr(i, 8) === "<upcase>") {
            i += 8;
            upcase = true;
        } else if (input.substr(i, 9) === "<lowcase>") {
            i += 9;
            lowcase = true;
        } else if (input.substr(i, 9) === "<mixcase>") {
            i += 9;
            mixcase = true;
        }
        // changing the letters when necessary
        if (upcase) {
            if (result[i] !== "<") {
                result[i] = result[i].toUpperCase();
            } else {
                upcase = false;
            }
        } else if (lowcase) {
            if (result[i] !== "<") {
                result[i] = result[i].toLowerCase();
            } else {
                lowcase = false;
            }
        } else if (mixcase) {
            if (result[i] !== "<") {
                if (Math.random() >= 0.5) {
                    result[i] = result[i].toLowerCase();
                } else {
                    result[i] = result[i].toUpperCase();
                }
            } else {
                mixcase = false;
            }
        }
    }
    // removing the tags
    result = result.join("");
    while (result.indexOf("<upcase>") != -1 || result.indexOf("<lowcase>") != -1 || result.indexOf("<mixcase>") != -1) {
        result = result.replace("<upcase>", "").replace("</upcase>", "")
                       .replace("<lowcase>", "").replace("</lowcase>", "")
                       .replace("<mixcase>", "").replace("</mixcase>", "");
    }
    // printing the result
    console.log(result);
}
fixCasing("We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>ANYTHING</lowcase> else.");