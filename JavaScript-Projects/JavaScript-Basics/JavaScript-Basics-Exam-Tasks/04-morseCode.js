function solve(args) {
    args = String(args[0]);
    var nSum = 0;
    for (var i = 0; i < args.length; i++) {
        nSum += Number(args[i]);
    }
    var result = '';
    for (var i1 = 0; i1 <= 5; i1++) {
        for (var i2 = 0; i2 <= 5; i2++) {
            for (var i3 = 0; i3 <= 5; i3++) {
                for (var i4 = 0; i4 <= 5; i4++) {
                    for (var i5 = 0; i5 <= 5; i5++) {
                        for (var i6 = 0; i6 <= 5; i6++) {
                            if (i1 * i2 * i3 * i4 * i5 * i6 == nSum) {
                                switch (i1) {
                                    case 0: result += '-----|'; break;
                                    case 1: result += '.----|'; break;
                                    case 2: result += '..---|'; break;
                                    case 3: result += '...--|'; break;
                                    case 4: result += '....-|'; break;
                                    case 5: result += '.....|'; break;
                                }
                                switch (i2) {
                                    case 0: result += '-----|'; break;
                                    case 1: result += '.----|'; break;
                                    case 2: result += '..---|'; break;
                                    case 3: result += '...--|'; break;
                                    case 4: result += '....-|'; break;
                                    case 5: result += '.....|'; break;
                                }
                                switch (i3) {
                                    case 0: result += '-----|'; break;
                                    case 1: result += '.----|'; break;
                                    case 2: result += '..---|'; break;
                                    case 3: result += '...--|'; break;
                                    case 4: result += '....-|'; break;
                                    case 5: result += '.....|'; break;
                                }
                                switch (i4) {
                                    case 0: result += '-----|'; break;
                                    case 1: result += '.----|'; break;
                                    case 2: result += '..---|'; break;
                                    case 3: result += '...--|'; break;
                                    case 4: result += '....-|'; break;
                                    case 5: result += '.....|'; break;
                                }
                                switch (i5) {
                                    case 0: result += '-----|'; break;
                                    case 1: result += '.----|'; break;
                                    case 2: result += '..---|'; break;
                                    case 3: result += '...--|'; break;
                                    case 4: result += '....-|'; break;
                                    case 5: result += '.....|'; break;
                                }
                                switch (i6) {
                                    case 0: result += '-----|'; break;
                                    case 1: result += '.----|'; break;
                                    case 2: result += '..---|'; break;
                                    case 3: result += '...--|'; break;
                                    case 4: result += '....-|'; break;
                                    case 5: result += '.....|'; break;
                                }
                                result += '\n';
                            }
                        }
                    }
                }
            }
        }
    }
    console.log(result ? result.trim() : 'No');
}
solve(['1000']);
solve(['1001']);
solve(['1231']);