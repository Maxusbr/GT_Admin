(function () {
    'use strict';

    function dictConcertActorGroupController($rootScope, $scope, concertService, $timeout) {
        var vm = this;

        vm.editItem = $rootScope.editedGroup? $rootScope.editedGroup: { Name: "" };

        $scope.saveChanges = function () {
            if (vm.editItem)
                concertService.saveActorGroup(vm.editItem, function (data) {
                    //TODO show msg
                    $rootScope.getGroups();
                    $timeout(function () {
                        return app.closeView('disoncertActorGroup');
                    }, 3000);
                });
        }
    }

    angular
        .module('app')
        .controller('dictConcertActorGroupController', dictConcertActorGroupController);

    dictConcertActorGroupController.$inject = ['$rootScope', '$scope', 'concertService', '$timeout'];
})();