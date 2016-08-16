﻿(function () {
    'use strict';

    function EventsEditController($rootScope, $scope, personService) {
        var vm = this;
        $scope.Id = $rootScope.Id;
        $scope.Promise = personService.getPerson($scope.Id, function (data) {
            $scope.person = data;
            $scope.person.bithday = new Date($scope.person.Bithday);
        });
    }

    angular
        .module('app')
        .controller('EventsEditController', EventsEditController);

    EventsEditController.$inject = ['$rootScope', '$scope', 'personService'];
})();