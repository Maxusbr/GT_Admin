(function () {
    'use strict';

    angular
        .module('app')
        .controller('UserInviteController', UserInviteController);

    UserInviteController.$inject = ['$rootScope', '$scope', 'userService'];
    function UserInviteController($rootScope, $scope, userService) {
        var vm = this;
        $scope.user = {}
        if (!$rootScope.roles)
            userService.getListRoles(function (data) {
                if (!data.error)
                    $rootScope.roles = data;
            });

        $scope.invite = function() {
            userService.inviteUser($scope.user, function (data) {
                $rootScope.getListUsers();
                app.closeView('userInvite');
            });
        }
    }
})();