(function () {
    'use strict';

    function concertProgrammController($rootScope, $scope, concertService) {
        var vm = this;
        $scope.concert = $rootScope.editedConcert;
        if ($scope.concert.IsOneProgramm === undefined)
            $scope.concert.IsOneProgramm = true;
        $scope.programms = [];
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
        $rootScope.getGroups = function () {
            concertService.getGroups(function (data) {
                $rootScope.actorgroups = data;
            });
        }
        $rootScope.getGroups();

        $rootScope.editProgramm = function (item) {
            $rootScope.editedProgrammPart = item ? item: {
                DateStart: new Date(),
                TimeStart: "00:00",
                TimeEnd: "00:00",
                IdEvent: $scope.concert.Id
            };
            app.closeFour();
            app.loadContentView('/main/concert/r3/r4/concert.programm.part.html', 3200);
        }
        $rootScope.editGroup = function (item) {
            var id = $scope.concert.IsOneProgramm ? $scope.programms[0].Id : 0;
            $rootScope.editedActor = item ? item : { IdProgramm: id };
            
            app.closeFour();
            app.loadContentView('/main/concert/r3/r4/concert.programm.actor.html', 3200);
        }
        $scope.editActorGroup = function (item) {
            $rootScope.editedGroup = {Id: item.Id, Name: item.Name};
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.concert.actorgroup.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('concertProgrammController', concertProgrammController);

    concertProgrammController.$inject = ['$rootScope', '$scope', 'concertService'];
})();