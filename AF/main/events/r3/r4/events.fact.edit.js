﻿(function () {
    'use strict';

    function EventsFactEditController($rootScope, $scope, eventService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = 'Error';

        $rootScope.saveFact = function save_fact() {
            console.log('save fact click, event - ' + $rootScope.eventId);
            $scope.showMessage = true;
            $rootScope.editedFact.id_Event = $rootScope.eventId;
            eventService.saveEntity($rootScope.eventId, $rootScope.editedFact, 'fact', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                $rootScope.getFacts();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('personFactCreate');
                    }, timeoutMsgShow);

            });
        }

        $scope.setConnection = function (id) {
            if (!id) return;
            var type = $rootScope.facttypes.filter(function (item) {
                return item.Id === id;
            })[0];
            $rootScope.editedFact.FactType = type;
        }
        // $scope.autoExpand = function(e) {
        //     var element = typeof e === 'object' ? e.target : document.getElementById(e);
        //     var scrollHeight = element.scrollHeight - 60; 
        //     element.style.height =  scrollHeight + "px";    
        // }
        // $scope.autoExpand('TextArea');

    }

    angular
        .module('app')
        .controller('EventsFactEditController', EventsFactEditController);

    EventsFactEditController.$inject = ['$rootScope', '$scope', 'eventService', '$timeout'];
})();