(function () {
    'use strict';

    function DictionaryConcertCityController($rootScope, $scope, $cookieStore, eventService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        //$rootScope.dictionaryLinks = [
        //    {
        //        Id:1,
        //        Name:'facebook'
        //    }
        //];
        $rootScope.$watch('eventCategories', function (items) {
            if (!items) return;
            $scope.baseCategory = items.filter(function (item) {
                return item.IdParent == null;
            });
        });
        if (!$rootScope.eventCategories) 
            eventService.getCategories(function (data) {
                $rootScope.eventCategories = data;
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
            $scope.editItemCat = $rootScope.eventCategories.filter(function (el) { return el.Id === item.IdParent; })[0];
        }

        $scope.saveCategories = function (cat) {
            if (!cat.Name) return;
            eventService.SaveCategory(cat, function (data) {
                cat = {}
                eventService.getCategories(function (data) {
                    $rootScope.eventCategories = data;
                });
            });
        }

        $scope.saveSubCategories = function () {
            if (!$scope.editItemCat.Id) return;
            $scope.editItemSubCat.IdParent = $scope.editItemCat.Id;
            $scope.saveCategories($scope.editItemSubCat);
        }
    }

    angular
        .module('app')
        .controller('DictionaryConcertCityController', DictionaryConcertCityController);

    DictionaryConcertCityController.$inject = ['$rootScope', '$scope', '$cookieStore', 'eventService'];
})();