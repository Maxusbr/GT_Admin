(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainEventCreateOverviewController', MainEventCreateOverviewController);

    MainEventCreateOverviewController.$inject = ['$scope', '$stateParams'];

    function MainEventCreateOverviewController($scope, $stateParams) {
        var vm = this;
    }
})();