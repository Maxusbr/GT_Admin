(function () {
    'use strict';

    function concertProgrammController($rootScope, $scope, concertService) {
        var vm = this;

    }

    angular
        .module('app')
        .controller('concertProgrammController', concertProgrammController);

    concertProgrammController.$inject = ['$rootScope', '$scope', 'concertService'];
})();