(function () {
	'use strict';

	angular
		.module('app')
		.controller('RecoveryConfirmController', RecoveryConfirmController);

	RecoveryConfirmController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
	function RecoveryConfirmController(UserService, $location, $rootScope, $routeParams) {
		var vm = this;

		vm.key = $routeParams.key;

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