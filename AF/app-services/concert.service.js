(function () {
    'use strict';

    function concertService($http) {
        var service = {};

        service.getConcerts = function (callback) {
            return $http.get(`${serviceUrl}concerts`).success(function (data) {
                if (callback) callback(data);
            });
        }
        service.getAllConcerts = function (id, callback) {
            return $http.get(`${serviceUrl}concerts/all/${id}`).success(function (data) {
                if (callback) callback(data);
            });
        }
        service.getConcert = function (id, callback) {
            return $http.get(`${serviceUrl}concerts/${id}`).success(function (data) {
                if (callback) callback(data);
            });
        }
        service.getSchedules = function (id, callback) {
            return $http.get(`${serviceUrl}concerts/schedule/${id}`).success(function (data) {
                if (callback) callback(data);
            });
        }
        service.getProgramms = function (id, callback) {
            return $http.get(`${serviceUrl}concerts/programm/${id}`).success(function (data) {
                if (callback) callback(data);
            });
        }
        service.getSeries = function (callback) {
            return $http.get(`${serviceUrl}concerts/series`).success(function (data) {
                if (callback) callback(data);
            });
        }
        service.getGroups = function (callback) {
            return $http.get(`${serviceUrl}concerts/groups`).success(function (data) {
                if (callback) callback(data);
            });
        }
        service.getHalls = function (id) {
            return $http.get(`${serviceUrl}concerts/halls/${id}`);
        }
        service.getExist = function (id, callback) {
            return $http.get(`${serviceUrl}concerts/exist/${id}`).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveConcert = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/add`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveProgramms = function (id, models, callback) {
            return $http.post(`${serviceUrl}concerts/programm/${id}`, models).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveProgramm = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/programm/save`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveSchedule = function (id, model, callback) {
            return $http.post(`${serviceUrl}concerts/schedule/${id}`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveConcertPlace = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/concertplace/save`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveHall = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/hall/save`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveTickets = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/tickets/save`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveActorGroup = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/group/save`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveActor = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/actor/save`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        return service;;
    }

    angular
        .module('app')
        .factory('concertService', concertService);

    concertService.$inject = ['$http'];
})();
