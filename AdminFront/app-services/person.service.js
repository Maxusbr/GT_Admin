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

        function getPersons(callback) {
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
                console.log("load persons");
                if (callback) callback();
            }).error(function(data) {
                if (callback) callback(data);
            });
        }

        function getLinks(id, callback) {
            $http.get(`${apiUrl}persons/social/${id}`).success(function(data) {
                callback(data);
            });
        }

        function getMedia(id, callback) {
            $http.get(`${apiUrl}persons/media/${id}`).success(function (data) {
                callback(data);
            });
        }

        function getDescript(id, callback) {
            $http.get(`${apiUrl}persons/description/${id}`).success(function (data) {
                callback(data);
            });
        }

        function getFact(id, callback) {
            $http.get(`${apiUrl}persons/fact/${id}`).success(function (data) {
                callback(data);
            });
        }

        function getConnection(id, callback) {
            $http.get(`${apiUrl}persons/connection/${id}`).success(function (data) {
                callback(data);
            });
        }

        function getAntro(id, callback) {
            $http.get(`${apiUrl}persons/antro/${id}`).success(function (data) {
                callback(data);
            });
        }

        function saveEntities(id, list, entity, callback) {
            $http.post(`${apiUrl}persons/${entity}/update/${id}`, list).success(function (response) {
                if (response.status === 'success')
                    callback(list);
            });
        }

        function deleteEntities(list, entity, callback) {
            $http.post(`${apiUrl}persons/${entity}/delete`, list).success(function (response) {
                if (response.status === 'success')
                    callback(list);
            });
        }

        function getCountries(name, callback) {
            $http.get(`${apiUrl}persons/country/${name}`).success(function (data) {
                callback(data);
            });
        }

        function getPlaces(name, callback) {
            $http.get(`${apiUrl}persons/place/${name}`).success(function (data) {
                callback(data);
            });
        }

        function save(person, callback) {
            var model = {
                Id: person.Id,
                Name: person.Name,
                LastName: person.LastName,
                Patronymic: person.Patronymic,
                Bithday: `${person.Bithday.getFullYear()}-${person.Bithday.getMonth()+1}-${person.Bithday.getDate()}`,
                NameLatin: person.NameLatin,
                LastNameLatin: person.LastNameLatin,
                PatronymicLatin: person.PatronymicLatin,
                IdBithplace: person.IdBithplace,
                Place: person.Place,
                Country: person.Country,
                IdSex: person.IdSex
            }
            return $http.post(`${apiUrl}persons/add`, model).success(function (data) {
                callback(data);
            }).error(function (data) {
                callback(data);
            });
        }

        function getTags(callback) {
            $http.get(`${apiUrl}persons/tags`).success(function (data) {
                callback(data);
            });
        }

        function getPersonTags(id, callback) {
            $http.get(`${apiUrl}persons/tags/${id}`).success(function (data) {
                callback(data);
            });
        }

        function saveDescriptions(model, callback) {
            return $http.post(`${apiUrl}persons/tags/save`, model).success(function (data) {
                callback(data);
            }).error(function (data) {
                callback(data);
            });
        }

        function savePersonTags(id, model, callback) {
            return $http.post(`${apiUrl}persons/tags/save/${id}`, model).success(function (data) {
                callback(data);
            }).error(function (data) {
                callback(data);
            });
        }
        service.getTags = getTags;
        service.getPersonTags = getPersonTags;

        service.getTypes = getTypes;
        service.getPersons = getPersons;

        service.getLinks = getLinks;
        service.getMedia = getMedia;
        service.getDescript = getDescript;
        service.getFact = getFact;
        service.getConnection = getConnection;
        service.getAntro = getAntro;

        service.saveEntities = saveEntities;
        service.deleteEntities = deleteEntities;

        service.getCountries = getCountries;
        service.getPlaces = getPlaces;
        service.Save = save;
        service.saveDescriptions = saveDescriptions;
        service.savePersonTags = savePersonTags;

        return service;;
    }

    angular
        .module('app')
        .factory('personService', personService);

    personService.$inject = ['$http', '$rootScope'];
})();
