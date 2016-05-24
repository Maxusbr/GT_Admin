(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserInviteController', MainUserInviteController);

    MainUserInviteController.$inject = ['UserService', '$rootScope'];
    function MainUserInviteController(UserService, $rootScope) {
        var vm = this;

    }

})();
