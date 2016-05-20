(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainEventsIsController', MainEventsIsController);

    MainEventsIsController.$inject = ['EventsIsService', '$rootScope'];
    function MainEventsIsController(EventsIsService, $rootScope) {
        var vm = this;

    }

})();