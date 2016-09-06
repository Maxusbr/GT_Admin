(function () {
    'use strict';

    function personNotesTizerController($rootScope, $cookieStore, $scope, $filter, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $scope.tizer = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc :
            { id_DescriptionType: 1, RequiredStaticDescription: true };
        $scope.notRequired = !$scope.tizer.RequiredStaticDescription;

        function saveTizerTags() {
            if ($scope.tizerTags.length && $scope.tizer.Id > 0)
                personService.saveTags($scope.tizer.Id, $scope.tizerTags, 'tizer');
        }

        $scope.savePersonNotesTizer = function () {
            //TODO: save changes
            //TODO: update notes table
            //TODO: close window
            $scope.tizer.id_Person = $rootScope.personId;
            $scope.tizer.id_DescriptionType = 1;
            personService.saveEntity(0, $scope.tizer, 'description', function (data) {
                $scope.tizer.Id = data;
                saveTizerTags();
                if ($rootScope.editableDesc.id_DescriptionType === 2 && $scope.tizer.Id > 0)
                    personService.saveEntity($scope.tizer.Id, $rootScope.editableDesc, 'description', function (data) {
                        $rootScope.getDescript();
                        app.closeView('disPersonNotesTizer');
                    });
                else {
                    $rootScope.getDescript();
                    app.closeView('disPersonNotesTizer');
                }
                if ($rootScope.getPersonCounts)
                    $rootScope.getPersonCounts();
            });
        }

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getTizerTags() {
            if ($scope.tizer.Id)
                personService.getEntityTags($scope.tizer.Id, 'tizer', function (data) {
                    $scope.tizerTags = [];
                    $scope.tizerTags.push.apply($scope.tizerTags, data);
                });
        }
        getTizerTags();


        $scope.loadTags = function (query) {
            if (!$scope.tags) return [];
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