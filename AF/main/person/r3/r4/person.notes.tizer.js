(function () {
    'use strict';

    function personNotesTizerController($rootScope, $cookieStore, $scope, $filter, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.savePersonNotesTizer = function save_person_notes_tizer(){
            //TODO: save changes
            //TODO: update notes table
            //TODO: close window
        }

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getPersonTags() {
            personService.getPersonTags($rootScope.person.Id, function (data) {
                $scope.personTags = [];
                $scope.personTags.push.apply($scope.personTags, data);
            });
        }

        if ($rootScope.person)
            getPersonTags();

        $scope.loadTags = function (query) {
            var result = $scope.tags.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }
    }

    angular
        .module('app')
        .controller('personNotesTizerController', personNotesTizerController);

    personNotesTizerController.$inject = ['$rootScope', '$cookieStore', '$scope', '$filter', 'personService'];
})();