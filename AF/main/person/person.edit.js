(function () {
    'use strict';

    function PersonEditController($rootScope) {
        var vm = this;
    }

    angular
        .module('app')
        .controller('PersonEditController', PersonEditController);

    PersonEditController.$inject = ['$rootScope'];
})();