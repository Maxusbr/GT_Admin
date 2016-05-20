(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserController', MainUserController);

    MainUserController.$inject = ['UserService', '$rootScope'];
    function MainUserController(UserService, $rootScope) {
        var vm = this;

    }

})();