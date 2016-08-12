(function () {
    'use strict';

    angular
        .module('app')
        .controller('UserInviteController', UserInviteController);

    UserInviteController.$inject = ['$rootScope'];
    function UserInviteController($rootScope) {
        var vm = this;
    }
})();