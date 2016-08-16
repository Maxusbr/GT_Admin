(function () {
    'use strict';

    function dictionaryAntroTypesController($rootScope, $cookieStore) {
        var vm = this;
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