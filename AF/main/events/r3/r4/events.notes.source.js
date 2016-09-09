(function () {
    'use strict';

    function eventsNotesSourceController($rootScope, $scope, eventService, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        if (!$rootScope.pageSchema.Page)
            $rootScope.pageSchema.Page = {};

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
                    return $rootScope.persons.forEach(function (item) {
                        $scope.details.push({ Id: item.Id, Name: `${item.LastName} ${item.Name}` });
                    });
                case 1:
                    return "Поиск";
                case 2:
                    $scope.detailId = $rootScope.pageSchema.Page.IdEvent;
                    return $rootScope.events.forEach(function (item) {
                        $scope.details.push({ Id: item.Id, Name: `${item.PageBlock.Page.Event.Name}` });
                    });
                case 3:
                    $scope.detailId = $rootScope.pageSchema.Page.IdHall;
                    return $rootScope.halls.forEach(function (item) {
                        $scope.details.push({ Id: item.Id, Name: `${item.PageBlock.Page.Hall.Name}` });
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
                case 1:
                    break;
                case 2:
                    $rootScope.pageSchema.Page.IdEvent = item;
                    break;
                case 3:
                    $rootScope.pageSchema.Page.IdHall = item;
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;;
            }
        };
        if (!$rootScope.userPageCategories) {
            $rootScope.userPageCategories = [{ Id: null, Name: "Не указано" }];
            personService.getUserPageCategories(function (data) {
                $rootScope.userPageCategories.push.apply($rootScope.userPageCategories, data);
            });
        }


        $rootScope.saveEventNotesSource = function () {
            $scope.showMessage = true;
            if (!$rootScope.editDescriptionId) $rootScope.editDescriptionId = 0;
            eventService.saveDescriptionSchema($rootScope.editDescriptionId, $rootScope.eventId, $rootScope.pageSchema, function () {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.getDescript();
                $scope.Promise = $timeout(function () {
                    return app.closeView('disEventNotesSource');
                }, timeoutMsgShow);
            });
        }

        $scope.displayPersonWTF = function display_person_WTF() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.wtf.html', 3200);
        }

        $scope.changeCat = function (id) {
            if ($rootScope.userPageCategories)
                $rootScope.pageSchema.UserPageCategory = $rootScope.userPageCategories.filter(function (item) {
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
        .controller('eventsNotesSourceController', eventsNotesSourceController);

    eventsNotesSourceController.$inject = ['$rootScope', '$scope', 'eventService', 'personService', '$timeout'];
})();