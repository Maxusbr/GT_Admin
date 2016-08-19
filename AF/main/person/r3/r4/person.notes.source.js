(function () {
    'use strict';

    function personNotesSourceController($rootScope, $scope, $cookieStore, personService, eventService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');
        if (!$rootScope.pageSchema.Page)
            $rootScope.pageSchema.Page = {};
        if (!$rootScope.events)
            eventService.getEvents();
        $rootScope.halls = [];
        $scope.pages = [
            { Id: 0, Name: "Персона" },
            { Id: 1, Name: "Поиск" },
            { Id: 2, Name: "Мероприятие" },
            { Id: 3, Name: "Площадка" },
            { Id: 4, Name: "Профиль" },
            { Id: 5, Name: "Главная" }
        ];

        //TODO get page blocks
        $scope.bloks = [
            { Id: null, Name: "Не указано" },
            { Id: 1, Name: "Другие персоны подборки" }
        ];
        
        $scope.getDetail = function (item) {
            $scope.detailId = 0;
            $scope.details = [];
            switch (item) {
                case 0:
                    $scope.detailId = $rootScope.pageSchema.Page.IdPerson;
                    return $rootScope.persons.forEach(function(item) {
                        $scope.details.push({ Id: item.Id, Name: `${item.LastName} ${item.Name}` });
                    });
                case 1:
                    return "Поиск";
                case 2:
                    $scope.detailId = $rootScope.pageSchema.Page.IdEvent;
                    return $rootScope.events.forEach(function (item) {
                        $scope.details.push({ Id: item.Id, Name: item.Name });
                    });
                case 3:
                    $scope.detailId = $rootScope.pageSchema.Page.IdHall;
                    return $rootScope.halls.forEach(function (item) {
                        $scope.details.push({ Id: item.Id, Name: item.Name });
                    });
                case 4:
                    return "Профиль";
                case 5:
                    return "Главная";
                default:
                    return "";
            }
        }
        $scope.getDetail($rootScope.pageSchema.Page.PageType);

        $scope.changeDetail = function (item) {
            switch ($rootScope.pageSchema.Page.PageType) {
                case 0:
                    $rootScope.pageSchema.Page.IdPerson = item;
                    break;
                case 1: break;
                    // "Поиск";
                case 2:
                    $rootScope.pageSchema.Page.IdEvent = item;
                    break;
                case 3:
                    $rootScope.pageSchema.Page.IdHall = item;
                    break;
                case 4: break;
                    // "Профиль";
                case 5: break;
                    // "Главная";
                default:
                    break;
            }
        }
        if (!$rootScope.userPageCategories) {
            $rootScope.userPageCategories = [{Id: null, Name: "Не указано"}];
            personService.getUserPageCategories(function (data) {
                $rootScope.userPageCategories.push.apply($rootScope.userPageCategories, data);
            });
        }

        $rootScope.savePersonNotesSource = function() {
            //TODO: save changes or create new source
            //TODO: update notes list
            //TODO: close this window
            if (!$rootScope.editDescriptionId)$rootScope.editDescriptionId = 0;
            personService.saveDescriptionSchema($rootScope.editDescriptionId, $rootScope.personId, $rootScope.pageSchema, function () {
                $rootScope.getDescript();
                app.closeView('disPersonNotesSource');
            });
        }

        $scope.displayPersonWTF = function display_person_WTF() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.wtf.html', 3200);
        }
            
        $scope.changeCat = function (id) {
            if ($rootScope.userPageCategories)
                $rootScope.pageSchema.UserPageCategory = $rootScope.userPageCategories.filter(function(item) {
                    return item.Id === id;
                })[0].Name;
        }
            
        $scope.cangeType = function (id) {
            $rootScope.pageSchema.Type.Name = $scope.bloks.filter(function (item) {
                return item.Id === id;
            })[0].Name;
        }
    }

    angular
        .module('app')
        .controller('personNotesSourceController', personNotesSourceController);

    personNotesSourceController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService', 'eventService'];
})();