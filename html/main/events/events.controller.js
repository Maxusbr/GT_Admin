(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainEventsController', MainEventsController);

    MainEventsController.$inject = ['EventsService', '$rootScope'];
    function MainEventsController(EventsService, $rootScope) {
        var vm = this;

    }

})();