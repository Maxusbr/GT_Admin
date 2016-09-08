(function () {
    'use strict';

    function personNotesStaticController($rootScope, $cookieStore, $scope, $filter, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $scope.staticDescription = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc.StaticDescription :
            $rootScope.editableDesc;
        $scope.tizerId = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc.Id : 0;

        function saveTizerTags() {
            if ($scope.tizerTags.length && $scope.staticDescription.Id > 0)
                personService.saveTags($scope.staticDescription.Id, $scope.tizerTags, 'tizer');
        }

        $scope.savePersonNotesStatic = function () {

            $scope.staticDescription.id_Person = $rootScope.personId;
            $scope.staticDescription.id_DescriptionType = 2;
            personService.saveEntity($scope.tizerId, $scope.staticDescription, 'description', function (data) {
                //TODO show msg
                $scope.staticDescription.Id = data;
                saveTizerTags();
                $rootScope.getDescript();
                if ($rootScope.getPersonCounts)
                    $rootScope.getPersonCounts();
                $timeout(function () {
                    return app.closeView('disPersonNotesStatic');
                }, 3000);

            });

        }

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getTizerTags() {
            if (!$scope.staticDescription || !$scope.staticDescription.Id) return;
            personService.getEntityTags($scope.staticDescription.Id, 'tizer', function (data) {
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
        .controller('personNotesStaticController', personNotesStaticController);

    personNotesStaticController.$inject = ['$rootScope', '$cookieStore', '$scope', '$filter', 'personService'];
})();