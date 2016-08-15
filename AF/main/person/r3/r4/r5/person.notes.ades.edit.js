(function () {
    'use strict';

    function personNotesAdesEditController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');
    }

    angular
        .module('app')
        .controller('personNotesAdesEditController', personNotesAdesEditController);

    personNotesAdesEditController.$inject = ['$rootScope', '$cookieStore'];
})();