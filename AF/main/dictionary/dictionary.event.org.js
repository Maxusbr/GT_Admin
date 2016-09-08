(function () {
    'use strict';

    function DictionaryEventOrgController($rootScope, $scope, $cookieStore, personService, $timeout) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $scope.editItem = { Name: "" };

        $scope.saveChanges = function () {
            var list = [$scope.editItem];
            personService.saveEntitieTypes(list, 'social', function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.getLinkTypes();
                $timeout(function () {
                    return $rootScope.closeMe('disDicEventOrg');
                }, 3000);
            });


        }
    }

    angular
        .module('app')
        .controller('DictionaryEventOrgController', DictionaryEventOrgController);

    DictionaryEventOrgController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService', '$timeout'];
})();