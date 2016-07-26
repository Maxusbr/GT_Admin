(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainEventsCreateController', MainEventsCreateController)
        .config(config);

    config.$inject = ['$stateProvider'];

    function config ($stateProvider) {
        $stateProvider
            
    }
    
    MainEventsCreateController.$inject = ['$scope', '$stateParams'];

    function MainEventsCreateController($scope, $stateParams) {
        // $scope.id = null;
    }
})();