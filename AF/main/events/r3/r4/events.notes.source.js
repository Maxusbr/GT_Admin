(function () {
    'use strict';

    function eventsNotesSourceController($rootScope, $scope, eventService, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        //TODO get page blocks
        $scope.bloks = [
            { Id: null, Name: "Не указано" },
            { Id: 1, Name: "Другие персоны подборки" }
        ];

        if (!$rootScope.userPageCategories) {
            $rootScope.userPageCategories = [{ Id: null, Name: "Не указано" }];
            personService.getUserPageCategories(function (data) {
                $rootScope.userPageCategories.push.apply($rootScope.userPageCategories, data);
            });
        }
        $scope.changeCat = function (id) {
            if ($rootScope.userPageCategories)
                $rootScope.pageSchema.UserPageCategory = $rootScope.userPageCategories.filter(function (item) {
                    return item.Id === id;
                })[0].Name;
        }

        $scope.cangeType = function (id) {
            if ($scope.bloks)
                $rootScope.pageSchema.Type.Name = $scope.bloks.filter(function (item) {
                    return item.Id === id;
                })[0].Name;
        }
        if (!$rootScope.pageSchema.Page)
            $rootScope.pageSchema.Page = {  };
        if (!$rootScope.pageSchema.Type)
            $rootScope.pageSchema.Type = { Id: 1, Name: "" };
        if (!$rootScope.pageSchema.UserPageCategoryId)
            $rootScope.pageSchema.UserPageCategoryId = null;

        $scope.cangeType($rootScope.pageSchema.Type.Id);
        $scope.pages = [
            { Id: 0, Name: "Персона" },
            { Id: 1, Name: "Поиск" },
            { Id: 2, Name: "Мероприятие" },
            { Id: 3, Name: "Площадка" },
            { Id: 4, Name: "Профиль" },
            { Id: 5, Name: "Главная" }
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



        $rootScope.saveEventNotesSource = function () {
            console.log($scope.pageSchema.Page.PageType);
            if (($scope.pageSchema.Page.PageType == undefined)) {
                $scope.showMessage = true;
                $scope.errorYes = true;
                $scope.message = 'Страница обязательные поле';
                return;
            }

            if (($scope.pageSchema.Page.PageType === 0) || ($scope.pageSchema.Page.PageType === 2) || ($scope.pageSchema.Page.PageType === 3)) {
                if ($scope.detailId == undefined) {
                    $scope.showMessage = true;
                    $scope.errorYes = true;
                    $scope.message = 'Уточнение обязательные поля';
                    return;
                }
            }

            if (!$rootScope.editDescriptionId) $rootScope.editDescriptionId = 0;
            eventService.saveDescriptionSchema($rootScope.editDescriptionId, $rootScope.eventId, $rootScope.pageSchema, function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.getDescript();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('disEventNotesSource');
                    }, timeoutMsgShow);
            });
        }

        $scope.displayPersonWTF = function display_person_WTF() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.wtf.html', 3200);
        }


    }

    angular
        .module('app')
        .controller('eventsNotesSourceController', eventsNotesSourceController);

    eventsNotesSourceController.$inject = ['$rootScope', '$scope', 'eventService', 'personService', '$timeout'];
})();