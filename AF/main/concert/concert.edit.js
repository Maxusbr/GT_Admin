(function () {
    'use strict';

    function concertEditController($rootScope, $scope, concertService, personService, $filter, $timeout) {
        var vm = this;
        vm.concertPlaceId = vm.hallId = 0;

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
                if($scope.concert.ConcertPlaceId)
                    vm.concertPlaceId = $scope.concert.ConcertPlaceId;
                if ($scope.concert.HallId)
                    vm.hallId = $scope.concert.HallId;
            });
        }
        $scope.$watch('place', function (data) {
            if (!$scope.isPlace(data) || !data.Id) return;
            $rootScope.getHalls(data.Id);
        });
        if ($scope.concert && $scope.concert.ConcertPlace)
            $scope.place = $scope.concert.ConcertPlace.CountryPlace;

        $scope.existHall = function (id) {
            if (!id) return false;
            var place = $rootScope.concertPlaces.filter(function (item) { return item.Id === id; })[0];
            return place && place.Halls && place.Halls.length;
        }
        $scope.getHall = function (id) {
            if (!id) return [];
            var place = $rootScope.concertPlaces.filter(function (item) { return item.Id === id; })[0];
            return place && place.Halls ? place.Halls : [];
        }
        $scope.editPlace = function () {
            $rootScope.countryPlace = $scope.place;
            $rootScope.$watch('countryPlace', function (place) {
                $scope.place = place;
            });
            app.closeFour();
            app.loadContentView('/main/dictionary/dictionary.concert.hall.html', 3200);
        }

        $scope.editCity = function () {
            app.closeFour();
            app.loadContentView('/main/dictionary/dictionary.concert.city.html', 3200);
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
            $scope.concert.ConcertPlaceId = vm.concertPlaceId;
            $scope.concert.HallId = vm.hallId;
            concertService.saveConcert($scope.concert, function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.loadConcerts();
                if ($rootScope.getConcert)
                    $rootScope.getConcert($scope.concert.Id);
                app.closeFour();
                $timeout(function () {
                    return app.closeView('concertEdit');
                }, 3000);
            });
        }

    }

    angular
        .module('app')
        .controller('concertEditController', concertEditController);

    concertEditController.$inject = ['$rootScope', '$scope', 'concertService', 'personService', '$filter', '$timeout'];
})();