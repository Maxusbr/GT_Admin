(function () {
    'use strict';

    function dictionaryConcertHallController($rootScope, $scope, personService, concertService) {
        var vm = this;
        $scope.clear = function() {
            $scope.concertPlace = {}
            $scope.concertHall = {}
        }
        $scope.clear();
        $scope.clearHalls = function () {
            $scope.concertHall = {}
        }

        $scope.getPlaces = function (value) {
            $scope.places = [];
            return personService.getPlaces(value).then(function (response) {
                $scope.places.push.apply($scope.places, response.data);
                return response.data.map(function (item) {
                    return item;
                });
            });
        }
        $scope.isPlace = function (place) {
            return place && typeof place !== 'string';
        }

        $scope.$watch('place', function (data) {
            if (!$scope.isPlace(data) || !data.Id) return;
            $rootScope.countryPlace = data;
        });
        $scope.place = $rootScope.countryPlace;

        $scope.saveConcertPlace = function (place) {
            if (!place.Name) return;
            place.PlaceId = $scope.place.Id;
            concertService.saveConcertPlace(place, function (data) {
                place = {}
                $rootScope.getHalls($scope.place.Id);
            });
        }
        $scope.saveHalls = function (place) {
            if (!place.Name || !$scope.concertPlace.Id) return;
            place.PlaceId = $scope.concertPlace.Id;
            concertService.saveHall(place, function (data) {
                place = {}
                $rootScope.getHalls($scope.place.Id);
            });
        }
        $scope.selectPlace = function (place) {
            $scope.concertPlace = place;
        }
        $scope.selectHall = function (place) {
            $scope.concertHall = place;
            $scope.concertPlace = $rootScope.concertPlaces.filter(function (item) { return item.Id === place.PlaceId; })[0];
        }

    }

    angular
        .module('app')
        .controller('dictionaryConcertHallController', dictionaryConcertHallController);

    dictionaryConcertHallController.$inject = ['$rootScope', '$scope', 'personService', 'concertService'];
})();