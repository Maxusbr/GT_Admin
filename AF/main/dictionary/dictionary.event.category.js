(function () {
    'use strict';

    function DictionaryEventCategoryController($rootScope, $scope, $cookieStore, personService) {
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
        }
    }

    angular
        .module('app')
        .controller('DictionaryEventCategoryController', DictionaryEventCategoryController);

    DictionaryEventCategoryController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService'];
})();