(function () {
    'use strict';

    function concertProgrammController($rootScope, $scope, concertService) {
        var vm = this;
        $scope.concert = $rootScope.editedConcert;
        if ($scope.concert.IsOneProgramm === undefined)
            $scope.concert.IsOneProgramm = true;

        $rootScope.getProgramms = function(id) {
            concertService.getProgramms(id, function (data) {
                if ($scope.concert.IsOneProgramm) {
                    $scope.programms = data;
                    if(data.length) {
                        $scope.actorgroups = data[0].Group;
                        $scope.actors = data[0].Actors;
                    }
                }
            });
        }
        $rootScope.getProgramms($scope.concert.Id);
    }

    angular
        .module('app')
        .controller('concertProgrammController', concertProgrammController);

    concertProgrammController.$inject = ['$rootScope', '$scope', 'concertService'];
})();