(function () {
    'use strict';

    function PersonEditController($rootScope, $scope, personService) {
        var vm = this;
        $scope.Id = $rootScope.personId;
        $scope.Promise = personService.getPerson($scope.Id, function (data) {
            $scope.person = data;
            $scope.person.bithday = new Date($scope.person.Bithday);
        });
    }

    angular
        .module('app')
        .controller('PersonEditController', PersonEditController);

    PersonEditController.$inject = ['$rootScope', '$scope', 'personService'];
})();