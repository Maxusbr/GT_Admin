(function () {
    'use strict';

    function DictionaryConcertCityController($rootScope, $scope, personService) {
        var vm = this;

        $scope.abrs = ['г', 'с', 'д', 'пос', 'пгт', 'ст-ца'];
        $scope.abr = $scope.abrs[0];

        $scope.getPlaces = function (value) {
            $scope.places = [];
            return personService.getPlaces(value).then(function (response) {
                $scope.places.push.apply($scope.places, response.data);
                return response.data.map(function (item) {
                    return item;
                });
            });
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

        $scope.savePlace = function () {

        }
    }

    angular
        .module('app')
        .controller('DictionaryConcertCityController', DictionaryConcertCityController);

    DictionaryConcertCityController.$inject = ['$rootScope', '$scope', 'personService'];
})();