(function () {
    'use strict';

    function dictConcertActorGroupController($rootScope, $scope, concertService) {
        var vm = this;

        vm.editItem = $rootScope.editedGroup? $rootScope.editedGroup: { Name: "" };

        $scope.saveChanges = function () {
            if (vm.editItem)
                concertService.saveActorGroup(vm.editItem, $rootScope.getGroups);
            $rootScope.closeMe('disoncertActorGroup');
        }
    }

    angular
        .module('app')
        .controller('dictConcertActorGroupController', dictConcertActorGroupController);

    dictConcertActorGroupController.$inject = ['$rootScope', '$scope', 'concertService'];
})();