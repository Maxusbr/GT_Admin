(function () {
    'use strict';

    function personNotesController($rootScope, $cookieStore, $scope, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.getDescript = function() {
            $scope.Promise = personService.getDescript($rootScope.personId, function (data) {
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
        }
        $rootScope.getDescript();

        $rootScope.displaySource = function (page) {
            $rootScope.pageSchema = page ? page: {};
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.source.html', 3200);
        }

        $rootScope.displayNotesStatic = function (descript) {
            $rootScope.staticDescript = descript ? descript : {id_DescriptionType: 2 };
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.static.html', 3200);
        }

        $rootScope.displayNotesTizer = function (tizer) {
            $rootScope.editableTizer = tizer ? tizer : { id_DescriptionType: 1 };
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.tizer.html', 3200);
        }

        $rootScope.displayNotesAdaptDescription = function () {

            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.ades.html', 3200);
        }

        $scope.getSchemaName = function(item) {
            if (!item.PageBlock) return "";

            switch (item.PageBlock.Page.PageType) {
            case 0:
                return `Персона/${item.PageBlock.Page.Person.LastName} ${item.PageBlock.Page.Person.Name}`;
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
    }

    angular
        .module('app')
        .controller('personNotesController', personNotesController);

    personNotesController.$inject = ['$rootScope', '$cookieStore', '$scope', 'personService'];
})();