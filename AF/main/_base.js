(function () {
    'use strict';

    function baseController($rootScope) {
        var vm = this;
    }

    angular
        .module('app')
        .controller('baseController', baseController);

    baseController.$inject = ['$rootScope'];
})();