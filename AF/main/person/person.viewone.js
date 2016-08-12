(function () {
    'use strict';

    function personViewoneController($rootScope) {
        var vm = this;
    }

    angular
        .module('app')
        .controller('personViewoneController', personViewoneController);

    personViewoneController.$inject = ['$rootScope'];
})();