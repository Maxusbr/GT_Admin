(function () {
    'use strict';

    function PersonCreatController($rootScope, $scope, $timeout, personService) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
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
            if ($scope.person.Sex == undefined) {
                $scope.errorYes = true;
                $scope.message = 'Пол обязательное поле';
                $scope.showMessage = true;
                return;
                console.log('save person click');
            }
            if ($scope.place) {
                $scope.person.Place = $scope.place.Name;
                $scope.person.Country = $scope.place.CountryName;
            }
            console.log($scope.person);
            personService.Save($scope.person, function (data) {
                personService.getPersons();
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('personEdit');
                    }, timeoutMsgShow);
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