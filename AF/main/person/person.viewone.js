﻿(function () {
    'use strict';

    function personViewoneController($rootScope, $scope, personService) {
        var vm = this;
        $scope.Id = $rootScope.Id;
        personService.getPerson($scope.Id, function(data) {
            $scope.person = data;
        });
        $rootScope.editPerson = function edit_person(){
            app.closeThird();
            app.loadContentView('peron.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('personViewoneController', personViewoneController);

    personViewoneController.$inject = ['$rootScope', '$scope', 'personService'];
})();