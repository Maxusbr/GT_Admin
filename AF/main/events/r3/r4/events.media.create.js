(function () {
    'use strict';

    function EventsMediaCreateController($rootScope, $scope) {
        var vm = this;
        $scope.foto_ = false;
        $scope.video_ = true;
        // $scope.personTags;
        $scope.association = {};
        $scope.association.type = 'event';
        // console.log($scope.association);

        $scope.showSelect = function show_select(type, check_type) {
        	console.log(type);
        	console.log(check_type);
            if (type == check_type) return true;
            else return false;
        }
        $scope.changeFile = function changeFile() {
        	console.log(vm.file);
        }
        
    }

    angular
        .module('app')
        .controller('EventsMediaCreateController', EventsMediaCreateController);

    EventsMediaCreateController.$inject = ['$rootScope', '$scope'];
})();