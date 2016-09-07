

(function () {
    'use strict';

    angular
        .module('app')
        .controller('EventListController', EventListController);

    EventListController.$inject = ['$rootScope', '$scope', 'eventService', '$interval'];
    function EventListController($rootScope, $scope, eventService, $interval) {
        var vm = this;
        $rootScope.loadEvent = function() {
            $scope.Promise = eventService.getEvents();
        }
        $rootScope.loadEvent();

        $scope.createEvent = function () {
            console.log('create event');
            $rootScope.editEvent = {}
            app.closeSecond();
            app.loadContentView('/main/events/events.edit.html', 1800);
        }

        $scope.selectEvents = function (id) {
            console.log(id);
            $rootScope.eventId = id;
            app.closeSecond();
            app.loadContentView('/main/events/events.viewone.html', 1800);
        }

        $scope.order = '';
        $scope.rever = false;
        $scope.arrows = [false,false,false,false,false];
        $scope.arrowId = ['Name','EventParentCategory','EventCategory','Organizer','AgeLimit'];
        $scope.orders = function(name) {
            if (name == $scope.order) {
                if (!$scope.rever) {
                    $scope.order = name;    
                }
                else { $scope.order = '-' + name; }
                $scope.rever = !$scope.rever;
            }
            else {
                $scope.order = name;
                $scope.rever = true;
            }

            function arrowTrue(element, index, array) {
                if ((element == name)&&(!$scope.rever)) $scope.arrows[index] = true;
                else $scope.arrows[index] = false;
            }

            $scope.arrowId.forEach(arrowTrue);
           
        }
    }
})();