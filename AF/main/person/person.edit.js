(function () {
    'use strict';

    function PersonEditController($rootScope, $scope, $timeout, personService) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
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
        $scope.save = function () {
            if (typeof $scope.person.Place !== 'string') {
                $scope.person.Country = $scope.person.Place.CountryName;
                $scope.person.IdBithplace = $scope.person.Place.Id;
                var place = $scope.person.Place.Name;
                $scope.person.Place = place;
            }
            
            personService.Save($scope.person, function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.getPerson($scope.Id);
                $timeout(function () {
                    return app.closeView('personEdit');
                }, 3000);
            });
        }

        // Datepicker
        $scope.dateOptions = {
            formatYear: 'yyyy',
            startingDay: 1,
            showWeeks: false
        };

        $scope.open1 = function () {
            $scope.popup1.opened = true;
        };

        $scope.open2 = function () {
            $scope.popup2.opened = true;
        };
        $scope.popup1 = {
            opened: false
        };

        $scope.popup2 = {
            opened: false
        };
    }

    angular
        .module('app')
        .controller('PersonEditController', PersonEditController);

    PersonEditController.$inject = ['$rootScope', '$scope', '$timeout', 'personService'];
})();