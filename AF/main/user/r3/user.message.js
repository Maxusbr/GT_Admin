(function () {
    'use strict';

    function UserMessageController($rootScope, $scope, personService) {
        var vm = this;

        // 
    }

    angular
        .module('app')
        .controller('UserMessageController', UserMessageController);

    UserMessageController.$inject = ['$rootScope', '$scope', 'personService'];
})();