(function () {

    'use strict';

    var app = angular
        .module('app')
        .controller('MainPersonaIndexController', MainPersonaIndexController);

    MainPersonaIndexController.$inject = ['$scope', '$stateParams', '$rootScope', '$location', '$filter', 'personService'];


    function MainPersonaIndexController($scope, $stateParams, $rootScope, $location, $filter, personService) {
        if ($stateParams.id > 0)
            $rootScope.id = $scope.id = $stateParams.id;
        else {
            $scope.isCreate = $scope.isEdit = true;
            $rootScope.id = $scope.id = -1;
            $scope.person = {Country:"", Place:"", Sex: 0}
        }
        

        function getLinks(data) {
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
        };
        function getMedia(data) {
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
        };
        function getDescript(data) {
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
        };
        function getFact(data) {
            $scope.factlist = [];
            data.forEach(function (item) {
                $scope.factlist.push.apply($scope.factlist, item.List);
            });
        };
        function getConnection(data) {
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
        };
        function getAntro(data) {
            $scope.antro = [];
            $scope.antro.push.apply($scope.antro, data);
        };

        function getYearText(age) {
            var year = age;
            while (year > 10) {
                year = year % 10;
            }
            if (year === 1) {
                return " год";
            }
            else {
                if (year > 1 && year < 5) {
                    return " года";
                }
                else {
                    return " лет";
                }
            }
        }
        function calculateAge(birthday) {
            if (birthday == undefined) return "";
            var ageDifMs = Date.now() - new Date(birthday).getTime();
            var ageDate = new Date(ageDifMs);
            var age = Math.abs(ageDate.getUTCFullYear() - 1970);
            return age + getYearText(age);
        }

        function zodiacYear(date) {
            var year = date.getFullYear();
            switch (year % 12) {
                case 0:
                    return "Обезьяна";
                case 1:
                    return "Петух";
                case 2:
                    return "Собака";
                case 3:
                    return "Свинья";
                case 4:
                    return "Крыса";
                case 5:
                    return "Бык";
                case 6:
                    return "Тигр";
                case 7:
                    return "Кролик";
                case 8:
                    return "Дракон";
                case 9:
                    return "Змея";
                case 10:
                    return "Лошадь";
                case 11:
                    return "Коза";
                default:
                    return "";
            }
        }
        function zodiacMonth(birthday) {
            var y = birthday.getFullYear();
            if (birthday <= new Date(y, 0, 20)) {
                return "Козерог";
            }
            else if (birthday <= new Date(y, 1, 20)) {
                return "Водолей";
            }
            else if (birthday <= new Date(y, 2, 20)) {
                return "Рыбы";
            }
            else if (birthday <= new Date(y, 3, 20)) {
                return "Овен";
            }
            else if (birthday <= new Date(y, 4, 20)) {
                return "Телец";
            }
            else if (birthday <= new Date(y, 5, 21)) {
                return "Близнецы";
            }
            else if (birthday <= new Date(y, 6, 22)) {
                return "Рак";
            }
            else if (birthday <= new Date(y, 7, 23)) {
                return "Лев";
            }
            else if (birthday <= new Date(y, 8, 23)) {
                return "Дева";
            }
            else if (birthday <= new Date(y, 9, 23)) {
                return "Весы";
            }
            else if (birthday <= new Date(y, 10, 22)) {
                return "Скорпион";
            }
            else if (birthday <= new Date(y, 11, 21)) {
                return "Стрелец";
            }
            else {
                return "Козерог";
            }
        }
        $scope.changeDate = function () {
            $scope.person.Bithday = new Date($scope.person.birthday);
            $scope.person.txtBirthday = $scope.person.Bithday;
            $scope.person.Age = calculateAge($scope.person.Bithday);
            $scope.person.ZodiacYear = zodiacYear($scope.person.Bithday);
            $scope.person.ZodiacMonth = zodiacMonth($scope.person.Bithday);
            $scope.person.IsChange = true;
        }
        function getAntros() {
            personService.getAntro($scope.id, getAntro);
        }
        function getAllLinks() {
            personService.getLinks($scope.id, function (data) {
                getLinks(data);
                getAntros();
            });
        }
        function getMedias() {
            personService.getMedia($scope.id, function (data) {
                getMedia(data);
                getAllLinks();
            });
        }
        function getConnections() {
            personService.getConnection($scope.id, function (data) {
                getConnection(data);
                getMedias();
            });
        }
        function getFacts() {
            personService.getFact($scope.id, function (data) {
                getFact(data);
                getConnections();
            });
        }
        function getDescriptions() {
            personService.getDescript($scope.id, function (data) {
                getDescript(data);
                getFacts();
            });
        }
        if ($rootScope.persons !== undefined)
            $rootScope.persons.forEach(function (item) {
                if (item.Id == $scope.id) {
                    $scope.person = item;
                    $scope.person.birthday = new Date($scope.person.Bithday);
                    $scope.changeDate();
                    $scope.person.IsChange = false;
                    getDescriptions();
                    return;
                }
            });
        else {
            personService.getPersons();
        }

        $scope.IsChanged = false;
        $scope.Changed = function (list) {
            $scope.IsChanged = list.filter(function (item) { return item.Changed; }).length > 0;
        }

        $scope.countries = [];
        personService.getCountries("", function (data) {
            $scope.countries.push.apply($scope.countries, data);
        });
        $scope.places = [];
        personService.getPlaces("", function (data) {
            $scope.places.push.apply($scope.places, data);
        });
        $scope.$watch('person.Place', function(data) {
            var place = $scope.places.filter(function (item) { return item.Name === data; })[0];
            if (place === undefined || place === null) return;
            $scope.person.IdBithplace = place.Id;
            $scope.person.Country = place.CountryName;
        });
        $scope.save = function() {
            personService.Save($scope.person, function (data) {
                if (data.Message)
                    $scope.response = data.Message;
                else {
                    personService.getPersons(function() {
                        var person = $scope.persons.filter(function (item) { return item.Id == $scope.id; })[0];
                        if (person === undefined || person === null) return;
                        $scope.person.LastChange = person.LastChange;
                    });
                    $scope.person.IsChange = false;
                    $scope.isEdit = false;
                }
            });
        }
        $scope.register = function () {
            personService.Save($scope.person, function (data) {
                if (data.Message)
                    $scope.response = data.Message;
                else {
                    $rootScope.id = data.personid;
                    personService.getPersons(function() {
                        $location.path("/main/persona/create");
                    });
                }
            });
        }
        // Description metods
        function continueSaveDescription(list) {
            
            personService.getDescript($scope.id, getDescript);
            //list.forEach(function (item) {
            //    item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
            //    item.PersonDescriptionType = $rootScope.descriptiontypes.filter(function (type) {
            //        return type.Id == item.id_DescriptionType;
            //    })[0].Name;
            //});
            //$scope.Changed(list);
        }
        function continueDeleteDescription(list) {
            personService.getDescript($scope.id, getDescript);
        }

        $scope.saveDescription = function (item) {
            var list = [item];
            personService.saveEntities($scope.id, list, 'description', continueSaveDescription);
        }
        $scope.deleteDescription = function ($index) {
            var item = $scope.descriptionlist[$index];
            $scope.descriptionlist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                personService.deleteEntities(list, 'description', continueDeleteDescription);
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
            personService.getFact($scope.id, getFact);
            //list.forEach(function (item) {
            //    item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
            //    item.FactType = $rootScope.facttypes.filter(function (type) { return type.Id === item.id_FactType; })[0];
            //});
            //$scope.Changed(list);
        }
        function continueDeleteFact(list) {
            personService.getFact($scope.id, getFact);
        }

        $scope.changedFact = function (item) {
            item.Changed = true;
            item.FactType = $rootScope.facttypes.filter(function (type) { return type.Id === item.id_FactType; })[0];
        }
        $scope.saveFact = function (item) {
            var list = [item];
            personService.saveEntities($scope.id, list, 'fact', continueSaveFact);
        }
        $scope.deleteFact = function ($index) {
            var item = $scope.factlist[$index];
            $scope.factlist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                personService.deleteEntities(list, 'fact', continueDeleteFact);
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
            personService.getConnection($scope.id, getConnection);
            //list.forEach(function (item) {
            //    item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
            //    item.PersonConnectionType = $rootScope.connectiontypes.filter(function (type) { return type.Id === item.id_ConnectionType; })[0].Name;
            //});
            //$scope.Changed(list);
        }
        function continueDeleteConnection(list) {
            personService.getConnection($scope.id, getConnection);
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
            personService.saveEntities($scope.id, list, 'connection', continueSaveConnection);
        }
        $scope.deleteConnection = function ($index) {
            var item = $scope.connectionList[$index];
            $scope.connectionList.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                personService.deleteEntities(list, 'connection', continueDeleteConnection);
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
            personService.getMedia($scope.id, getMedia);
            //list.forEach(function (item) {
            //    item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
            //    item.MediaType = $rootScope.mediatypes.filter(function (type) { return type.Id == item.id_MediaType; })[0].Name;
            //});
            //$scope.Changed(list);
        }
        function continueDeleteMedia(list) {
            personService.getMedia($scope.id, getMedia);
        }

        $scope.saveMedia = function (item) {
            var list = [item];
            personService.saveEntities($scope.id, list, 'media', continueSaveMedia);
        }
        $scope.deleteMedia = function ($index) {
            var item = $scope.medialist[$index];
            $scope.medialist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                personService.deleteEntities(list, 'media', continueDeleteMedia);
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

        // Links metods
        function continueSaveLink(list) {
            personService.getLinks($scope.id, getLinks);
            //list.forEach(function (item) {
            //    item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
            //    item.PersonSocialLinkType = $rootScope.socialtypes.filter(function (type) { return type.Id == item.IdSocialLinkType; })[0].Name;
            //});
            //$scope.Changed(list);
        }
        function continueDeleteLink(list) {
            personService.getLinks($scope.id, getLinks);
        }

        $scope.saveLink = function (item) {
            var list = [item];
            personService.saveEntities($scope.id, list, 'social', continueSaveLink);
        }
        $scope.deleteLink = function ($index) {
            var item = $scope.linklist[$index];
            $scope.linklist.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                personService.deleteEntities(list, 'social', continueDeleteLink);
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
            personService.getAntro($scope.id, getAntro);
            //list.forEach(function (item) {
            //    item.Changed = item.isEdit = item.isTypeEdit = item.isDescriptionEdit = false;
            //    item.AntroName = $rootScope.antronames.filter(function (type) { return type.Id == item.IdAntro; })[0].Name;
            //});
            //$scope.Changed(list);
        }
        function continueDeleteAntro(list) {
            personService.getAntro($scope.id, getAntro);
        }

        $scope.saveAntro = function (item) {
            var list = [item];
            personService.saveEntities($scope.id, list, 'antro', continueSaveAntro);
        }
        $scope.deleteAntro = function ($index) {
            var item = $scope.antro[$index];
            $scope.antro.splice($index, 1);
            if (item.Id > 0) {
                var list = [item];
                personService.deleteEntities(list, 'antro', continueDeleteAntro);
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
                personService.saveEntities($scope.id, list, 'description', continueSaveDescription);
            list = $scope.factlist.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                personService.saveEntities($scope.id, list, 'fact', continueSaveFact);
            list = $scope.connectionList.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                personService.saveEntities($scope.id, list, 'connection', continueSaveConnection);
            list = $scope.medialist.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                personService.saveEntities($scope.id, list, 'media', continueSaveMedia);
            list = $scope.linklist.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                personService.saveEntities($scope.id, list, 'social', continueSaveLink);
            list = $scope.antro.filter(function (item) { return item.Changed; });
            if (list.length > 0)
                personService.saveEntities($scope.id, list, 'antro', continueSaveAntro);
            $scope.person.IsChange = false;
        }

        $scope.createDescription = function () {
            $rootScope.person = $scope.person;
            $location.path("/main/persona/create");
        }

        $scope.SwitchElements = function () {
            $('.persona-main__container').hide();

            $('.persona-info__full-block').hide();
            $('.persona-info__small-block').show();
        }
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        $scope.tagChange = function (item) {
            item.Changed = true;
            $scope.Changed($scope.medialist);
        }
        $scope.loadMediaTags = function (query) {
            var result = $scope.tags.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }
    }
})();