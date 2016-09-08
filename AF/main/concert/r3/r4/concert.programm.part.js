(function () {
    'use strict';

    function concertProgrammPartController($rootScope, $scope, concertService, $timeout) {
        var vm = this;

        $scope.part = $rootScope.editedProgrammPart;
        $scope.$watch('dateStart', function (date) {
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
        $scope.dateEnd = $scope.part.DateEnd ? new Date($scope.part.DateEnd) : new Date($scope.part.DateStart);
        if ($scope.part.DateStart)
            $scope.dateStart = new Date($scope.part.DateStart);

        if ($scope.part.TimeStart) {
            $scope.timeStart = new Date($scope.part.DateStart);
            var times = $scope.part.TimeStart.split(':');
            $scope.timeStart.setHours(times[0], times[1]);
        }
        if ($scope.part.TimeEnd) {
            $scope.timeEnd = new Date($scope.part.DateEnd ? $scope.part.DateEnd : $scope.part.DateStart);
            var timee = $scope.part.TimeEnd.split(':');
            $scope.timeEnd.setHours(timee[0], timee[1]);
        }

        $scope.savePart = function () {
            $scope.part.DateStart = `${$scope.dateStart.getFullYear()}-${$scope.dateStart.getMonth() + 1}-${$scope.dateStart.getDate()}`;
            $scope.part.DateEnd = $scope.part.AllDay ? `${$scope.dateEnd.getFullYear()}-${$scope.dateEnd.getMonth() + 1}-${$scope.dateEnd.getDate()}` : null;
            $scope.part.TimeStart = `${$scope.timeStart.getHours()}:${$scope.timeStart.getMinutes()}`;
            $scope.part.TimeEnd = `${$scope.timeEnd.getHours()}:${$scope.timeEnd.getMinutes()}`;
            concertService.saveProgramm($scope.part, function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $scope.part.Id = data.programmid;
                if ($rootScope.saveActorPart) {
                    $rootScope.saveActorPart($scope.part);
                } else {
                    $rootScope.getProgramms($rootScope.concertId);
                    if ($rootScope.getConcert)
                        $rootScope.getConcert($rootScope.concertId);
                }
                $timeout(function () {
                    return app.closeView('disConcertProgrammPart');
                }, 3000);
                
            });
        }

    }

    angular
        .module('app')
        .controller('concertProgrammPartController', concertProgrammPartController);

    concertProgrammPartController.$inject = ['$rootScope', '$scope', 'concertService', '$timeout'];
})();