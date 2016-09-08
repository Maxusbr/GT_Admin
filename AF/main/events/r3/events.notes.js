(function () {
    'use strict';

    function EventsNotesController($rootScope, $scope, eventService, personService, $filter, $timeout) {
        var vm = this;
        if (!$rootScope.persons)
            $scope.Promise = personService.getPersons();

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

        //Tags
        eventService.getListEventsTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getEventTags() {
            if ($scope.eventId)
                eventService.getEventTags($scope.eventId, function (data) {
                    $scope.categoryTags = [];
                    $scope.categoryTags.push.apply($scope.categoryTags, data);
                });
        }
        getEventTags();


        $scope.loadTags = function (query) {
            if (!$scope.tags) return [];
            var result = $scope.tags.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }

        //Genre
        eventService.getEventListGenres(function (data) {
            $scope.listGenres = [];
            $scope.listGenres.push.apply($scope.listGenres, data);
        });

        function getEventGenres() {
            if ($scope.eventId)
                eventService.getEventGenres($scope.eventId, function (data) {
                    $scope.genres = [];
                    $scope.genres.push.apply($scope.genres, data);
                });
        }
        getEventGenres();

        $scope.loadGenres = function (query) {
            if (!$scope.listGenres) return [];
            var result = $scope.listGenres.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }

        $scope.saveEventTags = function() {
            if ($scope.genres.length) {
                eventService.saveTags($scope.eventId, $scope.categoryTags, 'event', function(deta) {
                    eventService.saveTags($scope.eventId, $scope.genres, 'genre', function (deta) {
                        //TODO show msg
                    });
                });
            }
        }
    }

    angular
        .module('app')
        .controller('EventsNotesController', EventsNotesController);

    EventsNotesController.$inject = ['$rootScope', '$scope', 'eventService', 'personService', '$filter', '$timeout'];
})();