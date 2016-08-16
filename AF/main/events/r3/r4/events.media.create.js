(function () {
    'use strict';

    function EventsMediaCreateController($rootScope, $scope) {
        var vm = this;
        $scope.foto_ = false;
        $scope.video_ = true;
        
        $scope.association = {};
        $scope.association.type = 'event';


        $scope.showSelect = function show_select(type, check_type) {
            if (type == check_type) return true;
            else return false;
        }
        
        
    }

    angular
        .module('app')
        .controller('EventsMediaCreateController', EventsMediaCreateController);

    EventsMediaCreateController.$inject = ['$rootScope', '$scope'];
})();