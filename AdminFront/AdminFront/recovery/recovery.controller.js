(function () {
	'use strict';

	angular
		.module('app')
		.controller('RecoveryController', RecoveryController);

	RecoveryController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
	function RecoveryController(UserService, $location, $rootScope) {
		var vm = this;

		vm.email = '';
		vm.emailCheck = false;

		vm.checkCode = function () {

			console.log(vm.email);
			if (vm.email.length > 4) {
				UserService.RecoveryPassword(vm.email)
					.success(function (data, status) {
						vm.emailCheck = true;
					});
			}

		};
	}

})();