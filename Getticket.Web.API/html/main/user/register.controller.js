(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserRegisterController', MainUserRegisterController);

    MainUserRegisterController.$inject = ['UserService', '$scope'];
    function MainUserRegisterController(UserService, $scope) {
        var vm = this;

        $scope.emailpattern = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;

        $scope.submitted = false;
        $scope.passtype = 'password';
        $scope.user = {};
        $scope.roles = [
            {id: 1, name: 'R1'},
            {id: 2, name: 'R2'},
            {id: 3, name: 'R3'},
            {id: 4, name: 'R4'},
        ];

        $scope.register = register;
        $scope.generatePassword = generatePassword;


        function str_rand() {
            var result = '';
            var words = '0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM';
            var i;
            var position;
            var max_position = words.length - 1;
            for (i = 0; i < 10; ++i) {
                position = Math.floor(Math.random() * max_position);
                result = result + words.substring(position, position + 1);
            }
            return result;
        }

        function generatePassword(c) {
            if ($('#generatePassword').is(':checked')) {
                // $('#password').attr('type', 'text');
                // $('#password').attr('value', str_rand());
                $scope.passtype = 'text';
                $scope.user.password = str_rand();
            }
            else {
                // $('#password').attr('type', 'password');
                // $('#password').attr('value', '');
                $scope.passtype = 'password';
                $scope.user.password = '';
            }
        };
        function register(user) {
            $scope.user = angular.copy(user);
            $scope.submitted = true;

            console.log(user);
        };

    }


})();
