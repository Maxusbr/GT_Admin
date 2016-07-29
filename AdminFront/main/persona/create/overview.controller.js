(function () {
    'use strict';

    function MainPersonaCreateOverviewController($scope, $stateParams, $rootScope, $location) {
        var vm = this;
        if (!$rootScope.person) {
            $location.path("/main/persona/create");
            return;
        }
    }

    angular
        .module('app')
        .controller('MainPersonaCreateOverviewController', MainPersonaCreateOverviewController);

    MainPersonaCreateOverviewController.$inject = ['$scope', '$stateParams', '$rootScope', '$location'];
})();