(function () {
    'use strict';

    function EventsEditController($rootScope, $scope, eventService, $filter, $timeout) {
        var vm = this;


        vm.organizers = [];

        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        $scope.event = $rootScope.editEvent;
        $scope.selectedOrganizer = $scope.event.Organizer;
        $scope.$watch('selectedOrganizer', function (item) {
            if (item)
                $scope.event.Organizer = item.Name;
        });

        if ($scope.event.DateStartSold)
            $scope.dateStartSold = new Date($scope.event.DateStartSold);
        if ($scope.event.DateStopSold)
            $scope.dateStopSold = new Date($scope.event.DateStopSold);
        $scope.$watch('dateStartSold', function (date) {
            if (date) $scope.event.DateStartSold = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
        });
        $scope.$watch('dateStopSold', function (date) {
            if (date) $scope.event.DateStopSold = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
        });
        $rootScope.$watch('eventCategories', function (items) {
            if (!items) return;
            $scope.baseCategory = items.filter(function (item) {
                return item.IdParent == null;
            });
        });
        if (!$rootScope.eventCategories)
            eventService.getCategories(function (data) {
                $rootScope.eventCategories = data;
            });

        $scope.getChildCategory = function (id) {
            if (!$rootScope.eventCategories) return [];
            return $rootScope.eventCategories.filter(function (item) {
                return item.IdParent === id;
            });
        }

        $scope.editCat = function () {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.event.category.html', 3200);
        }

        $scope.editOrg = function () {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.event.org.html', 3200);
        }

        //Organizer
        $rootScope.getOrganizers = function () {
            eventService.getOrganizers(function (data) {
                vm.organizers = [];
                vm.organizers.push.apply(vm.organizers, data);
            });
        }
        $rootScope.getOrganizers();

        vm.querySearch = function (query) {
            if (!vm.organizers || !query) return [];
            var result = vm.organizers.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }

        $scope.saveEvent = function () {
            if ($scope.event.EventParentCategoryId == undefined) {
                $scope.showMessage = true;
                $scope.errorYes = true;
                $scope.message = 'Категория обязательное поле';
                return;
            }
            if ($scope.event.AgeLimit)
                $scope.event.AgeLimit = parseInt($scope.event.AgeLimit, 10);
            if ($scope.selectedOrganizer)
                $scope.event.IdCompany = $scope.selectedOrganizer.Id;
            eventService.Save($scope.event, function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.loadEvent();
                if ($rootScope.getEvent)
                    $rootScope.getEvent($scope.event.Id);
                $scope.Promise = $timeout(function () {
                    return app.closeView('eventEdit');
                }, timeoutMsgShow);
            });

        }

        $scope.validFuncNumber = function (fild) {

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

        $scope.ageLimits = [0, 6, 12, 16, 18];


    }

    angular
        .module('app')
        .controller('EventsEditController', EventsEditController);

    EventsEditController.$inject = ['$rootScope', '$scope', 'eventService', '$filter', '$timeout'];
})();