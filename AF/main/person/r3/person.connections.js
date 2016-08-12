(function () {
    'use strict';

    function PersonConnectionsController($rootScope) {
        var vm = this;

        $rootScope.addConnection= function add_connection() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('PersonConnectionsController', PersonConnectionsController);

    PersonConnectionsController.$inject = ['$rootScope'];
})();