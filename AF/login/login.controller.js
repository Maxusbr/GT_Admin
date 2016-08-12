(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', 'AuthenticationService', 'FlashService'];
    function LoginController($location, AuthenticationService, FlashService, $http) {
        var vm = this;

        vm.login = login;
        vm.emailpattern = /^[a-z]+[a-z0-9._]+@[a-z]+\.[a-z.]{2,5}$/;

        (function initController() {
            // reset login status
            AuthenticationService.ClearCredentials();
        })();

        //$scope.clickLogin = login();
        

        function login() {
            console.log('click login');
            vm.dataLoading = true;
            AuthenticationService.Login(vm.user.username, vm.user.password, function (response) {
                vm.dataLoading = false;
                if (response) {
                    //AuthenticationService.set('authorizationData', { token: response.access_token, userName: username });
                    AuthenticationService.SetCredentials(vm.user.username, vm.user.password, response.access_token);
                    $location.path('/');
                } else {
                    FlashService.Error(response.message);
                }
            });
        };

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();
