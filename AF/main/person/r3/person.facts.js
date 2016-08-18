﻿(function () {
    'use strict';

    function PersonFactsController($rootScope, $scope, personService) {
        var vm = this;
        $rootScope.getFacts = function() {
            personService.getFact($rootScope.personId, function (data) {
                $scope.factlist = data;

                //data.forEach(function (item) {
                //    $scope.factlist.push.apply($scope.factlist, item.List);
                //});
            });
        }

        $rootScope.addFact = function addFact() {
            $rootScope.editedFact = {}
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.editor.html', 3200);
        }
        $rootScope.editFact = function (item) {
            $rootScope.editedFact = item;
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.fact.editor.html', 3200);
        }
        $rootScope.getFacts();

        if (!$rootScope.facttypes)
            personService.getFactTypes(function (data) {
                $rootScope.facttypes = [];
                $rootScope.facttypes.push.apply($rootScope.facttypes, data);
            });

        
    }

    angular
        .module('app')
        .controller('PersonFactsController', PersonFactsController);

    PersonFactsController.$inject = ['$rootScope', '$scope', 'personService'];
})();