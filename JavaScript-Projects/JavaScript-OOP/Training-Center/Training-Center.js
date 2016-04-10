function processTrainingCenterCommands(commands) {
    
    'use strict';
    
    var trainingcenter = (function () {

        Object.prototype.inherits = function(parent) {
            this.prototype = Object.create(parent.prototype);
            this.prototype.constructor = this;
        };

        Object.prototype.validateObligatoryString = function(value, variableName) {
            if (typeof (value) != 'string' || !value) {
                throw new Error(variableName + " must be a be non-empty string.");
            }
        };

        Object.prototype.validateNonObligatoryString = function(value, variableName) {
            if (value !== undefined) {
                this.validateObligatoryString(value, variableName)
            }
        };

        Object.prototype.validateEmail = function(value) {
            if (value !== undefined) {
                this.validateObligatoryString(value, 'email');
                if (value.indexOf('@') < 0) {
                    throw new Error("The email must contain '@' when present.");
                }
            }
        };

        Object.prototype.validateNonObligatoryInteger = function(value, variableName, minValue, maxValue) {
            if (value !== undefined) {
                if (typeof (value) != 'number' || value !== parseInt(value, 10)) {
                    throw new Error(variableName + " should be an integer.");
                }

                if (value < minValue || value > maxValue) {
                    throw new Error(variableName + " should be an integer in the range [" +
                        minValue + "..." + maxValue + "].");
                }
            }
        };

        Object.prototype.validateDateBetweenTwoYears = function(date, startYear, endYear) {
            if (date === undefined) {
                throw new Error('The date is obligatory.');
            }

            if (date.getFullYear() < startYear || date.getFullYear() > endYear) {
                throw new Error('The year must be between 2000 and 2020.')
            }
        };
                
        var TrainingCenterEngine = (function () {
            
            var _trainers;
            var _uniqueTrainerUsernames;
            var _trainings;
            
            function initialize() {
                _trainers = [];
                _uniqueTrainerUsernames = {};
                _trainings = [];
            }
            
            function executeCommand(command) {
                var cmdParts = command.split(' ');
                var cmdName = cmdParts[0];
                var cmdArgs = cmdParts.splice(1);
                switch (cmdName) {
                    case 'create':
                        return executeCreateCommand(cmdArgs);
                    case 'list':
                        return executeListCommand();
                    case 'delete':
                        return executeDeleteCommand(cmdArgs);
                    default:
                        throw new Error('Unknown command: ' + cmdName);
                }
            }
            
            function executeCreateCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var createArgs = cmdArgs.splice(1).join(' ');
                var objectData = JSON.parse(createArgs);
                var trainer;
                switch (objectType) {
                    case 'Trainer':
                        trainer = new trainingcenter.Trainer(objectData.username, objectData.firstName, 
                            objectData.lastName, objectData.email);
                        addTrainer(trainer);
                        break;
                    case 'Course':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var course = new trainingcenter.Course(objectData.name, objectData.description, trainer,
                            parseDate(objectData.startDate), objectData.duration);
                        addTraining(course);
                        break;
                    case 'Seminar':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var seminar = new trainingcenter.Seminar(objectData.name, objectData.description, 
                            trainer, parseDate(objectData.date));
                        addTraining(seminar);
                        break;
                    case 'RemoteCourse':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var remoteCourse = new trainingcenter.RemoteCourse(objectData.name, objectData.description,
                            trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                        addTraining(remoteCourse);
                        break;
                    default:
                        throw new Error('Unknown object to create: ' + objectType);
                }
                return objectType + ' created.';
            }
            
            function findTrainerByUsername(username) {
                if (! username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].getUsername() == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }
            
            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.getUsername()]) {
                    throw new Error('Duplicated trainer: ' + trainer.getUsername());
                }
                _uniqueTrainerUsernames[trainer.getUsername()] = true;
                _trainers.push(trainer);
            }

            function addTraining(training) {
                _trainings.push(training);
            }
            
            function executeListCommand() {
                var result = '', i;
                if (_trainers.length > 0) {
                    result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
                } else {
                    result += 'No trainers\n';
                }
                
                if (_trainings.length > 0) {
                    result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
                } else {
                    result += 'No trainings\n';
                }
                
                return result.trim();
            }
            
            function executeDeleteCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var deleteArgs = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        removeTrainer(deleteArgs);
                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }

            function removeTrainer(trainerUsername) {
                if (!_uniqueTrainerUsernames[trainerUsername]) {
                    throw new Error('Unexciting trainer: ' + trainerUsername)
                }
                _uniqueTrainerUsernames[trainerUsername] = false;
                _trainers.splice(_trainers.indexOf(findTrainerByUsername(trainerUsername)), 1);
                _trainings.forEach(function(training) {
                    if (training.getTrainer() && training.getTrainer().getUsername() === trainerUsername) {
                        training.setTrainer(undefined);
                    }
                });
            }
            
            var trainingCenterEngine = {
                initialize: initialize,
                executeCommand: executeCommand
            };
            return trainingCenterEngine;
        }());

        var Trainer = (function() {
            function Trainer(username, firstName, lastName, email) {
                this.setUsername(username);
                this.setFirstName(firstName);
                this.setLastName(lastName);
                this.setEmail(email);
            }

            Trainer.prototype.getUsername = function() {
                return this._username;
            };

            Trainer.prototype.setUsername = function(username) {
                this.validateObligatoryString(username, 'username');
                this._username = username;
            };

            Trainer.prototype.getLastName = function() {
                return this._lastName;
            };

            Trainer.prototype.setLastName = function(lastName) {
                this.validateObligatoryString(lastName, 'lastName');
                this._lastName = lastName;
            };

            Trainer.prototype.getFirstName = function() {
                return this._firstName;
            };

            Trainer.prototype.setFirstName = function(firstName) {
                this.validateNonObligatoryString(firstName, 'firstName');
                this._firstName = firstName;
            };

            Trainer.prototype.getEmail = function() {
                return this._email;
            };

            Trainer.prototype.setEmail = function(email) {
                this.validateEmail(email);
                this._email = email;
            };

            Trainer.prototype.toString = function() {
                var result = this.constructor.name + '[username=' + this.getUsername();
                if (this.getFirstName()) {
                    result += ';first-name=' + this.getFirstName();
                }

                result += ';last-name=' + this.getLastName();
                if (this.getEmail()) {
                    result += ';email=' + this.getEmail();
                }

                result += ']';
                return result;
            };

            return Trainer;
        }());

        var Training = (function() {
            var MIN_YEAR = 2000;
            var MAX_YEAR = 2020;
            var MIN_DURATION = 1;
            var MAX_DURATION = 99;

            function Training(name, description, trainer, startDate, duration) {
                if (this.constructor === Training) {
                    throw new Error("Training is an abstract 'class'.");
                }

                this.setName(name);
                this.setDescription(description);
                this.setTrainer(trainer);
                this.setStartDate(startDate);
                this.setDuration(duration);
            }

            Training.prototype.getDuration = function() {
                return this._duration;
            };

            Training.prototype.setDuration = function(duration) {
                this.validateNonObligatoryInteger(duration, 'duration', MIN_DURATION, MAX_DURATION);
                this._duration = duration;
            };

            Training.prototype.getStartDate = function() {
                return this._startDate;
            };

            Training.prototype.setStartDate = function(startDate) {
                // there is validation for month and day in the engine
                this.validateDateBetweenTwoYears(startDate, MIN_YEAR, MAX_YEAR);
                this._startDate = startDate;
            };

            Training.prototype.getTrainer = function() {
                return this._trainer;
            };

            Training.prototype.setTrainer = function(trainer) {
                // there is validation in the engine
                this._trainer = trainer;
            };

            Training.prototype.getDescription = function() {
                return this._description;
            };

            Training.prototype.setDescription = function(description) {
                this.validateNonObligatoryString(description, 'description');
                this._description = description;
            };

            Training.prototype.getName = function() {
                return this._name;
            };

            Training.prototype.setName = function(name) {
                this.validateObligatoryString(name, 'name');
                this._name = name;
            };

            Training.prototype.toString = function() {
                var result = this.constructor.name + '[name=' + this.getName();
                if (this.getDescription()) {
                    result += ';description=' + this.getDescription();
                }
                if (this.getTrainer()) {
                    result += ';trainer=' + this.getTrainer().toString();
                }

                result += ';start-date=' + formatDate(this.getStartDate());

                if(this.getDuration()) {
                    result += ';duration=' + this.getDuration();
                }

                result += ']';
                return result;
            };

            return Training;
        }());

        var Course = (function() {
            function Course(name, description, trainer, startDate, duration) {
                Training.apply(this, arguments);
            }

            Course.inherits(Training);

            return Course;
        }());

        var Seminar = (function() {
            function Seminar(name, description, trainer, startDate, duration) {
                Training.apply(this, arguments);
            }

            Seminar.inherits(Training);

            Seminar.prototype.toString = function() {
                return Course.prototype.toString.call(this).replace('start-date', 'date');
            };

            return Seminar;
        }());

        var RemoteCourse = (function() {
            function RemoteCourse(name, description, trainer, startDate, duration, location) {
                Course.apply(this, arguments);
                this.setLocation(location);
            }

            RemoteCourse.inherits(Course);

            RemoteCourse.prototype.getLocation = function() {
                return this._location;
            };

            RemoteCourse.prototype.setLocation = function(location) {
                this.validateObligatoryString(location, 'location');
                this._location = location;
            };

            RemoteCourse.prototype.toString = function() {
                return Course.prototype.toString.call(this).slice(0, -1) + ';location=' + this.getLocation() + ']';
            };

            return RemoteCourse;
        }());

        var trainingcenter = {
            Trainer: Trainer,
            Course: Course,
            Seminar: Seminar,
            RemoteCourse: RemoteCourse,
            engine: {
                TrainingCenterEngine: TrainingCenterEngine
            }
        };
        
        return trainingcenter;
    })();
    
    
    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    };
    
    
    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    };
    
    
    // Process the input commands and return the results
    var results = '';
    trainingcenter.engine.TrainingCenterEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err.stack);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();
}
