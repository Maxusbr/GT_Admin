﻿(function () {
    'use strict';

    function PersonFactsController($rootScope) {
        var vm = this;

        $rootScope.addFact = function add_fact(){
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('PersonFactsController', PersonFactsController);

    PersonFactsController.$inject = ['$rootScope'];
})();