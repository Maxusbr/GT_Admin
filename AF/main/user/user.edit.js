(function () {
    'use strict';

    angular
        .module('app')
        .controller('UserEditController', UserEditController);

    UserEditController.$inject = ['$rootScope', '$scope', 'userService'];
    function UserEditController($rootScope, $scope, userService) {
        var vm = this;
        $scope.user = $rootScope.editedUser;

        if (!$rootScope.roles)
            userService.getListRoles(function (data) {
                if (!data.error)
                    $rootScope.roles = data;
            });

        function strRand() {
            var result = '';
            var words = '0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM';
            var i;
            var position;
            var maxPosition = words.length - 1;
            for (i = 0; i < 10; ++i) {
                position = Math.floor(Math.random() * maxPosition);
                result = result + words.substring(position, position + 1);
            }
            return result;
        }

        $scope.generatePassword = function () {
            if ($('#generatePassword').is(':checked')) {
                $scope.passtype = 'text';
                $scope.user.Password = strRand();
            }
            else {
                $scope.passtype = 'password';
                $scope.user.Password = '';
            }
        }

        $scope.save = function () {
            userService.Update($scope.user).then(function (data) {
                if (data.success) {
                    userService.getListUsers();
                    app.closeView('userCreate');
                }
            });

        };
    }
})();