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

        $scope.editItemCat = { Name: "" };
        $scope.editItemSubCat = { Name: "" };

        $scope.clickCategory = function (id) {

        }

        $scope.saveCategories = function () {
            //TODO: save changes to server
        }

        $scope.saveSubCategories = function () {
            //TODO: save changes to server
            
        }
    }

    angular
        .module('app')
        .controller('DictionaryEventCategoryController', DictionaryEventCategoryController);

    DictionaryEventCategoryController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService'];
})();