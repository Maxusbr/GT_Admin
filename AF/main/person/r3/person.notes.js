(function () {
    'use strict';

    function personNotesController($rootScope, $cookieStore, $scope, personService, $filter) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        $rootScope.getDescript = function () {
            $scope.Promise = personService.getDescript($rootScope.personId, function (data) {
                $scope.descriptions = [];
                $scope.descriptionlist = data;
                //data.forEach(function (item) {
                //    if (item.List.length > 0)
                //        $scope.descriptions.push({
                //            type: item.List[0].PersonDescriptionType,
                //            value: item.List[0].DescriptionText,
                //            count: item.Count - 1
                //        });
                //    $scope.descriptionlist.push.apply($scope.descriptionlist, item.List);
                //});
            });
        }
        $rootScope.getDescript();

        $scope.displaySource = function (id, page) {
            $rootScope.editDescriptionId = id;
            $rootScope.pageSchema = page ? page : {};
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.source.html', 3200);
        }
        
        $scope.displayNewSource = function () {
            $rootScope.editableDesc = { id_DescriptionType: 1 };
            $rootScope.pageSchema = {};
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.source.html', 3200);
        }

        $scope.displayNotesStatic = function (item) {
            $rootScope.editableDesc = item ? item : { id_DescriptionType: 2 };
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.static.html', 3200);
        }

        $scope.displayNotesTizer = function (tizer) {
            $rootScope.editableDesc = tizer ? tizer : { id_DescriptionType: 1 };
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.tizer.html', 3200);
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

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getPersonTags() {
            personService.getEntityTags($rootScope.person.Id, 'person', function (data) {
                $scope.personTags = [];
                $scope.personTags.push.apply($scope.personTags, data);
            });
        }

        if ($rootScope.person)
            getPersonTags();

        $scope.loadTags = function (query) {
            if (!$scope.tags) return [];
            var result = $scope.tags.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }

        $scope.savePersonTags = function () {
            if ($scope.personTags.length)
                personService.saveTags($rootScope.personId, $scope.personTags, 'person');
        }
    }

    angular
        .module('app')
        .controller('personNotesController', personNotesController);

    personNotesController.$inject = ['$rootScope', '$cookieStore', '$scope', 'personService', '$filter'];
})();