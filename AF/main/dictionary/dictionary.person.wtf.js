(function () {
    'use strict';

    function DictionaryPersonWTFController($rootScope, $scope, $filter) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        $scope.editItem = {Id: 0, Name: ""};

        $scope.saveChanges = function (item) {
            $rootScope.pageSchema.UserPageCategoryId = item.Id;
            $rootScope.pageSchema.UserPageCategory = item.Name;
            var cat = $rootScope.userPageCategories.filter(function(el) {
                return el.Id === item.Id;
            });
            if (cat.length) {
                cat.Name = item.Name;
            } else {
                $rootScope.userPageCategories.push(item);
            }
            app.closeView('disDicPersonWTF');
        }
    }

    angular
        .module('app')
        .controller('DictionaryPersonWTFController', DictionaryPersonWTFController);

    DictionaryPersonWTFController.$inject = ['$rootScope', '$scope', '$filter'];
})();