function processRestaurantManagerCommands(commands) {
    'use strict';

    var RestaurantEngine = (function () {
        var _restaurants, _recipes;

        function initialize() {
            _restaurants = [];
            _recipes = [];
        }

        Object.prototype.inherits = function(parent) {
            this.prototype = Object.create(parent.prototype);
            this.prototype.constructor = this;
        };

        Object.prototype.validateNonEmptyString = function(value, variableName) {
            if (typeof (value) != 'string' || !value) {
                throw new Error('The ' + variableName + ' is required.');
            }
        };

        Object.prototype.validatePositiveNumber = function(value, variableName) {
            if (typeof (value) != 'number') {
                throw new Error(variableName + " should be a number.");
            }

            if (value <= 0) {
                throw new Error('The ' + variableName + ' must be positive.');
            }
        };

        Object.prototype.validateBoolean = function(value, variableName) {
            if (typeof (value) != 'boolean') {
                throw new Error(variableName + " should be a boolean value.");
            }
        };

        Object.prototype.validateObjectFromClass = function(value, className, variableName) {
            if (! (value instanceof className)) {
                throw new Error(variableName + " should be non-empty " +
                    className.prototype.constructor.name + ".");
            }
        };

        var Restaurant = (function() {
            function Restaurant(name, location) {
                this.setName(name);
                this.setLocation(location);
                this._recipeList = [];
            }

            Restaurant.prototype.addRecipe = function(recipe) {
                this.validateObjectFromClass(recipe, Recipe, 'recipe');
                this._recipeList.push(recipe);
            };

            Restaurant.prototype.removeRecipe = function(recipe) {
                if (this._recipeList.indexOf(recipe) !== -1) {
                    this._recipeList.splice(this._recipeList.indexOf(recipe), 1);
                }
            };

            Restaurant.prototype.getName = function() {
                return this._name;
            };

            Restaurant.prototype.setName = function(name) {
                this.validateNonEmptyString(name, 'name');
                this._name = name;
            };

            Restaurant.prototype.getLocation = function() {
                return this._location;
            };

            Restaurant.prototype.setLocation = function(location) {
                this.validateNonEmptyString(location, 'location');
                this._location = location;
            };

            Restaurant.prototype.printRestaurantMenu = function() {
                var result = '***** ' + this.getName() + ' - ' + this.getLocation() + ' *****';
                if (this._recipeList.length === 0) {
                    return result + '\nNo recipes... yet\n';
                }
                
                var drinks = [],
                    salads = [],
                    mains = [],
                    desserts = [];
                
                this._recipeList.forEach(function (recipe) {
                    if (recipe instanceof Drink) {
                        drinks.push(recipe);
                    } else if (recipe instanceof Salad) {
                        salads.push(recipe);
                    } else if (recipe instanceof MainCourse) {
                        mains.push(recipe);
                    } else if (recipe instanceof Dessert) {
                        desserts.push(recipe);
                    }
                });
                
                function sorter (a, b) {
                    return a.getName().localeCompare(b.getName());
                }
                
                if (drinks.length > 0) {
                    drinks.sort(sorter);
                    result += '\n~~~~~ DRINKS ~~~~~';
                    drinks.forEach(function(drink) {
                        result += '\n' + drink.toString();
                    });
                }

                if (salads.length > 0) {
                    salads.sort(sorter);
                    result += '\n~~~~~ SALADS ~~~~~';
                    salads.forEach(function(salad) {
                        result += '\n' + salad.toString();
                    });
                }

                if (mains.length > 0) {
                    mains.sort(sorter);
                    result += '\n~~~~~ MAIN COURSES ~~~~~';
                    mains.forEach(function(main) {
                        result += '\n' + main.toString();
                    });
                }

                if (desserts.length > 0) {
                    desserts.sort(sorter);
                    result += '\n~~~~~ DESSERTS ~~~~~';
                    desserts.forEach(function(dessert) {
                        result += '\n' + dessert.toString();
                    });
                }

                return result + '\n';
            };

            return Restaurant;
        }());

        var Recipe = (function() {
            function Recipe(name, price, calories, quantity, unit, time) {
                if (this.constructor === Recipe) {
                    throw new Error('Recipe is an abstract class.');
                }

                this.setName(name);
                this.setPrice(price);
                this.setCalories(calories);
                this.setQuantity(quantity);
                this.setUnit(unit);
                this.setTime(time);
            }

            Recipe.prototype.getName = function() {
                return this._name;
            };

            Recipe.prototype.setName = function(name) {
                this.validateNonEmptyString(name, 'name');
                this._name = name;
            };
            
            Recipe.prototype.getPrice = function() {
                return this._price;
            };
            
            Recipe.prototype.setPrice = function(price) {
                this.validatePositiveNumber(price, 'price');
                this._price = price;
            };
            
            Recipe.prototype.getCalories = function() {
                return this._calories;
            };
            
            Recipe.prototype.setCalories = function(calories) {
                this.validatePositiveNumber(calories, 'calories');
                this._calories = calories;
            };
            
            Recipe.prototype.getQuantity = function() {
                return this._quantity;
            };
            
            Recipe.prototype.setQuantity = function(quantity) {
                this.validatePositiveNumber(quantity, 'quantity');
                this._quantity = quantity;
            };
            
            Recipe.prototype.getUnit = function() {
                return this._unit;
            };
            
            Recipe.prototype.setUnit = function(unit) {
                this._unit = unit;
            };

            Recipe.prototype.getTime = function() {
                return this._time;
            };

            Recipe.prototype.setTime = function (time) {
                time = Number(time);
                this.validatePositiveNumber(time, 'time');
                this._time = time;
            };

            Recipe.prototype.toString = function() {
                return '==  ' + this.getName() + ' == $' + this.getPrice().toFixed(2) + '\n' +
                    'Per serving: ' + this.getQuantity() + ' ' + this.getUnit() +
                    ', ' + this.getCalories() + ' kcal\n' + 'Ready in ' + this.getTime() + ' minutes';
            };

            return Recipe;
        }());

        var Drink = (function() {
            function Drink(name, price, calories, quantity, time, isCarbonated) {
                if (calories > 100) {
                    throw new Error('The drink calories cannot be more than 100.')
                }

                if (time > 20) {
                    throw new Error('The drink time cannot be more than 20.')
                }

                Recipe.call(this, name, price, calories, quantity, 'ml', time);
                this.setIsCarbonated(isCarbonated);
            }

            Drink.inherits(Recipe);

            Drink.prototype.getIsCarbonated = function() {
                return this._isCarbonated;
            };

            Drink.prototype.setIsCarbonated = function(isCarbonated) {
                this.validateBoolean(isCarbonated, 'isCarbonated');
                this._isCarbonated = isCarbonated;
            };

            Drink.prototype.toString = function() {
                return Recipe.prototype.toString.call(this) +
                    '\nCarbonated: ' + (this.getIsCarbonated() ? 'yes' : 'no');
            };

            return Drink;
        }());

        var Meal = (function() {
            function Meal(name, price, calories, quantity, time, isVegan) {
                if (this.constructor === Meal) {
                    throw new Error('Meal is an abstract class.');
                }

                Recipe.call(this, name, price, calories, quantity, 'g', time);
                this.setIsVegan(isVegan);
            }

            Meal.inherits(Recipe);

            Meal.prototype.getIsVegan = function() {
                return this._isVegan;
            };

            Meal.prototype.setIsVegan = function(isVegan) {
                //isVegan = parseBoolean(isVegan);
                this.validateBoolean(isVegan, 'isVegan');
                this._isVegan = isVegan;
            };

            Meal.prototype.toggleVegan = function() {
                this.setIsVegan(!this.getIsVegan());
            };

            Meal.prototype.toString = function() {
                return (this.getIsVegan() ? '[VEGAN] ' : '') + Recipe.prototype.toString.call(this);
            };

            return Meal;
        }());

        var Dessert = (function() {
            function Dessert(name, price, calories, quantity, time, isVegan) {
                Meal.apply(this, arguments);
                this.setHasSugar(true);
            }

            Dessert.inherits(Meal);
            
            Dessert.prototype.getHasSugar = function() {
                return this._hasSugar;
            };
            
            Dessert.prototype.setHasSugar = function(hasSugar) {
                this.validateBoolean(hasSugar, 'hasSugar');
                this._hasSugar = hasSugar;
            };

            Dessert.prototype.toggleSugar = function() {
                this.setHasSugar(!this.getHasSugar());
            };

            Dessert.prototype.toString = function() {
                return (this.getHasSugar() ? '' : '[NO SUGAR] ') + Meal.prototype.toString.call(this);
            };

            return Dessert;
        }());

        var MainCourse = (function() {
            function MainCourse(name, price, calories, quantity, time, isVegan, type) {
                Meal.apply(this, arguments);
                this.setType(type);
            }
            
            MainCourse.inherits(Meal);

            MainCourse.prototype.getType = function() {
                return this._type;
            };

            MainCourse.prototype.setType = function(type) {
                this.validateNonEmptyString(type, 'type');
                this._type = type;
            };
            
            MainCourse.prototype.toString = function() {
                return Meal.prototype.toString.call(this) + '\nType: ' + this.getType();
            };
            
            return MainCourse;
        }());

        var Salad = (function() {
            function Salad(name, price, calories, quantity, time, hasPasta) {
                Meal.call(this, name, price, calories, quantity, time, true);
                this.setHasPasta(hasPasta);
            }

            Salad.inherits(Meal);

            Salad.prototype.getHasPasta = function() {
                return this._hasPasta;
            };

            Salad.prototype.setHasPasta = function(hasPasta) {
                this.validateBoolean(hasPasta, 'hasPasta');
                this._hasPasta = hasPasta;
            };

            Salad.prototype.toString = function() {
                return Meal.prototype.toString.call(this) +
                    '\nContains pasta: ' + (this.getHasPasta() ? 'yes' : 'no');
            };

            return Salad;
        }());

        var Command = (function () {

            function Command(commandLine) {
                this._params = [];
                this.translateCommand(commandLine);
            }

            Command.prototype.translateCommand = function (commandLine) {
                var self, paramsBeginning, name, parametersKeysAndValues;
                self = this;
                paramsBeginning = commandLine.indexOf("(");

                this._name = commandLine.substring(0, paramsBeginning);
                name = commandLine.substring(0, paramsBeginning);
                parametersKeysAndValues = commandLine
                    .substring(paramsBeginning + 1, commandLine.length - 1)
                    .split(";")
                    .filter(function (e) { return true });

                parametersKeysAndValues.forEach(function (p) {
                    var split = p
                        .split("=")
                        .filter(function (e) { return true; });
                    self._params[split[0]] = split[1];
                });
            };

            return Command;
        }());

        function createRestaurant(name, location) {
            _restaurants[name] = new Restaurant(name, location);
            return "Restaurant " + name + " created\n";
        }

        function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
            _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
            return "Recipe " + name + " created\n";
        }

        function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
            _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
            return "Recipe " + name + " created\n";
        }

        function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
            _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
            return "Recipe " + name + " created\n";
        }

        function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
            _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
            return "Recipe " + name + " created\n";
        }

        function toggleSugar(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            recipe = _recipes[name];

            if (recipe instanceof Dessert) {
                recipe.toggleSugar();
                return "Command ToggleSugar executed successfully. New value: " + recipe.getHasSugar().toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleSugar is not applicable to recipe " + name + "\n";
            }
        }

        function toggleVegan(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }

            recipe = _recipes[name];
            if (recipe instanceof Meal) {
                recipe.toggleVegan();
                return "Command ToggleVegan executed successfully. New value: " +
                    recipe._isVegan.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleVegan is not applicable to recipe " + name + "\n";
            }
        }

        function printRestaurantMenu(name) {
            var restaurant;

            if (!_restaurants.hasOwnProperty(name)) {
                throw new Error("The restaurant " + name + " does not exist");
            }

            restaurant = _restaurants[name];
            return restaurant.printRestaurantMenu();
        }

        function addRecipeToRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.addRecipe(recipe);
            return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
        }

        function removeRecipeFromRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.removeRecipe(recipe);
            return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
        }

        function executeCommand(commandLine) {
            var cmd, params, result;
            cmd = new Command(commandLine);
            params = cmd._params;

            switch (cmd._name) {
                case 'CreateRestaurant':
                    result = createRestaurant(params["name"], params["location"]);
                    break;
                case 'CreateDrink':
                    result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["carbonated"]));
                    break;
                case 'CreateSalad':
                    result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["pasta"]));
                    break;
                case "CreateMainCourse":
                    result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]), params["type"]);
                    break;
                case "CreateDessert":
                    result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]));
                    break;
                case "ToggleSugar":
                    result = toggleSugar(params["name"]);
                    break;
                case "ToggleVegan":
                    result = toggleVegan(params["name"]);
                    break;
                case "AddRecipeToRestaurant":
                    result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "RemoveRecipeFromRestaurant":
                    result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "PrintRestaurantMenu":
                    result = printRestaurantMenu(params["name"]);
                    break;
                default:
                    throw new Error('Invalid command name: ' + cmdName);
            }

            return result;
        }

        function parseBoolean(value) {
            switch (value) {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    RestaurantEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != "") {
            try {
                var cmdResult = RestaurantEngine.executeCommand(cmd);
                results += cmdResult;
            } catch (err) {
                results += err.message + "\n";
            }
        }
    });

    return results.trim();
}
