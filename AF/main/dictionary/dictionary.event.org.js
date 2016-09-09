(function () {
    'use strict';

    function DictionaryEventOrgController($rootScope, $scope, $cookieStore, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
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
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return $rootScope.closeMe('disDicEventOrg');
                    }, timeoutMsgShow);
            });


        }
    }

    angular
        .module('app')
        .controller('DictionaryEventOrgController', DictionaryEventOrgController);

    DictionaryEventOrgController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService', '$timeout'];
})();