(function () {
    'use strict';

    function personService($http, $rootScope) {
        var service = {};

        function getTypes() {
            if (!$rootScope.descriptiontypes) {
                $rootScope.descriptiontypes = [];
                $http.get(`${apiUrl}persons/description/types`).success(function (data) {
                    $rootScope.descriptiontypes.push.apply($rootScope.descriptiontypes, data);
                });
            }
            if (!$rootScope.facttypes) {
                $rootScope.facttypes = [];
                $http.get(`${apiUrl}persons/fact/types`).success(function (data) {
                    $rootScope.facttypes.push.apply($rootScope.facttypes, data);
                });
            }
            if (!$rootScope.connectiontypes) {
                $rootScope.connectiontypes = [];
                $http.get(`${apiUrl}persons/connection/types`).success(function (data) {
                    $rootScope.connectiontypes.push.apply($rootScope.connectiontypes, data);
                });
            }
            if (!$rootScope.mediatypes) {
                $rootScope.mediatypes = [];
                $http.get(`${apiUrl}persons/media/types`).success(function (data) {
                    $rootScope.mediatypes.push.apply($rootScope.mediatypes, data);
                });
            }
            if (!$rootScope.socialtypes) {
                $rootScope.socialtypes = [];
                $http.get(`${apiUrl}persons/social/types`).success(function (data) {
                    $rootScope.socialtypes.push.apply($rootScope.socialtypes, data);
                });
            }
            if (!$rootScope.antronames) {
                $rootScope.antronames = [];
                $http.get(`${apiUrl}persons/antro/names`).success(function (data) {
                    $rootScope.antronames.push.apply($rootScope.antronames, data);
                });
            }
            if (!$rootScope.eventlist) {
                $rootScope.eventlist = [];
                $http.get(`${apiUrl}events`).success(function (data) {
                    $rootScope.eventlist.push.apply($rootScope.eventlist, data);
                });
            }
        }

        function getPersons() {
            $http.get(`${apiUrl}persons`).success(function (data) {
                $rootScope.menuScope = [];
                $rootScope.persons = data;
                $rootScope.persons.forEach(function (item) {
                    $rootScope.menuScope.push({
                        id: item.Id,
                        name: {
                            firstName: item.Name,
                            lastName: item.LastName,
                            middleName: item.Patronymic
                        },
                        nameTranslated: {
                            firstName: item.NameLatin,
                            lastName: item.LastNameLatin,
                            middleName: item.PatronymicLatin
                        },
                        type: item.EventType,
                        event: item.EventName
                    });
                });
            });
        }

        service.getTypes = getTypes;
        service.getPersons = getPersons;

        return service;;
    }

    angular
        .module('app')
        .factory('personService', personService);

    personService.$inject = ['$http', '$rootScope'];
})();
