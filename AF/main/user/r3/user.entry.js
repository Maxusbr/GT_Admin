(function () {
    'use strict';

    function UserEntryController($rootScope, $scope, personService) {
        var vm = this;

        
    }

    angular
        .module('app')
        .controller('UserEntryController', UserEntryController);

    UserEntryController.$inject = ['$rootScope', '$scope', 'personService'];
})();