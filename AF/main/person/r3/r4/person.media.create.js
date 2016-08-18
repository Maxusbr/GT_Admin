(function () {
    'use strict';

    function PersonMediaCreateController($rootScope, $scope, personService, $filter) {
        var vm = this;

        function save(path) {
            $rootScope.editedMedia.MediaLink = path;
            $rootScope.editedMedia.id_Person = $rootScope.personId;
            personService.saveEntity($rootScope.personId, $rootScope.editedMedia, 'media', function (data) {
                $rootScope.getMedias();
                app.closeView('personMediaCreate');
            });
        }

        $scope.saveMedia = function () {
            if (!$scope.file) return;
            if ($rootScope.editedMedia.id_MediaType === 2 && typeof $scope.file != 'string')
                personService.uploadImage($scope.file, function (data) {
                    save(`${serviceUrl}${data.path}`);
                });
            else save($scope.file);
        }

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

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
        .controller('PersonMediaCreateController', PersonMediaCreateController);

    PersonMediaCreateController.$inject = ['$rootScope', '$scope', 'personService', '$filter'];
})();