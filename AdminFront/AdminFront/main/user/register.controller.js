(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserRegisterController', MainUserRegisterController);

    MainUserRegisterController.$inject = ['UserService', '$rootScope'];
    function MainUserRegisterController(UserService, $rootScope) {
        var vm = this;

    }


})();
