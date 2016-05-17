(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'AuthenticationService', 'FlashService'];
    function LoginController($location, AuthenticationService, FlashService, $cookies) {
        var vm = this;

        vm.user = {};

        vm.login = login;

        (function initController() {
            // reset login status
            AuthenticationService.ClearCredentials();
        })();

        function login() {
            vm.dataLoading = true;
            AuthenticationService.Login(vm.user)
              .success(function(data, status) {
                    console.info('Login success!');
                    AuthenticationService.SetCredentials(data, vm.user);
                    $location.path('/');

              });
        }
    }

})();
