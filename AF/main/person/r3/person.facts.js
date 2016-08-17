﻿(function () {
    'use strict';

    function PersonFactsController($rootScope, $scope, personService) {
        var vm = this;

        personService.getFact($rootScope.personId, function (data) {
            $scope.factlist = [];
            data.forEach(function (item) {
                $scope.factlist.push.apply($scope.factlist, item.List);
            });
        });

        $rootScope.addFact = function addFact(){
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.create.html', 3200);
        }
        $rootScope.editFact = function addFact(){
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.editor.html', 3200);
        }

    }

    angular
        .module('app')
        .controller('PersonFactsController', PersonFactsController);

    PersonFactsController.$inject = ['$rootScope', '$scope', 'personService'];
})();