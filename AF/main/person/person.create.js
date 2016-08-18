(function () {
    'use strict';

    function PersonCreatController($rootScope, $scope, personService) {
        var vm = this;
        $scope.sexes = [{ id: 0, name: "Мужской" }, { id: 1, name: "Женский" }];
        $scope.person = { Id: 0 };
        $scope.getPlaces = function (value) {
            $scope.places = [];
            return personService.getPlaces(value).then(function (response) {
                $scope.places.push.apply($scope.places, response.data);
                return response.data.map(function (item) {
                    return item;
                });
            });
        }
        $scope.saveNewPerson = function () {
            console.log('save person click');
            if ($scope.place) {
                $scope.person.Place = $scope.place.Name;
                $scope.person.Country = $scope.place.CountryName;
            }
            console.log($scope.person);
            personService.Save($scope.person, function (data) {
                personService.getPersons(app.closeView('personEdit'));
            });
        }
    }

    angular
        .module('app')
        .controller('PersonCreatController', PersonCreatController);

    PersonCreatController.$inject = ['$rootScope', '$scope', 'personService'];
})();