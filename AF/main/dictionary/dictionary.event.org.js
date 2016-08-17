(function () {
    'use strict';

    function DictionaryEventOrgController($rootScope, $scope, $cookieStore, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $scope.editItem = { Name: "" };

        $scope.saveChanges = function () {
            //TODO: save changes to server
            var list = [$scope.editItem];
            personService.saveEntitieTypes(list, 'social', $rootScope.getLinkTypes);
            $rootScope.closeMe('disDicEventOrg');
        }
    }

    angular
        .module('app')
        .controller('DictionaryEventOrgController', DictionaryEventOrgController);

    DictionaryEventOrgController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService'];
})();