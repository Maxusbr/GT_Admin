(function () {

    'use strict';

    function mainPersonaEditController($scope, $stateParams, $rootScope, $location, personService) {

        function getYearText(age) {
            var year = age;
            while (year > 10) {
                year = year % 10;
            }
            if (year === 1) {
                return "год";
            }
            else {
                if (year > 1 && year < 5) {
                    return "года";
                }
                else {
                    return "лет";
                }
            }
        }


        $scope.SwitchElements = function () {
            $('.persona-main__container').hide();

            $('.persona-info__full-block').hide();
            $('.persona-info__small-block').show();
        }
    }

    var app = angular
        .module('app')
        .controller('mainPersonaEditController', mainPersonaEditController);

    mainPersonaEditController.$inject = ['$scope', '$stateParams', '$rootScope', '$location', 'personService'];
})();