(function () {
    'use strict';

    function PersonMediaController($rootScope) {
        var vm = this;

        $rootScope.addFact = function add_fact() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('PersonMediaController', PersonMediaController);

    PersonMediaController.$inject = ['$rootScope'];
})();