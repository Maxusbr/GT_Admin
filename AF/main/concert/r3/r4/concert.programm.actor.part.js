(function () {
    'use strict';

    function concertProgrammActorPartController($rootScope, $scope, concertService, personService) {
        var vm = this;
        $scope.actor = $rootScope.editedActor;

        $scope.editProgramm = function (item) {
            $rootScope.editedProgrammPart = item ? item : {
                DateStart: new Date(),
                TimeStart: "00:00",
                TimeEnd: "00:00",
                IdEvent: $rootScope.editedConcert.Id
            };
            app.closeFive();
            app.loadContentView('/main/concert/r3/r4/concert.programm.part.html', 3200);
        }

        
        if (!$rootScope.persons)
            $scope.Promise = personService.getPersons();

        $scope.saveActor = function () {
            concertService.saveActor($scope.actor, function (data) {
                $rootScope.getProgramms($rootScope.concertId);
                if ($rootScope.getConcert)
                    $rootScope.getConcert($rootScope.concertId);
                app.closeFive();
                app.closeView('disConcertActorPart');
            });
        }

        $rootScope.saveActorPart = function (part) {
            var pr = $scope.actor.Programms.filter(function (item) { return item.Id === part.Id })[0];
            if (pr) {
                $scope.actor.Programms.forEach(function (item) {
                    if (item.Id === part.Id)
                        $scope.actor[$scope.actor.indexOf(item)] = part;
                });
            } else {
                $scope.actor.Programms.push(part);
            }
        }
    }

    angular
        .module('app')
        .controller('concertProgrammActorPartController', concertProgrammActorPartController);

    concertProgrammActorPartController.$inject = ['$rootScope', '$scope', 'concertService', 'personService'];
})();