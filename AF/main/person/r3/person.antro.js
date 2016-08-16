(function () {
    'use strict';

    function PersonAntroController($rootScope, $scope, personService) {
        var vm = this;

        personService.getAntro($rootScope.personId, function (data) {
            $scope.antro = [];
            $scope.antro.push.apply($scope.antro, data);
        });

        $rootScope.addAntro = function add_connection() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.antro.editor.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('PersonAntroController', PersonAntroController);

    PersonAntroController.$inject = ['$rootScope', '$scope', 'personService'];
})();