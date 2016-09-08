(function () {
    'use strict';

    function PersonCreatController($rootScope, $scope, $timeout, personService) {
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
                personService.getPersons();
                //TODO show msg
                $timeout(function () {
                    return app.closeView('personEdit');
                }, 3000);
            });
        }
        $scope.open1 = function () {
            $scope.popup1.opened = true;
        };

        $scope.popup1 = {
            opened: false
        };
    }

    angular
        .module('app')
        .controller('PersonCreatController', PersonCreatController);

    PersonCreatController.$inject = ['$rootScope', '$scope', '$timeout', 'personService'];
})();