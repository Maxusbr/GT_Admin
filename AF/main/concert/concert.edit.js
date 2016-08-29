(function () {
    'use strict';

    function concertEditController($rootScope, $scope, concertService, personService, $filter) {
        var vm = this;
        vm.organizers = [];

        $scope.concert = $rootScope.editedConcert;
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
        $rootScope.getHalls = function (id) {
            $rootScope.concertPlaces = [];
            $scope.Promise = concertService.getHalls(id).then(function (response) {
                $rootScope.concertPlaces.push.apply($rootScope.concertPlaces, response.data);
                $scope.concertPlaceId = $scope.concert.ConcertPlaceId;
                $scope.hallId = $scope.concert.HallId;
            });
        }
        $scope.$watch('place', function (data) {
            if (!$scope.isPlace(data) || !data.Id) return;
            $rootScope.getHalls(data.Id);
        });
        if ($scope.concert && $scope.concert.ConcertPlace)
            $scope.place = $scope.concert.ConcertPlace.CountryPlace;

        $scope.existHall = function (id) {
            var place = $rootScope.concertPlaces.filter(function (item) { return item.Id === id; })[0];
            return place && place.Halls && place.Halls.length;
        }
        $scope.getHall = function (id) {
            var place = $rootScope.concertPlaces.filter(function (item) { return item.Id === id; })[0];
            return place && place.Halls ? place.Halls : [];
        }
        $scope.editPlace = function () {
            $rootScope.countryPlace = $scope.place;
            $rootScope.$watch('countryPlace', function (place) {
                $scope.place = place;
            });
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.concert.hall.html', 3200);
        }

        // Series
        concertService.getSeries(function (data) {
            $scope.series = [];
            $scope.series.push.apply($scope.series, data);
        });
        $scope.loadSeries = function (query) {
            if (!$scope.series) return [];
            var result = $scope.series.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }

        $scope.saveConcert = function () {
            $scope.concert.ConcertPlaceId = $scope.concertPlaceId;
            $scope.concert.HallId = $scope.hallId;
            concertService.saveConcert($scope.concert, function (data) {
                $rootScope.loadConcerts();
                if ($rootScope.getConcert)
                    $rootScope.getConcert($scope.concert.Id);
                app.closeFive();
                app.closeView('concertEdit');
            });
        }

    }

    angular
        .module('app')
        .controller('concertEditController', concertEditController);

    concertEditController.$inject = ['$rootScope', '$scope', 'concertService', 'personService', '$filter'];
})();