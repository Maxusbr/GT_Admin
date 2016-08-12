(function () {
    'use strict';

    angular
        .module('app')
        .controller('UserCreateController', UserCreateController);

    UserCreateController.$inject = ['$rootScope'];
    function UserCreateController($rootScope) {
        var vm = this;
    }
})();