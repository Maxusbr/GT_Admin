(function () {
    'use strict';

    function concertTicketsController($rootScope, $scope, concertService) {
        var vm = this;
        $scope.concert = $rootScope.editedConcert;

        $scope.ticket = $scope.concert.Tickets ? $scope.concert.Tickets : {
            Id: $scope.concert.Id,
            ShowFormWhileEmpty: true,
            ShowFormWhileEndTime: true,
            DateStart: new Date(),
            TimeStart: "00:00",
            TimeEnd: "00:00"
        }
        $scope.$watch('dateStart', function(date) {
            if (!date) return;
            if (date > $scope.dateEnd)
                $scope.dateEnd = date;
            if (!$scope.timeStart) return;
            var dt = $scope.timeStart;
            $scope.timeStart = date;
            $scope.timeStart.setHours(dt.getHours(), dt.getMinutes());
        });
        $scope.$watch('dateEnd', function (date) {
            if (!date) return;
            if (date < $scope.dateEnd)
                $scope.dateStart = date;
            if (!$scope.timeEnd) return;
            var dt = $scope.timeEnd;
            $scope.timeEnd = date;
            $scope.timeEnd.setHours(dt.getHours(), dt.getMinutes());
        });
        $scope.$watch('timeStart', function (date) {
            if (!date) return;
            if (date > $scope.timeEnd)
                $scope.timeEnd = date;
        });
        $scope.$watch('timeEnd', function (date) {
            if (!date) return;
            if (date < $scope.timeStart)
                $scope.timeStart = date;
        });
        $scope.dateEnd = $scope.ticket.DateEnd ? new Date($scope.ticket.DateEnd) : new Date($scope.ticket.DateStart);
        if ($scope.ticket.DateStart)
            $scope.dateStart = new Date($scope.ticket.DateStart);
        
        if ($scope.ticket.TimeStart) {
            $scope.timeStart = new Date($scope.ticket.DateStart);
            var times = $scope.ticket.TimeStart.split(':');
            $scope.timeStart.setHours(times[0], times[1]);
        }
        if ($scope.ticket.TimeEnd) {
            $scope.timeEnd = new Date($scope.ticket.DateEnd ? $scope.ticket.DateEnd : $scope.ticket.DateStart);
            var timee = $scope.ticket.TimeEnd.split(':');
            $scope.timeEnd.setHours(timee[0], timee[1]);
        }

        $scope.saveTickets = function() {
            $scope.ticket.DateStart = `${$scope.dateStart.getFullYear()}-${$scope.dateStart.getMonth() + 1}-${$scope.dateStart.getDate()}`;
            $scope.ticket.DateEnd = `${$scope.dateEnd.getFullYear()}-${$scope.dateEnd.getMonth() + 1}-${$scope.dateEnd.getDate()}`;
            $scope.ticket.TimeStart = `${$scope.timeStart.getHours()}:${$scope.timeStart.getMinutes()}`;
            $scope.ticket.TimeEnd = `${$scope.timeEnd.getHours()}:${$scope.timeEnd.getMinutes()}`;
            concertService.saveTickets($scope.ticket, function(data) {
                $rootScope.loadConcerts();
                if ($rootScope.getConcert)
                    $rootScope.getConcert($scope.concert.Id);
                app.closeView('concertTicketsEdit');
            });
        }
    }

    angular
        .module('app')
        .controller('concertTicketsController', concertTicketsController);

    concertTicketsController.$inject = ['$rootScope', '$scope', 'concertService'];
})();