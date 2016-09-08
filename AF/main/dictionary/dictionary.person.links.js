(function () {
    'use strict';

    function DictionaryPersonLinkController($rootScope, $scope, $cookieStore, personService, $timeout) {
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
            personService.saveEntitieTypes(list, 'social', function (data) {
                //TODO show msg
                $rootScope.getLinkTypes();
                $timeout(function () {
                    return $rootScope.closeMe('disDicPersonLinks');
                }, 3000);
            });
            
            
        }
    }

    angular
        .module('app')
        .controller('DictionaryPersonLinkController', DictionaryPersonLinkController);

    DictionaryPersonLinkController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService', '$timeout'];
})();