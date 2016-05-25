(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainRoleController', MainRoleController);

    MainRoleController.$inject = ['RoleService', '$rootScope'];
    function MainRoleController(RoleService, $rootScope) {
        var vm = this;

    }

})();