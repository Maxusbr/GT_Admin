(function () {
    'use strict';

    angular
        .module('app')
        .controller('UserEditController', UserEditController);

    UserEditController.$inject = ['$rootScope'];
    function UserEditController($rootScope) {
        var vm = this;
    }
})();