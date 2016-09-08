(function () {
    'use strict';

    function DictionaryConcertCityController($rootScope, $scope, personService, $timeout) {
        var vm = this;

        $scope.abrs = ['г', 'с', 'д', 'пос', 'пгт', 'ст-ца'];
        $scope.abr = $scope.abrs[0];
        var countryId = 0;

        function addPlace(response) {
            $scope.places.push.apply($scope.places, response.data);
            return response.data.map(function (item) {
                return item;
            });
        }

        $scope.getPlaces = function (value) {
            $scope.places = [];
            return countryId > 0 ? personService.getCountryPlaces(countryId, value).then(addPlace) :
                personService.getPlaces(value).then(addPlace);
        }

        function getCountries(value) {
            $scope.countries = [];
            personService.getCountries(value, function (data) {
                $scope.countries.push.apply($scope.countries, data);
            });
        }
        getCountries('');

        $scope.getCountry = function(value) {
            return $scope.countries.filter(function (item) {
                return !value || item.Name.indexOf(value) >= 0;
            }).map(function (el) {
                return el;
            });
            //return res.map(function (item) {
            //    return item;
            //});
        }

        $scope.$watch('countryName', function(data) {
            if (!data || typeof data === "string") return;
            countryId = data.Id;
            $scope.countryName = data.Name;
        });

        $scope.savePlace = function () {
            if (countryId > 0)
                $scope.placeName.IdCountry = countryId;
            personService.saveCountryPlace($scope.placeName, function (data) {
                //TODO show msg
                app.closeFive();
                $timeout(function () {
                    return app.closeView('DictionaryConcertCityController');
                }, 3000);
            });
        }
    }

    angular
        .module('app')
        .controller('DictionaryConcertCityController', DictionaryConcertCityController);

    DictionaryConcertCityController.$inject = ['$rootScope', '$scope', 'personService', '$timeout'];
})();