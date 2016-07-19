(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaCreateController', MainPersonaCreateController)
        .config(config);

    config.$inject = ['$stateProvider'];

    function config ($stateProvider) {
        $stateProvider
            
    }
    
    MainPersonaCreateController.$inject = ['$scope', '$stateParams'];

    function MainPersonaCreateController($scope, $stateParams) {
        // $scope.id = null;
    }
})();