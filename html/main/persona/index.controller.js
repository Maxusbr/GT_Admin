(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaIndexController', MainPersonaIndexController);

    MainPersonaIndexController.$inject = ['$rootScope', '$stateParams'];

    function MainPersonaIndexController($rootScope, $stateParams) {
        $rootScope.id = $stateParams.id;
    }
})();