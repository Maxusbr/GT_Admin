(function () {
    'use strict';

    function personNotesAdesEditController($rootScope, $cookieStore) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');
    }

    angular
        .module('app')
        .controller('personNotesAdesEditController', personNotesAdesEditController);

    personNotesAdesEditController.$inject = ['$rootScope', '$cookieStore'];
})();