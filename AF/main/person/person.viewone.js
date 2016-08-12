(function () {
    'use strict';

    function PeronViewoneController($rootScope) {
        var vm = this;
    }

    angular
        .module('app')
        .controller('PeronViewoneController', PeronViewoneController);

    PeronViewoneController.$inject = ['$rootScope'];
})();