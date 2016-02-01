'use strict';

var specialConsole = function specialConsoleFunc() {
    function replacePlaceholders(args) {
        var msg = args[0];

        if (args.length > 1) {
            var placeholder = 0;
            while (msg.indexOf('{' + placeholder + '}') >= 0) {
                var replacement = args[placeholder + 1] != undefined ? args[placeholder + 1] : '';
                msg = msg.replace('{' + placeholder + '}', replacement);
                placeholder++;
            }
        }
        
        return msg;
    }

    function writeLine() {
        var msg = replacePlaceholders(arguments);
        console.log(msg);
    }
    
    function writeError() {
        var msg = replacePlaceholders(arguments);
        console.error(msg);
    }

    function writeWarning() {
        var msg = replacePlaceholders(arguments);
        console.warn(msg);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
}();

specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Message: {0} {1} {2} {3}", "hello", "what's", "up");
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");
