(function () {
    'use strict';

    function DictionaryPersonWTFController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.dictionaryWTF = [
            {
                Id:1,
                Name:'facebook'
            }
        ];

        $rootScope.editItem;

        $rootScope.saveChanges = function save_changes() {
            //TODO: save changes to server
            //TODO: refresh dictionary list
        }
    }

    angular
        .module('app')
        .controller('DictionaryPersonWTFController', DictionaryPersonWTFController);

    DictionaryPersonWTFController.$inject = ['$rootScope', '$cookieStore'];
})();