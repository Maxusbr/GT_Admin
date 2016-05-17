(function () {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
    function RegisterController(UserService, $location, FlashService, $rootScope) {
        var vm = this;

        vm.register = register;

        function register() {
            vm.dataLoading = true;

            vm.user.lang = 'ru'; //$cookieStore.get('lang');
            vm.user.password_confirmation = vm.user.password;

            UserService.Create(vm.user)
              .success(function(data, status) {
                  $location.path('/success');
              });
                //.then(function (response) {
                //    if (response.success) {
                //        console.log(response);
                //        FlashService.Success('Регистрация успешно произведена.', true);
                //        $location.path('/login');
                //    } else {
                //        console.log(response);
                //        FlashService.Error(response.message);
                //        vm.dataLoading = false;
                //    }
                //});
            vm.dataLoading = false;
        }
    }

})();
