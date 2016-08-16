(function () {
    'use strict';

    function DictionaryPersonLinkController($rootScope, $scope, $cookieStore, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        //$rootScope.dictionaryLinks = [
        //    {
        //        Id:1,
        //        Name:'facebook'
        //    }
        //];

        $scope.editItem = { Name: "" };

        $scope.saveChanges = function () {
            //TODO: save changes to server
            var list = [$scope.editItem];
            personService.saveEntitieTypes(list, 'social', $rootScope.getLinkTypes);
            $rootScope.closeMe('disDicPersonLinks');
        }
    }

    angular
        .module('app')
        .controller('DictionaryPersonLinkController', DictionaryPersonLinkController);

    DictionaryPersonLinkController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService'];
})();