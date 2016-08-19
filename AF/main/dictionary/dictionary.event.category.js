(function () {
    'use strict';

    function DictionaryEventCategoryController($rootScope, $scope, $cookieStore, eventService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        //$rootScope.dictionaryLinks = [
        //    {
        //        Id:1,
        //        Name:'facebook'
        //    }
        //];
        if (!$rootScope.eventCategories) {
            eventService.getCategories(function (data) {
                $rootScope.eventCategories = data;
                $scope.baseCategory = data.filter(function (item) {
                    return item.IdParent == null;
                });
            });
        } else $scope.baseCategory = $rootScope.eventCategories.filter(function (item) {
            return item.IdParent == null;
        });
        $scope.getChildCategory = function (id) {
            if (!$rootScope.eventCategories) return [];
            return $rootScope.eventCategories.filter(function (item) {
                return item.IdParent === id;
            });
        }

        $scope.editItemCat = {};
        $scope.editItemSubCat = {};

        $scope.selectCat = function (item) {
            $scope.editItemCat = item;
        }
        $scope.selectSubCat = function (item) {
            $scope.editItemSubCat = item;
        }

        $scope.saveCategories = function () {
            //TODO: save changes to server
        }

        $scope.saveSubCategories = function () {
            if (!$scope.editItemSubCat.Name || !$scope.editItemCat.Id) return;
            $scope.editItemSubCat.IdParent = $scope.editItemCat.Id;
            eventService.SaveCategory($scope.editItemSubCat, function (data) {
                $scope.editItemSubCat = {}
                eventService.getCategories(function (data) {
                    $rootScope.eventCategories = data;
                    $scope.baseCategory = data.filter(function (item) {
                        return item.IdParent == null;
                    });
                });
            });
        }
    }

    angular
        .module('app')
        .controller('DictionaryEventCategoryController', DictionaryEventCategoryController);

    DictionaryEventCategoryController.$inject = ['$rootScope', '$scope', '$cookieStore', 'eventService'];
})();