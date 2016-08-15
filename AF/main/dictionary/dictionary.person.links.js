(function () {
    'use strict';

    function DictionaryPersonLinkController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.dictionaryLinks = [
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
        .controller('DictionaryPersonLinkController', DictionaryPersonLinkController);

    DictionaryPersonLinkController.$inject = ['$rootScope', '$cookieStore'];
})();