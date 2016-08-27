﻿(function () {
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

        service.saveConcert = function (model, callback) {
            return $http.post(`${serviceUrl}concerts/add`, model).success(function (data) {
                if (callback)
                    callback(data);
            }).error(function (data) {
                if (callback)
                    callback(data);
            });
        }
        service.saveProgramm = function (id, model, callback) {
            return $http.post(`${serviceUrl}concerts/programm/${id}`, model).success(function (data) {
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
        
        return service;;
    }

    angular
        .module('app')
        .factory('concertService', concertService);

    concertService.$inject = ['$http'];
})();
