﻿(function () {
    'use strict';

    function PersonConnectionstCreateController($rootScope, $scope) {
        var vm = this;
        $scope.fact = $rootScope.fact ? $rootScope.fact: {
            FactText: "",
            LastChange: {
                UserName: $rootScope.UserName,
                Date: new Date()
            },
            FactType: {
                Name: "",
                Descript: ""
            }
        };

        $rootScope.saveFact = function save_fact() {
            console.log('save fact click');
            //TODO: save changes or create new
            //TODO: close this view
            //TODO: refresh facts table
        }
    }

    angular
        .module('app')
        .controller('PersonConnectionstCreateController', PersonConnectionstCreateController);

    PersonConnectionstCreateController.$inject = ['$rootScope', '$scope'];
})();