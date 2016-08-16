(function () {
    'use strict';

    function personNotesSourceController($rootScope, $scope, $cookieStore) {
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
                    return `Мероприятие/${item.PageBlock.Page.Event.Name}`;
                case 3:
                    return `Площадка/${item.PageBlock.Page.Hall.Name}`;
                case 4:
                    return "Профиль";
                case 5:
                    return "Главная";
                default:
                    return "";
            }
        }
        $scope.getDetail($rootScope.pageSchema.Page.PageType);

        $rootScope.savePersonNotesSource = function() {
            //TODO: save changes or create new source
            //TODO: update notes list
            //TODO: close this window
        }

        $rootScope.displayPersonWTF = function display_person_WTF() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.wtf.html', 3200);
        }
            
    }

    angular
        .module('app')
        .controller('personNotesSourceController', personNotesSourceController);

    personNotesSourceController.$inject = ['$rootScope', '$scope', '$cookieStore'];
})();