function processEstatesAgencyCommands(commands) {

    'use strict';

    Object.prototype.inherits = function(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    Object.prototype.validateNonEmptyString = function(value, variableName) {
        if (typeof (value) != 'string' || !value) {
            throw new Error(variableName + " should be non-empty string.");
        }
    };

    Object.prototype.validateIntegerRange = function(value, variableName, minValue, maxValue) {
        if (typeof (value) != 'number') {
            throw new Error(variableName + " should be a number.");
        }

        if (value !== parseInt(value, 10)) {
            throw new Error(variableName + " should be integer.");
        }

        if (value < minValue || value > maxValue) {
            throw new Error(variableName + " should be integer in the range [" +
                minValue + "..." + maxValue + "].");
        }
    };

    Object.prototype.validateBoolean = function(value, variableName) {
        if (typeof (value) != 'boolean') {
            throw new Error(variableName + " should be a boolean value.");
        }
    };

    Object.prototype.validateNonEmptyObject = function(value, className, variableName) {
        if (! (value instanceof className)) {
            throw new Error(variableName + " should be non-empty " +
                className.prototype.constructor.name + ".");
        }
    };

    var Estate = (function () {
        function Estate(name, area, location, isFurnitured) {
            if (this.constructor === Estate) {
                throw new Error('Estate is an abstract class.');
            }

            this.setName(name);
            this.setArea(area);
            this.setLocation(location);
            this.setIsFurnitured(isFurnitured);
        }

        Estate.prototype.getName = function() {
            return this._name;
        };

        Estate.prototype.setName = function(name) {
            this.validateNonEmptyString(name, 'name');
            this._name = name;
        };

        Estate.prototype.getArea = function() {
            return this._area;
        };

        Estate.prototype.setArea = function(area) {
            this.validateIntegerRange(area, 'area', 1, 10000);
            this._area = area;
        };

        Estate.prototype.getLocation = function() {
            return this._location;
        };

        Estate.prototype.setLocation = function(location) {
            this.validateNonEmptyString(location, 'location');
            this._location = location;
        };

        Estate.prototype.getIsFurnitured = function() {
            return this._isFurnitured;
        };

        Estate.prototype.setIsFurnitured = function(isFurnitured) {
            this.validateBoolean(isFurnitured, 'isFurnitured');
            this._isFurnitured = isFurnitured;
        };

        Estate.prototype.toString = function() {
            return this.constructor.name + ': Name = ' + this.getName() +
                ', Area = ' + this.getArea() + ', Location = ' + this.getLocation() +
                ', Furnitured = ' + (this.getIsFurnitured() ? 'Yes' : 'No');
        };

        return Estate;
    }());


    var BuildingEstate = (function() {
        function BuildingEstate(name, area, location, isFurnitured, rooms, hasElevator) {
            if (this.constructor === BuildingEstate) {
                throw new Error('BuildingEstate is an abstract class.');
            }
            
            Estate.apply(this, arguments);
            this.setRooms(rooms);
            this.setHasElevator(hasElevator);
        }

        BuildingEstate.inherits(Estate);
        
        BuildingEstate.prototype.getRooms = function() {
            return this._rooms;
        };
        
        BuildingEstate.prototype.setRooms = function(rooms) {
            this.validateIntegerRange(rooms, 'rooms', 1, 100);
            this._rooms = rooms;
        };       
        
        BuildingEstate.prototype.getHasElevator = function() {
            return this._hasElevator;
        };
        
        BuildingEstate.prototype.setHasElevator = function(hasElevator) {
            this.validateBoolean(hasElevator, 'hasElevator');
            this._hasElevator = hasElevator;
        };

        BuildingEstate.prototype.toString = function() {
            return Estate.prototype.toString.call(this) +
                ", Rooms: " + this.getRooms() + ", Elevator: " + (this.getHasElevator() ? 'Yes' : 'No');
        };

        return BuildingEstate;
    }());


    var Apartment = (function() {
        function Apartment(name, area, location, isFurnitured, rooms, hasElevator) {
            BuildingEstate.apply(this, arguments);
        }

        Apartment.inherits(BuildingEstate);

        return Apartment;
    }());


    var Office = (function() {
        function Office(name, area, location, isFurnitured, rooms, hasElevator) {
            BuildingEstate.apply(this, arguments);
        }

        Office.inherits(BuildingEstate);

        return Office;
    }());


    var House = (function() {
        function House(name, area, location, isFurnitured, floors) {
            Estate.apply(this, arguments);
            this.setFloors(floors);
        }

        House.inherits(Estate);

        House.prototype.getFloors = function() {
            return this._floors;
        };

        House.prototype.setFloors = function(floors) {
            this.validateIntegerRange(floors, 'floors', 1, 10);
            this._floors = floors;
        };

        House.prototype.toString = function() {
            return Estate.prototype.toString.call(this) + ", Floors: " + this.getFloors();
        };

        return House;
    }());


    var Garage = (function() {
        function Garage(name, area, location, isFurnitured, width, height) {
            Estate.apply(this, arguments);
            this.setWidth(width);
            this.setHeight(height);
        }

        Garage.inherits(Estate);

        Garage.prototype.getWidth = function() {
            return this._width;
        };

        Garage.prototype.setWidth = function(width) {
            this.validateIntegerRange(width, 'width', 1, 500);
            this._width = width;
        };

        Garage.prototype.getHeight = function() {
            return this._height;
        };

        Garage.prototype.setHeight = function(height) {
            this.validateIntegerRange(height, 'height', 1, 500);
            this._height = height;
        };

        Garage.prototype.toString = function() {
            return Estate.prototype.toString.call(this) +
                ", Width: " + this.getWidth() + ", Height: " + this.getHeight();
        };

        return Garage;
    }());


    var Offer = (function() {
        function Offer(estate, price) {
            if (this.constructor === Offer) {
                throw new Error("Can't instantiate abstract class Offer.");
            }

            this.setEstate(estate);
            this.setPrice(price);
        }

        Offer.prototype.getEstate = function() {
            return this._estate;
        };

        Offer.prototype.setEstate = function(estate) {
            this.validateNonEmptyObject(estate, Estate, 'estate');
            this._estate = estate;
        };

        Offer.prototype.getPrice = function() {
            return this._price;
        };

        Offer.prototype.setPrice = function(price) {
            this.validateIntegerRange(price, 'price', 1, Number.POSITIVE_INFINITY);
            this._price = price;
        };

        Offer.prototype.toString = function() {
            return "Estate = " + this.getEstate().getName() +
                ", Location = " + this.getEstate().getLocation() +
                ", Price = " + this.getPrice();
        };

        return Offer;
    }());


    var RentOffer = (function() {
        function RentOffer(estate, price) {
            Offer.apply(this, arguments);
        }

        RentOffer.inherits(Offer);

        RentOffer.prototype.toString = function() {
            return 'Rent: ' + Offer.prototype.toString.call(this);
        };

        return RentOffer;
    }());


    var SaleOffer = (function() {
        function SaleOffer(estate, price) {
            Offer.apply(this, arguments);
        }

        SaleOffer.inherits(Offer);

        SaleOffer.prototype.toString = function() {
            return 'Sale: ' + Offer.prototype.toString.call(this);
        };

        return SaleOffer;
    }());


    var EstatesEngine = (function() {
        var _estates;
        var _uniqueEstateNames;
        var _offers;

        function initialize() {
            _estates = [];
            _uniqueEstateNames = {};
            _offers = [];
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
            case 'create':
                return executeCreateCommand(cmdArgs);
            case 'status':
                return executeStatusCommand();
            case 'find-sales-by-location':
                return executeFindSalesByLocationCommand(cmdArgs[0]);
            case 'find-rents-by-location':
                return executeFindRentsByLocationCommand(cmdArgs[0]);
            case 'find-rents-by-price':
                return executeFindRentsByPriceCommand(Number(cmdArgs[0]), Number(cmdArgs[1]));
            default:
                throw new Error('Unknown command: ' + cmdName);
            }
        }

        function executeCreateCommand(cmdArgs) {
            var objType = cmdArgs[0];
            switch (objType) {
            case 'Apartment':
                var apartment = new Apartment(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                addEstate(apartment);
                break;
            case 'Office':
                var office = new Office(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                addEstate(office);
                break;
            case 'House':
                var house = new House(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
                addEstate(house);
                break;
            case 'Garage':
                var garage = new Garage(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
                addEstate(garage);
                break;
            case 'RentOffer':
                var estate = findEstateByName(cmdArgs[1]);
                var rentOffer = new RentOffer(estate, Number(cmdArgs[2]));
                addOffer(rentOffer);
                break;
            case 'SaleOffer':
                estate = findEstateByName(cmdArgs[1]);
                var saleOffer = new SaleOffer(estate, Number(cmdArgs[2]));
                addOffer(saleOffer);
                break;
            default:
                throw new Error('Unknown object to create: ' + objType);
            }
            return objType + ' created.';
        }

        function parseBoolean(value) {
            switch (value) {
            case "true":
                return true;
            case "false":
                return false;
            default:
                throw new Error("Invalid boolean value: " + value);
            }
        }

        function findEstateByName(estateName) {
            for (var i = 0; i < _estates.length; i++) {
                if (_estates[i].getName() == estateName) {
                    return _estates[i];
                }
            }
            return undefined;
        }

        function addEstate(estate) {
            if (_uniqueEstateNames[estate.getName()]) {
                throw new Error('Duplicated estate name: ' + estate.getName());
            }
            _uniqueEstateNames[estate.getName()] = true;
            _estates.push(estate);
        }

        function addOffer(offer) {
            _offers.push(offer);
        }

        function executeStatusCommand() {
            var result = '', i;
            if (_estates.length > 0) {
                result += 'Estates:\n';
                for (i = 0; i < _estates.length; i++) {
                    result += "  " + _estates[i].toString() + '\n';
                }
            } else {
                result += 'No estates\n';
            }

            if (_offers.length > 0) {
                result += 'Offers:\n';
                for (i = 0; i < _offers.length; i++) {
                    result += "  " + _offers[i].toString() + '\n';
                }
            } else {
                result += 'No offers\n';
            }

            return result.trim();
        }

        function executeFindSalesByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function(offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof SaleOffer;
            });
            selectedOffers.sort(function(a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function(offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof RentOffer;
            });
            selectedOffers.sort(function(a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByPriceCommand(minPrice, maxPrice) {
            Object.prototype.validateIntegerRange(
                minPrice, "minPrice", Number.NEGATIVE_INFINITY, Number.POSITIVE_INFINITY);
            Object.prototype.validateIntegerRange(
                maxPrice, "maxPrice", Number.NEGATIVE_INFINITY, Number.POSITIVE_INFINITY);

            var selectedOffers = _offers.filter(function(offer) {
                return offer.getPrice() >= minPrice &&
                    offer.getPrice() <= maxPrice &&
                    offer instanceof RentOffer;
            });

            selectedOffers.sort(function(a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });

            selectedOffers.sort(function(a, b) {
                return a.getPrice() - b.getPrice();
            });

            return formatQueryResults(selectedOffers);
        }

        function formatQueryResults(offers) {
            var result = '';
            if (offers.length == 0) {
                result += 'No Results\n';
            } else {
                result += 'Query Results:\n';
                for (var i = 0; i < offers.length; i++) {
                    var offer = offers[i];
                    result += '  [Estate: ' + offer.getEstate().getName() +
                        ', Location: ' + offer.getEstate().getLocation() +
                        ', Price: ' + offer.getPrice() + ']\n';
                }
            }
            return result.trim();
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    EstatesEngine.initialize();
    commands.forEach(function(cmd) {
        if (cmd != '') {
            try {
                var cmdResult = EstatesEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();
}
