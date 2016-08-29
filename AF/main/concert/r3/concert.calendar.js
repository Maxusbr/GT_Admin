(function () {
    'use strict';

    function concertCalendarController($rootScope, $scope, concertService) {
        var vm = this;

    }

    angular
        .module('app')
        .controller('concertCalendarController', concertCalendarController);

    concertCalendarController.$inject = ['$rootScope', '$scope', 'concertService'];
})();