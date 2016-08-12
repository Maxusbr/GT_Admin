(function () {
    'use strict';

    function PersonFactsController($rootScope) {
        var vm = this;
    }

    angular
        .module('app')
        .controller('PersonFactsController', PersonFactsController);

    PersonFactsController.$inject = ['$rootScope'];
})();