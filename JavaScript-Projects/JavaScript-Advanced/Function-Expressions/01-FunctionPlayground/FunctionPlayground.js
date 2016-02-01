'use strict';

function myFunction() {
    console.log('Number of arguments: ' + arguments.length);
    var argumentsTypes = [];
    for (var i in arguments) {
        argumentsTypes.push(typeof(arguments[i]));
    }
    console.log('Arguments types: ' + argumentsTypes.join(', '));
    console.log(this);
}

myFunction(3, "peshkata", true, 45, []);
myFunction.call("I am the object", "gogo");
myFunction.apply({ Name: "ivan", Age: 38 }, [false, 3.14]);
