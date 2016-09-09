(function () {
    'use strict';

    function eventNotesTizerController($rootScope, $cookieStore, $scope, $filter, eventService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $scope.tizer = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc :
            { id_DescriptionType: 1, RequiredStaticDescription: true };
        $scope.notRequired = !$scope.tizer.RequiredStaticDescription;

        function saveTizerTags() {
            if ($scope.tizerTags.length && $scope.tizer.Id > 0)
                eventService.saveTags($scope.tizer.Id, $scope.tizerTags, 'tizer', function (data) {
                    $scope.errorYes = data.status !== "success";
                    $scope.message = data.result;
                    $scope.showMessage = true;
                });
        }
        function continueSave() {
            $rootScope.getDescript();
            if (!$scope.errorYes)
                $scope.Promise = $timeout(function () {
                    return app.closeView('disEventnNotesTizer');
                }, timeoutMsgShow);
        }
        $scope.savePersonNotesTizer = function () {
            console.log($scope.tizer);
            $scope.tizer.id_Person = $rootScope.personId;
            $scope.tizer.id_DescriptionType = 1;
            eventService.saveEntity(0, $scope.tizer, 'description', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                $scope.tizer.Id = id;
                saveTizerTags();
                if ($rootScope.editableDesc.id_DescriptionType === 2 && $scope.tizer.Id > 0)
                    eventService.saveEntity($scope.tizer.Id, $rootScope.editableDesc, 'description', function (id) {
                        $scope.errorYes = id <= 0;
                        $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                        $scope.showMessage = true;
                        continueSave();
                    });
                else {
                    continueSave();
                }
            });
        }

        // Tags
        eventService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getTizerTags() {
            if ($scope.tizer.Id)
                eventService.getEntityTags($scope.tizer.Id, 'tizer', function (data) {
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
        .controller('eventNotesTizerController', eventNotesTizerController);

    eventNotesTizerController.$inject = ['$rootScope', '$cookieStore', '$scope', '$filter', 'eventService', '$timeout'];
})();