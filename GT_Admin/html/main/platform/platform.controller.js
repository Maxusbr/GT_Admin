(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPlatformController', MainPlatformController);

    MainPlatformController.$inject = ['PlatformService', '$rootScope'];
    function MainPlatformController(PlatformService, $rootScope) {
        var vm = this;

    }

})();