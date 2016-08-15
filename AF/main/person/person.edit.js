(function () {
    'use strict';

    function PersonEditController($rootScope, $scope, personService) {
        var vm = this;
        $scope.Id = $rootScope.personId;
        $scope.Promise = personService.getPerson($scope.Id, function (data) {
            $scope.person = data;
            $scope.person.bithday = new Date($scope.person.Bithday);
        });
        $scope.sexes = [{ id: 0, name: "Мужской" }, { id: 1, name: "Женский" }];
        $scope.getPlaces = function (value) {
            $scope.places = [];
            return personService.getPlaces(value).then(function (response) {
                $scope.places.push.apply($scope.places, response.data);
                return response.data.map(function (item) {
                    return item;
                });
            });
        }
    }

    angular
        .module('app')
        .controller('PersonEditController', PersonEditController);

    PersonEditController.$inject = ['$rootScope', '$scope', 'personService'];
})();