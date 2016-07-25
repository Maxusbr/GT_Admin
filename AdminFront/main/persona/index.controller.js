(function () {

    'use strict';

    var app = angular
        .module('app')
        .controller('MainPersonaIndexController', MainPersonaIndexController);

    MainPersonaIndexController.$inject = ['$scope', '$stateParams', '$http', '$rootScope'];


    function MainPersonaIndexController($scope, $stateParams, $http, $rootScope) {

        function getLinks(id) {
            $http.get(`${apiUrl}persons/social/${id}`).success(function (data) {
                $scope.links = [];
                $scope.linklist = [];
                data.forEach(function (item) {
                    if (item.List.length > 0)
                        $scope.links.push({
                            type: item.List[0].PersonSocialLinkType,
                            value: item.List[0].Link,
                            descript: item.List[0].Description,
                            count: item.Count - 1
                        });
                    $scope.linklist.push.apply($scope.linklist, item.List);
                });
            });
        };
        function getMedia(id) {
            $http.get(`${apiUrl}persons/media/${id}`).success(function (data) {
                $scope.medias = [];
                $scope.medialist = [];
                data.forEach(function (item) {
                    if (item.List.length > 0)
                        $scope.medias.push({
                            type: item.List[0].MediaType,
                            value: item.List[0].MediaLink,
                            count: item.Count - 1
                        });
                    $scope.medialist.push.apply($scope.medialist, item.List);
                });
            });
        };
        function getDescript(id) {
            $http.get(`${apiUrl}persons/description/${id}`).success(function (data) {
                $scope.descriptions = [];
                $scope.descriptionlist = [];
                data.forEach(function (item) {
                    if (item.List.length > 0)
                        $scope.descriptions.push({
                            type: item.List[0].PersonDescriptionType,
                            value: item.List[0].DescriptionText,
                            count: item.Count - 1
                        });
                    $scope.descriptionlist.push.apply($scope.descriptionlist, item.List);
                });

            });
        };
        function getFact(id) {
            $http.get(`${apiUrl}persons/fact/${id}`).success(function (data) {
                $scope.factlist = [];
                data.forEach(function (item) {
                    $scope.factlist.push.apply($scope.factlist, item.List);
                });
            });
        };
        function getConnection(id) {
            $http.get(`${apiUrl}persons/connection/${id}`).success(function (data) {
                $scope.connections = [];
                $scope.connectionList = [];
                data.forEach(function (item) {
                    if (item.List.length > 0) {
                        var connection = item.Type > 1 ? {
                            name: item.List[0].PersonConnectionType,
                            descript: item.List[0].Description,
                            value: item.List[0].Event.Name,
                            count: item.Count - 1
                        } : {
                            name: item.List[0].PersonConnectionType,
                            descript: item.List[0].Description,
                            value: `${item.List[0].PersonConnectTo.LastName} ${item.List[0].PersonConnectTo.Name}`,
                            count: item.Count - 1
                        };
                        $scope.connectionList.push.apply($scope.connectionList, item.List);
                        $scope.connections.push(connection);
                    }
                });
            });
        };
        function getAntro(id) {
            $http.get(`${apiUrl}persons/antro/${id}`).success(function (data) {
                $scope.antro = [];
                $scope.antro.push.apply($scope.antro, data);
                //data.forEach(function (item) {
                //    $scope.antro.push({ name: item.AntroName, value: item.Value });
                //});
            });
        };

        function getYearText(age) {
            var year = age;
            while (year > 10) {
                year = year % 10;
            }
            if (year === 1) {
                return "год";
            }
            else {
                if (year > 1 && year < 5) {
                    return "года";
                }
                else {
                    return "лет";
                }
            }
        }
        $scope.id = $stateParams.id;
        if ($rootScope.persons !== undefined)
            $rootScope.persons.forEach(function (item) {
                if (item.Id == $scope.id) {
                    $scope.person = item;
                    $scope.yearText = getYearText(item.Age);
                    getDescript($scope.id);
                    getFact($scope.id);
                    getConnection($scope.id);
                    getMedia($scope.id);
                    getLinks($scope.id);
                    getAntro($scope.id);
                    return;
                }
            });
        else {
            $http({
                url: `${apiUrl}persons/${pageNumber}/${pageSize}`,
                method: "POST",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).success(function (data) {
                $rootScope.persons = data;
                $rootScope.persons.forEach(function (item) {
                    $scope.menuScope.push({
                        id: item.Id,
                        name: item.Name + ' ' + item.LastName,
                        type: item.EventType,
                        event: item.EventName
                    });
                });
            });
        }

        $scope.IsChanged = false;
        $scope.Changed = function (list) {
            $scope.IsChanged = list.filter(function (item) { return item.Changed; }).length > 0;
        }

        function saveEntities(list, entity, callback) {
            $http.post(`${apiUrl}persons/${entity}/update/${$scope.id}`, list).success(function (response) {
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

        // Description metods
        function continueSaveDescription(list) {
            list.forEach(function (item) {
                item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
                item.PersonDescriptionType = $rootScope.descriptiontypes.filter(function (type) {
                    return type.Id == item.id_DescriptionType;
                })[0].Name;
            });
            $scope.Changed(list);
        }
        function continueDeleteDescription(list) {
            getDescript($scope.id);
        }

        $scope.saveDescription = function (item) {
            var list = [item];
            saveEntities(list, 'description', continueSaveDescription);
        }
        $scope.deleteDescription = function ($index) {
            var item = $scope.descriptionlist[$index];
            $scope.descriptionlist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                deleteEntities(list, 'description', continueDeleteDescription);
            }
            $scope.Changed($scope.descriptionlist);
            $scope.$apply();
        }
        $scope.addDescription = function () {
            var descript = {
                Id: 0, Changed: true, isTypeEdit: true, isEdit: true, isDescriptionEdit: true,
                id_Person: $scope.id,
                id_DescriptionType: 1
            }
            descript.PersonDescriptionType = $rootScope.descriptiontypes.filter(function (type) { return type.Id === descript.id_DescriptionType; })[0].Name;
            $scope.descriptionlist.push(descript);
            $scope.Changed($scope.descriptionlist);
        }

        // Fact metods
        function continueSaveFact(list) {
            list.forEach(function (item) {
                item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
                item.FactType = $rootScope.facttypes.filter(function (type) { return type.Id === item.id_FactType; })[0];
            });
            $scope.Changed(list);
        }
        function continueDeleteFact(list) {
            getFact($scope.id);
        }

        $scope.changedFact = function (item) {
            item.Changed = true;
            item.FactType = $rootScope.facttypes.filter(function (type) { return type.Id === item.id_FactType; })[0];
        }
        $scope.saveFact = function (item) {
            var list = [item];
            saveEntities(list, 'fact', continueSaveFact);
        }
        $scope.deleteFact = function ($index) {
            var item = $scope.factlist[$index];
            $scope.factlist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                deleteEntities(list, 'fact', continueDeleteFact);
            }
            $scope.Changed($scope.factlist);
            $scope.$apply();
        }
        $scope.addFact = function () {
            var fact = {
                Id: 0, Changed: true, isTypeEdit: true, isEdit: true, isDescriptionEdit: true,
                id_Person: $scope.id,
                id_FactType: 1
            }
            fact.FactType = $rootScope.facttypes.filter(function (type) { return type.Id === fact.id_FactType; })[0];
            $scope.factlist.push(fact);
            $scope.Changed($scope.factlist);
        }

        // Connection metods
        function continueSaveConnection(list) {
            list.forEach(function (item) {
                item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
                item.PersonConnectionType = $rootScope.connectiontypes.filter(function (type) { return type.Id === item.id_ConnectionType; })[0].Name;
            });
            $scope.Changed(list);
        }
        function continueDeleteConnection(list) {
            getConnection($scope.id);
        }

        $scope.changedConnectionEvent = function (item) {
            item.Changed = true;
            item.id_PersonConnectTo = null;
            item.Event = $rootScope.eventlist.filter(function (type) { return type.Id === item.id_Event; })[0];
        }
        $scope.changedConnectionPerson = function (item) {
            item.Changed = true;
            item.id_Event = null;
            item.PersonConnectTo = $rootScope.persons.filter(function (type) { return type.Id === item.id_PersonConnectTo; })[0];
        }
        $scope.saveConnection = function (item) {
            var list = [item];
            saveEntities(list, 'connection', continueSaveConnection);
        }
        $scope.deleteConnection = function ($index) {
            var item = $scope.connectionList[$index];
            $scope.connectionList.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                deleteEntities(list, 'connection', continueDeleteConnection);
            }
            $scope.Changed($scope.connectionList);
            $scope.$apply();
        }
        $scope.addConnection = function () {
            var connection = {
                Id: 0, Changed: true, isTypeEdit: true, isEdit: true, isDescriptionEdit: true,
                id_Person: $scope.id,
                id_ConnectionType: 1
            }
            connection.PersonConnectionType = $rootScope.connectiontypes.filter(function (type) { return type.Id === connection.id_ConnectionType; })[0].Name;
            $scope.connectionList.push(connection);
            $scope.Changed($scope.connectionList);
        }

        // Media metods
        function continueSaveMedia(list) {
            list.forEach(function (item) {
                item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
                item.MediaType = $rootScope.mediatypes.filter(function (type) { return type.Id == item.id_MediaType; })[0].Name;
            });
            $scope.Changed(list);
        }
        function continueDeleteMedia(list) {
            getMedia($scope.id);
        }

        $scope.saveMedia = function (item) {
            var list = [item];
            saveEntities(list, 'media', continueSaveMedia);
        }
        $scope.deleteMedia = function ($index) {
            var item = $scope.medialist[$index];
            $scope.medialist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                deleteEntities(list, 'media', continueDeleteMedia);
            }
            $scope.Changed($scope.medialist);
            $scope.$apply();
        }
        $scope.addMedia = function () {
            var media = {
                Id: 0, Changed: true, isTypeEdit: true, isEdit: true, isDescriptionEdit: true,
                id_Person: $scope.id,
                id_MediaType: 1
            }
            media.MediaType = $rootScope.mediatypes.filter(function (type) { return type.Id == media.id_MediaType; })[0].Name;
            $scope.medialist.push(media);
            $scope.Changed($scope.medialist);
        }

        // Media metods
        function continueSaveLink(list) {
            list.forEach(function (item) {
                item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
                item.PersonSocialLinkType = $rootScope.socialtypes.filter(function (type) { return type.Id == item.IdSocialLinkType; })[0].Name;
            });
            $scope.Changed(list);
        }
        function continueDeleteLink(list) {
            getLinks($scope.id);
        }

        $scope.saveLink = function (item) {
            var list = [item];
            saveEntities(list, 'social', continueSaveLink);
        }
        $scope.deleteLink = function ($index) {
            var item = $scope.linklist[$index];
            $scope.linklist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                deleteEntities(list, 'social', continueDeleteLink);
            }
            $scope.Changed($scope.linklist);
            $scope.$apply();
        }
        $scope.addLink = function () {
            var link = {
                Id: 0, Changed: true, isTypeEdit: true, isEdit: true, isDescriptionEdit: true,
                id_Person: $scope.id,
                IdSocialLinkType: 1
            }
            link.PersonSocialLinkType = $rootScope.socialtypes.filter(function (type) { return type.Id == link.IdSocialLinkType; })[0].Name;
            $scope.linklist.push(link);
            $scope.Changed($scope.linklist);
        }

        // Media antros
        function continueSaveAntro(list) {
            list.forEach(function (item) {
                item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
                item.AntroName = $rootScope.antronames.filter(function (type) { return type.Id == item.IdAntro; })[0].Name;
            });
            $scope.Changed(list);
        }
        function continueDeleteAntro(list) {
            getAntro($scope.id);
        }

        $scope.saveAntro = function (item) {
            var list = [item];
            saveEntities(list, 'antro', continueSaveAntro);
        }
        $scope.deleteAntro = function ($index) {
            var item = $scope.antro[$index];
            $scope.antro.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                deleteEntities(list, 'antro', continueDeleteAntro);
            }
            $scope.Changed($scope.antro);
            $scope.$apply();
        }
        $scope.addAntro = function () {
            var antro = {
                Id: 0, Changed: true, isTypeEdit: true, isEdit: true, isDescriptionEdit: true,
                id_Person: $scope.id,
                IdAntro: 1
            }
            antro.AntroName = $rootScope.antronames.filter(function (type) { return type.Id == antro.IdAntro; })[0].Name;
            $scope.antro.push(antro);
            $scope.Changed($scope.antro);
        }

        $scope.saveAll = function () {
            var list = $scope.descriptionlist.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                saveEntities(list, 'description', continueSaveDescription);
            list = $scope.factlist.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                saveEntities(list, 'fact', continueSaveFact);
            list = $scope.connectionList.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                saveEntities(list, 'connection', continueSaveConnection);
            list = $scope.medialist.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                saveEntities(list, 'media', continueSaveMedia);
            list = $scope.linklist.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                saveEntities(list, 'social', continueSaveLink);
            list = $scope.antro.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                saveEntities(list, 'antro', continueSaveAntro);
        }

        $scope.SwitchElements = function () {
            $('.persona-main__container').hide();

            $('.persona-info__full-block').hide();
            $('.persona-info__small-block').show();
        }
    }
})();