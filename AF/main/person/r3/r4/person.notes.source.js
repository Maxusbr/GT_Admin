(function () {
    'use strict';

    function personNotesSourceController($rootScope, $scope, $cookieStore, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');
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
            { Id: 0, Name: "Не указано" },
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
                case 1: break;
                    return "Поиск";
                case 2:
                    $rootScope.pageSchema.Page.IdEvent = item;
                    break;
                case 3:
                    $rootScope.pageSchema.Page.IdHall = item;
                    break;
                case 4: break;
                    return "Профиль";
                case 5: break;
                    return "Главная";
                default:
                    return "";
            }
        }

        $rootScope.savePersonNotesSource = function() {
            //TODO: save changes or create new source
            //TODO: update notes list
            //TODO: close this window
            personService.saveDescriptionSchema($rootScope.editDescriptionId, $rootScope.pageSchema, function () {
                $rootScope.getDescript();
                app.closeView('disPersonNotesSource');
            });
        }

        $rootScope.displayPersonWTF = function display_person_WTF() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.wtf.html', 3200);
        }
            
    }

    angular
        .module('app')
        .controller('personNotesSourceController', personNotesSourceController);

    personNotesSourceController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService'];
})();