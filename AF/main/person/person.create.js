(function () {
    'use strict';

    function PersonCreatController($rootScope, $scope, personService) {
        var vm = this;
        $scope.sexes = [{ id: 0, name: "Мужской" }, { id: 1, name: "Женский" }];
        $scope.getPlaces = function (value) {
            $scope.places = [];
        }
    }

    angular
        .module('app')
        .controller('PersonCreatController', PersonCreatController);

    PersonCreatController.$inject = ['$rootScope', '$scope', 'personService'];
})();