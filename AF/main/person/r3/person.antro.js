(function () {
    'use strict';

    function PersonAntroController($rootScope) {
        var vm = this;

        $rootScope.addAntro = function add_connection() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('PersonAntroController', PersonAntroController);

    PersonAntroController.$inject = ['$rootScope'];
})();