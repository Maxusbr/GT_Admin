﻿(function () {
    'use strict';

    function PersonFactEditorController($rootScope, $scope, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        $rootScope.saveFact = function save_fact() {
            console.log('save fact click');
            $rootScope.editedFact.id_Person = $rootScope.personId;
            personService.saveEntity($rootScope.personId, $rootScope.editedFact, 'fact', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                if ($rootScope.getPersonCounts)
                    $rootScope.getPersonCounts();
                $rootScope.getFacts();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('personFactEdit');
                    }, timeoutMsgShow);

            });
        }

        $scope.setConnection = function (id) {
            if (!id) return;
            var type = $rootScope.facttypes.filter(function (item) {
                return item.Id === id;
            })[0];
            $rootScope.editedFact.FactType = type;
        }
    }

    angular
        .module('app')
        .controller('PersonFactEditorController', PersonFactEditorController);

    PersonFactEditorController.$inject = ['$rootScope', '$scope', 'personService', '$timeout'];
})();