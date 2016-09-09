(function () {
    'use strict';

    function concertProgrammController($rootScope, $scope, concertService, $q, $timeout) {
        var vm = this;
        var actors = [];
        $scope.concert = $rootScope.editedConcert;
        if ($scope.concert.IsOneProgramm === undefined)
            $scope.concert.IsOneProgramm = true;

        $rootScope.getProgramms = function (id) {
            if ($scope.concert.IsOneProgramm) {
                concertService.getProgramms(id, function (data) {
                    $scope.programms = [];
                    if (data.length) {
                        
                        var deferred = $q.defer();
                        var promise = deferred.promise;
                        promise.then(function () {
                            data.forEach(function (item) {
                                $scope.programms.push(item.Programm);
                            });
                        }).then(function () {
                            $scope.actorgroups = data[0].Group;
                            $scope.actors = data[0].Actors;
                            $scope.actors.forEach(function (item) {
                                item.Programms = $scope.programms;
                            });
                        });
                        deferred.resolve();
                    }
                });
            } else {
                concertService.getActors(id, function (data) {
                    $scope.actors = [];
                    if (data.length) {
                        data.forEach(function (item) {
                            $scope.actors.push(item);
                        });
                    }
                });
            }
        }
        $rootScope.getProgramms($scope.concert.Id);
        $rootScope.getGroups = function () {
            concertService.getGroups(function (data) {
                $rootScope.actorgroups = data;
            });
        }
        $rootScope.getGroups();
        $rootScope.AddActor = function (item) {
            item.Programms = $scope.programms;
            concertService.saveActor(item, function (data) {
                $rootScope.getProgramms($scope.concert.Id);
                app.closeFive();
                app.closeView('disConcertProgrammActor');
            });
        }

        $scope.editProgramm = function (item) {
            $rootScope.editedProgrammPart = item ? item : {
                DateStart: new Date(),
                TimeStart: "00:00",
                TimeEnd: "00:00",
                IdEvent: $scope.concert.Id
            };
            app.closeFive();
            app.loadContentView('/main/concert/r3/r4/concert.programm.part.html', 3200);
        }
        $scope.editActor = function (item) {
            $rootScope.editedActor = item ? item : {};
            app.closeFour();
            app.loadContentView('/main/concert/r3/r4/concert.programm.actor.html', 3200);
        }
        $scope.editActorGroup = function (item) {
            $rootScope.editedGroup = { Id: item.Id, Name: item.Name };
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.concert.actorgroup.html', 3200);
        }
        $rootScope.editActorProgramm = function (item) {
            $rootScope.editedActor = item ? item : {Programms: []};
            app.closeFour();
            app.loadContentView('/main/concert/r3/r4/concert.programm.actor.part.html', 3200);
        }

        function update(model) {
            concertService.updateConcert(model, function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.getConcert($rootScope.concertId);
                app.closeFour();
                
                $scope.Promise = $timeout(function () {
                    return app.closeView('concertProgrammEdit');
                }, timeoutMsgShow);
            });
        }
        $scope.saveProgramm = function () {
            var model = $scope.concert.IsOneProgramm ? {
                Concert: $scope.concert,
                Programms: $scope.programms,
                Actors: $scope.actors
            } : {
                Concert: $scope.concert
            }
            update(model);
        }
    }

    angular
        .module('app')
        .controller('concertProgrammController', concertProgrammController);

    concertProgrammController.$inject = ['$rootScope', '$scope', 'concertService', '$q', '$timeout'];
})();