(function () {
    'use strict';

    function PersonMediaCreateController($rootScope, $scope, personService, $filter, $timeout) {
        var vm = this;

        function save(path) {
            $rootScope.editedMedia.MediaLink = path;
            $rootScope.editedMedia.id_Person = $rootScope.personId;
            personService.saveEntity($rootScope.personId, $rootScope.editedMedia, 'media', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                $rootScope.getMedias();
                $scope.Promise = $timeout(function () {
                    return app.closeView('personMediaCreate');
                }, timeoutMsgShow);
                
            });
        }

        $scope.saveMedia = function () {
            if (!$scope.file) return;
            if ($rootScope.editedMedia.id_MediaType === 2 && typeof $scope.file != 'string')
                personService.uploadImage($scope.file, function (data) {
                    $scope.errorYes = !data.path;
                    if (data.path) {
                        $scope.message = 'Save complete';
                        save(`${serviceUrl}${data.path}`);
                    } else {
                        $scope.message = 'Error save: ' + data;
                    }
                    $scope.showMessage = true;
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

    PersonMediaCreateController.$inject = ['$rootScope', '$scope', 'personService', '$filter', '$timeout'];
})();