(function () {
	'use strict';

	angular
		.module('app')
		.controller('ConfirmController', ConfirmController);

	ConfirmController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
	function ConfirmController(UserService, $location, $rootScope) {
		var vm = this;

		vm.code = '';

		vm.checkCode = function () {

			console.log(vm.code);

		};

		//function register() {
		//	vm.dataLoading = true;
		//	UserService.Create(vm.user)
		//		.then(function (response) {
		//			if (response.success) {
		//				FlashService.Success('Регистрация успешно произведена.', true);
		//				$location.path('/login');
		//			} else {
		//				FlashService.Error(response.message);
		//				vm.dataLoading = false;
		//			}
		//		});
		//}
	}

})();