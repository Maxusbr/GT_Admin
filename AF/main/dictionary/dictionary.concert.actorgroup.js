(function () {
    'use strict';

    function dictConcertActorGroupController($rootScope, $scope, concertService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        vm.editItem = $rootScope.editedGroup? $rootScope.editedGroup: { Name: "" };

        $scope.saveChanges = function () {
            if (vm.editItem)
                concertService.saveActorGroup(vm.editItem, function (data) {
                    $scope.errorYes = data.status !== "success";
                    $scope.message = data.result;
                    $scope.showMessage = true;
                    $rootScope.getGroups();
                    $scope.Promise = $timeout(function () {
                        return app.closeView('disoncertActorGroup');
                    }, timeoutMsgShow);
                });
        }
    }

    angular
        .module('app')
        .controller('dictConcertActorGroupController', dictConcertActorGroupController);

    dictConcertActorGroupController.$inject = ['$rootScope', '$scope', 'concertService', '$timeout'];
})();