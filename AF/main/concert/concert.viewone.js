(function () {
    'use strict';


    function concertViewoneController($rootScope, $scope, concertService) {
        var vm = this;

        $scope.displaySeries = function (concert) {
            $rootScope.editedConcert = concert;
            app.closeThird();
            app.loadContentView('/main/concert/concert.edit.html', 1800);
        }
        $scope.displayHall = function (concert) {
            $rootScope.editedConcert = concert;
            app.closeThird();
            app.loadContentView('/main/concert/concert.edit.html', 1800);
        }
        $scope.displayCalendar = function (concert) {
            $rootScope.editedConcert = concert;
            app.closeThird();
            app.loadContentView('/main/concert/r3/concert.calendar.html', 2500);
        }
        $scope.displayProgramms = function (concert) {
            $rootScope.editedConcert = concert;
            app.closeThird();
            app.loadContentView('/main/concert/r3/concert.programm.html', 2500);
        }
        $scope.displayTickets = function (concert) {
            $rootScope.editedConcert = concert;
            app.closeThird();
            app.loadContentView('/main/concert/r3/concert.tickets.html', 2500);
        }

        $scope.Id = $rootScope.concertId;
        $scope.counts = { CountDescriptions: 0, CountFacts: 0, CountConnects: 0, CountMedias: 0, CountLinks: 0, CountAntros: 0 }

        $rootScope.getConcert = function (id) {
            $scope.Promise = concertService.getConcert(id, function (data) {
                $scope.concert = data;
                //TODO get programm & calendar
                concertService.getExist(id, function (data) {
                    $scope.concert.ExistProgramm = data.ExistProgramm;
                    $scope.concert.ExistCalendar = data.ExistCalendar;
                });
            });
        }
        $rootScope.getConcert($scope.Id);

        $scope.editConcert = function (concert) {
            $rootScope.editedConcert = concert;
            app.closeThird();
            app.loadContentView('/main/concert/concert.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('concertViewoneController', concertViewoneController);

    concertViewoneController.$inject = ['$rootScope', '$scope', 'concertService'];

})();