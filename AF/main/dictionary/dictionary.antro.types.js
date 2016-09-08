(function () {
    'use strict';

    function dictionaryAntroTypesController($rootScope, $cookieStore) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

            $rootScope.saveChanges = function save_changes(){
                
            }
    }

    angular
        .module('app')
        .controller('dictionaryAntroTypesController', dictionaryAntroTypesController);

    dictionaryAntroTypesController.$inject = ['$rootScope', '$cookieStore'];
})();