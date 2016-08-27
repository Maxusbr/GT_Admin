(function () {
    'use strict';

    function concertEditController($rootScope, $scope, concertService, $filter) {
        var vm = this;

        
        vm.organizers = [];

        $scope.concert = $rootScope.editedConcert;

        if ($scope.concert.DateStartSold)
            $scope.dateStartSold = new Date($scope.concert.DateStartSold);
        if ($scope.concert.DateStopSold)
            $scope.dateStopSold = new Date($scope.concert.DateStopSold);
        $scope.$watch('dateStartSold', function (date) {
            if (date) $scope.concert.DateStartSold = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
        });
        $scope.$watch('dateStopSold', function (date) {
            if (date) $scope.concert.DateStopSold = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
        });
        $rootScope.$watch('concertCategories', function (items) {
            if (!items) return;
            $scope.baseCategory = items.filter(function (item) {
                return item.IdParent == null;
            });
        });

        $scope.editCat = function () {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.concert.category.html', 3200);
        }

        $scope.editOrg = function () {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.concert.org.html', 3200);
        }

        $scope.saveEvent = function () {
            if ($scope.concert.AgeLimit)
                $scope.concert.AgeLimit = parseInt($scope.concert.AgeLimit, 10);
            concertService.Save($scope.concert, function (data) {
                $rootScope.loadEvent();
                if ($rootScope.getEvent)
                    $rootScope.getEvent($scope.concert.Id);
                app.closeView('concertEdit');
            });
        }

        // Datepicker
        $scope.dateOptions = {
            formatYear: 'yyyy',
            startingDay: 1,
            showWeeks: false
        };
        $scope.open1 = function () {
            $scope.popup1.opened = true;
        };

        $scope.open2 = function () {
            $scope.popup2.opened = true;
        };
        $scope.popup1 = {
            opened: false
        };

        $scope.popup2 = {
            opened: false
        };
    }

    angular
        .module('app')
        .controller('concertEditController', concertEditController);

    concertEditController.$inject = ['$rootScope', '$scope', 'concertService', '$filter'];
})();