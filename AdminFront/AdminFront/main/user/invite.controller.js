(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserInviteController', MainUserInviteController);

    MainUserInviteController.$inject = ['UserService', '$scope'];
    function MainUserInviteController(UserService, $scope) {
        var vm = this;

        $scope.user = {};

        $scope.invite = function (user) {
            $scope.user = angular.copy(user);
            console.log(user);
        };
    }

})();
