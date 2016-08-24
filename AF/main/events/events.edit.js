﻿(function () {
    'use strict';

    function EventsEditController($rootScope, $scope, eventService, $filter) {
        var vm = this;
        $scope.event = $rootScope.editEvent;
        if ($scope.event.DateStartSold)
            $scope.dateStartSold = new Date($scope.event.DateStartSold);
        if ($scope.event.DateStopSold)
            $scope.dateStopSold = new Date($scope.event.DateStopSold);
        $scope.$watch('dateStartSold', function (date) {
            if (date) $scope.event.DateStartSold = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
        });
        $scope.$watch('dateStopSold', function(date) {
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
            return $rootScope.eventCategories.filter(function(item) {
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

        $scope.saveEvent = function () {
            eventService.Save($scope.event, function (data) {
                $rootScope.loadEvent();
                app.closeView('eventEdit');
            });
            
        }
    }

    angular
        .module('app')
        .controller('EventsEditController', EventsEditController);

    EventsEditController.$inject = ['$rootScope', '$scope', 'eventService', '$filter'];
})();