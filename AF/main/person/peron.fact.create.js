(function () {
    'use strict';

    function PersonFactCreateController($rootScope) {
        var vm = this;
    }

    angular
        .module('app')
        .controller('PersonFactCreateController', PersonFactCreateController);

    PersonFactCreateController.$inject = ['$rootScope'];
})();