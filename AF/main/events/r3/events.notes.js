(function () {
    'use strict';

    function EventsNotesController($rootScope, $scope, eventService) {
        var vm = this;

        $rootScope.getDescript = function () {
            $scope.Promise = eventService.getDescript($rootScope.eventId, function (data) {
                $scope.descriptions = [];
                $scope.descriptionlist = data;
            });
        }
        $rootScope.getDescript();

        $scope.displaySource = function (id, page) {
            $rootScope.editDescriptionId = id;
            $rootScope.pageSchema = page ? page : {};
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.notes.source.html', 3200);
        }

        $scope.displayNewSource = function () {
            $rootScope.editableDesc = { id_DescriptionType: 1 };
            $rootScope.pageSchema = {};
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.notes.source.html', 3200);
        }

        $scope.displayNotesStatic = function (item) {
            $rootScope.editableDesc = item ? item : { id_DescriptionType: 2 };
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.notes.static.html', 3200);
        }

        $scope.displayNotesTizer = function (tizer) {
            $rootScope.editableDesc = tizer ? tizer : { id_DescriptionType: 1 };
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.notes.tizer.html', 3200);
        }

        $scope.displayNotesAdaptDescription = function () {

            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.ades.html', 3200);
        }

        $scope.getSchemaName = function (item) {
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
        .controller('EventsNotesController', EventsNotesController);

    EventsNotesController.$inject = ['$rootScope', '$scope', 'eventService'];
})();