(function () {
    'use strict';

    function PersonFactEditorController($rootScope, $scope, personService) {
        var vm = this;

        $rootScope.saveFact = function save_fact() {
            console.log('save fact click');
            //TODO: save changes or create new
            //TODO: close this view
            //TODO: refresh facts table

            $rootScope.editedFact.id_Person = $rootScope.personId;
            personService.saveEntity($rootScope.personId, $rootScope.editedFact, 'fact', function (data) {
                $rootScope.getFacts();
                app.closeView('personFactEdit');
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

    PersonFactEditorController.$inject = ['$rootScope', '$scope', 'personService'];
})();