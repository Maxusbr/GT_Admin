(function () {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
    function RegisterController(UserService, $location, $rootScope, FlashService) {
        var vm = this;

        vm.user = {};
        vm.passtype = 'password';
        vm.emailpattern = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;

        vm.register = register;
        vm.generatePassword = generatePassword;
        vm.response = {};

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

        function generatePassword() {
            if ($('#generatePassword').is(':checked')) {
                vm.passtype = 'text';
                vm.user.password = str_rand();
            }
            else {
                vm.passtype = 'password';
                vm.user.password = '';
            }
        };

        function register() {
            vm.dataLoading = true;
            //if ($scope.form.$valid) {
                var user = {
                    Name: vm.user.first_name,
                    LastName: vm.user.last_name,
                    Company: vm.user.company,
                    Position: vm.user.post,
                    Email: vm.user.username,
                    Phone: vm.user.phone,
                    Password: vm.user.password,
                    RoleId: 2
                }
                UserService.registerUser(user)
                    .success(function (response) {
                        vm.dataLoading = false;
                        vm.response = response;
                        if (response.status === 'success') {
                            $location.path('/login');
                        }
                    })
                    .error(function (response) { vm.dataLoading = false; vm.response = response;  });
            //}
            //UserService.Create(vm.user)
            //    .then(function (response) {
            //        if (response.success) {
            //            FlashService.Success('Registration successful', true);
            //            $location.path('/login');
            //        } else {
            //            FlashService.Error(response.message);
            //            vm.dataLoading = false;
            //        }
            //    });
        }
    }

})();
