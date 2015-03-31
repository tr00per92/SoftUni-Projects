function soothsayer(value) {
    return [value[0][Math.floor(Math.random() * 4)], value[1][Math.floor(Math.random() * 4)],
            value[2][Math.floor(Math.random() * 4)], value[3][Math.floor(Math.random() * 4)]];
}

var result = soothsayer([[3, 5, 2, 7, 9], ["Java", "Python", "C#", "JavaScript", "Ruby"],
                        ["Silicon Valley", "London", "Las Vegas", "Paris", "Sofia"],
                        ["BMW", "Audi", "Lada", "Skoda", "Opel"]]);

console.log("You will work %s years on %s.", result[0], result[1]);
console.log("You will live in %s and drive %s.", result[2], result[3]);