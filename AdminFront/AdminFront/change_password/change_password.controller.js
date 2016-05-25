(function () {
	'use strict';

	angular
		.module('app')
		.controller('ChangePasswordController', ChangePasswordController);

	ChangePasswordController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
	function ChangePasswordController(UserService, $location, $rootScope) {
		var vm = this;

		vm.password1 = '';
		vm.password2 = '';
		vm.passwordInvalid = false;

		vm.checkCode = function () {

			console.log('Passwords: ' + vm.password1 + ', ' + vm.password2);

			if (vm.password1 === vm.password2 && vm.password1.length >= 8) {
				vm.passwordInvalid = false;

				console.warn('Операция не может быть выполнена. так как для данного сервиса еще не введен API!');
			}
			else {
				vm.passwordInvalid = true;
			}


		};
	}

})();