(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserInviteController', MainUserInviteController);

    MainUserInviteController.$inject = ['UserService', '$scope'];
    function MainUserInviteController(UserService, $scope) {
        var vm = this;

        $scope.user = {};
        $scope.roles = [
            {id: 1, name: 'R1'},
            {id: 2, name: 'R2'},
            {id: 3, name: 'R3'},
            {id: 4, name: 'R4'},
        ];

        $scope.invite = function (user) {
            $scope.user = angular.copy(user);
            console.log(user);
        };
    }

})();
