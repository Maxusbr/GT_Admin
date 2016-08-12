(function () {
    'use strict';

    function PersonFactCreateController($rootScope) {
        var vm = this;

        $rootScope.saveFact = function save_fact() {
            console.log('save fact click');
            //TODO: save changes or create new
            //TODO: close this view
            //TODO: refresh facts table
        }
    }

    angular
        .module('app')
        .controller('PersonFactCreateController', PersonFactCreateController);

    PersonFactCreateController.$inject = ['$rootScope'];
})();