(function () {
    'use strict';

    function baseController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');
    }

    angular
        .module('app')
        .controller('baseController', baseController);

    baseController.$inject = ['$rootScope', '$cookieStore'];
})();