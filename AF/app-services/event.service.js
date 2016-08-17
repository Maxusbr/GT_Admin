(function () {
    'use strict';

    function eventService($http, $rootScope) {
        var service = {};

        service.getEvent = function (id, callback) {
            return $http.get(`${serviceUrl}events/${id}`)
                .success(function (data) { callback(data); })
                .error(function (data) { callback(data); });
        }

        service.getCountes = function (id, callback) {
            return $http.get(`${serviceUrl}events/counts/${id}`)
                .success(function (data) { callback(data); })
                .error(function (data) { callback(data); });
        }

        service.getCategories = function (callback) {
            return $http.get(`${serviceUrl}events/categories`)
                .success(function (data) { callback(data); })
                .error(function (data) { callback(data); });
        }

        service.getEvents = function (callback) {
            return $http.get(`${serviceUrl}events`).success(function (data) {
                $rootScope.events = data;
                console.log("load events");
                if (callback) callback();
            }).error(function (data) {
                if (callback) callback(data);
            });
        };

        service.getMedia = function getMedia(id, callback) {
            return $http.get(`${serviceUrl}events/media/${id}`).success(function (data) {
                callback(data);
            });
        };
        service.getDescript = function getDescript(id, callback) {
            return $http.get(`${serviceUrl}events/description/${id}`).success(function (data) {
                callback(data);
            });
        };
        service.getConnection = function getConnection(id, callback) {
            return $http.get(`${serviceUrl}events/connection/${id}`).success(function (data) {
                callback(data);
            });
        }

        service.getTags = function (callback) {
            return $http.get(`${serviceUrl}events/tags`).success(function (data) {
                callback(data);
            });
        };
        service.getEventTags = function (id, callback) {
            return $http.get(`${serviceUrl}events/tags/${id}`).success(function (data) {
                callback(data);
            });
        };

        service.getTypes = function () {
            if (!$rootScope.descriptiontypes) {
                $rootScope.descriptiontypes = [];
                $http.get(`${serviceUrl}events/description/types`).success(function (data) {
                    $rootScope.descriptiontypes.push.apply($rootScope.descriptiontypes, data);
                });
            }
            if (!$rootScope.connectiontypes) {
                $rootScope.connectiontypes = [];
                $http.get(`${serviceUrl}events/connection/types`).success(function (data) {
                    $rootScope.connectiontypes.push.apply($rootScope.connectiontypes, data);
                });
            }
            if (!$rootScope.mediatypes) {
                $rootScope.mediatypes = [];
                $http.get(`${serviceUrl}events/media/types`).success(function (data) {
                    $rootScope.mediatypes.push.apply($rootScope.mediatypes, data);
                });
            }
            //if (!$rootScope.eventlist) {
            //    $rootScope.eventlist = [];
            //    $http.get(`${serviceUrl}events`).success(function (data) {
            //        $rootScope.eventlist.push.apply($rootScope.eventlist, data);
            //    });
            //}
        };


        service.saveEntities = function saveEntities(id, list, entity, callback) {
            return $http.post(`${serviceUrl}events/${entity}/update/${id}`, list).success(function (response) {
                if (response.status === 'success')
                    callback(list);
            });
        }
        service.deleteEntities = function deleteEntities(list, entity, callback) {
            return $http.post(`${serviceUrl}events/${entity}/delete`, list).success(function (response) {
                if (response.status === 'success')
                    callback(list);
            });
        }

        service.Save = function (event, callback) {
            var model = {
                Id: event.Id,
                Name: event.Name,
                
            }
            return $http.post(`${serviceUrl}events/add`, model).success(function (data) {
                callback(data);
            }).error(function (data) {
                callback(data);
            });
        }

        service.saveDescriptions = function saveDescriptions(model, callback) {
            return $http.post(`${serviceUrl}events/tags/save/description`, model).success(function (data) {
                callback(data);
            }).error(function (data) {
                callback(data);
            });
        }

        service.saveEventTags = function (id, model, callback) {
            return $http.post(`${serviceUrl}events/tags/save/${id}`, model).success(function (data) {
                callback(data);
            }).error(function (data) {
                callback(data);
            });
        };

        service.saveEntitiesTypes = function (list, entity, callback) {
            $http.post(`${serviceUrl}events/${entity}/updatetypes`, list).success(function (response) {
                if (response.status === 'success')
                    callback(list);
            });
        }
        return service;;
    }

    angular
        .module('app')
        .factory('eventService', eventService);

    eventService.$inject = ['$http', '$rootScope'];
})();
