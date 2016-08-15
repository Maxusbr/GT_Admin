(function () {
    'use strict';

    function personNotesAdesController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');
    }

    angular
        .module('app')
        .controller('personNotesAdesController', personNotesAdesController);

    personNotesAdesController.$inject = ['$rootScope', '$cookieStore'];
})();