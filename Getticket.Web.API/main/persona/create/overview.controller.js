(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaCreateOverviewController', MainPersonaCreateOverviewController);

    MainPersonaCreateOverviewController.$inject = ['$scope', '$stateParams'];

    function MainPersonaCreateOverviewController($scope, $stateParams) {
        var vm = this;
    }
})();