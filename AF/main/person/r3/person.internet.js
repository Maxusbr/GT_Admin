(function () {
    'use strict';

    function PersonInternetController($rootScope) {
        var vm = this;

        $rootScope.addInternet = function add_connection() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('PersonInternetController', PersonInternetController);

    PersonInternetController.$inject = ['$rootScope'];
})();