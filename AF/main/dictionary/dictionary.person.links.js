(function () {
    'use strict';

    function DictionaryPersonLinkController($rootScope, $scope, $cookieStore, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
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
            var list = [$scope.editItem];
            personService.saveEntitieTypes(list, 'social', function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.getLinkTypes();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return $rootScope.closeMe('disDicPersonLinks');
                    }, timeoutMsgShow);
            });


        }
    }

    angular
        .module('app')
        .controller('DictionaryPersonLinkController', DictionaryPersonLinkController);

    DictionaryPersonLinkController.$inject = ['$rootScope', '$scope', '$cookieStore', 'personService', '$timeout'];
})();