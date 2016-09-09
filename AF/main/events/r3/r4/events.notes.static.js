(function () {
    'use strict';

    function eventsNotesStaticController($rootScope, $cookieStore, $scope, $filter, eventService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = 'Error';
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $scope.staticDescription = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc.StaticDescription :
            $rootScope.editableDesc;
        $scope.tizerId = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc.Id : 0;

        function saveTizerTags() {
            if ($scope.tizerTags.length && $scope.staticDescription.Id > 0)
                eventService.saveTags($scope.staticDescription.Id, $scope.tizerTags, 'tizer', function (data) {
                    $scope.errorYes = data.status !== "success";
                    $scope.message = data.result;
                    $scope.showMessage = true;
                });
        }

        $scope.savePersonNotesStatic = function () {

            $scope.staticDescription.id_Person = $rootScope.personId;
            $scope.staticDescription.id_DescriptionType = 2;
            eventService.saveEntity($scope.tizerId, $scope.staticDescription, 'description', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                $scope.staticDescription.Id = id;
                saveTizerTags();
                $rootScope.getDescript();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('disPersonNotesStatic');
                    }, timeoutMsgShow);
            });
        }

        // Tags
        eventService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getTizerTags() {
            if (!$scope.staticDescription || !$scope.staticDescription.Id) return;
            eventService.getEntityTags($scope.staticDescription.Id, 'tizer', function (data) {
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
        .controller('eventsNotesStaticController', eventsNotesStaticController);

    eventsNotesStaticController.$inject = ['$rootScope', '$cookieStore', '$scope', '$filter', 'eventService', '$timeout'];
})();