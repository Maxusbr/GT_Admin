(function () {
    'use strict';

    function PersonAntroController($rootScope, $scope, personService) {
        var vm = this;
        $rootScope.getAntros = function () {
            $scope.Promise = personService.getAntro($rootScope.personId, function (data) {
                $scope.antro = [];
                $scope.antro.push.apply($scope.antro, data);
                $scope.antro.forEach(function (item) {
                    if (item.LastChange)
                        item.LastChange.localdate = new Date(item.LastChange.Date);
                });
            });
        }
        $rootScope.getAntros();

        $rootScope.addAntro = function (item) {
            if (item == undefined) item = { Id: 0, Liks: [], IdPerson: $rootScope.personId }
            $rootScope.editedAntro = item;
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.antro.editor.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('PersonAntroController', PersonAntroController);

    PersonAntroController.$inject = ['$rootScope', '$scope', 'personService'];
})();