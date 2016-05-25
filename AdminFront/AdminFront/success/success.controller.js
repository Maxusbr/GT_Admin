(function () {
	'use strict';

	angular
		.module('app')
		.controller('SuccessController', SuccessController);

	SuccessController.$inject = ['UserService', '$location', '$rootScope', 'FlashService'];
	function SuccessController(UserService, $location, $rootScope, $cookies) {
		var vm = this;
	}

})();