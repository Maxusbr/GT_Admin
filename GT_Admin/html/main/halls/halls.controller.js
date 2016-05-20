(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainHallsController', MainHallsController);

    MainHallsController.$inject = ['HallsService', '$rootScope'];
    function MainHallsController(HallsService, $rootScope) {
        var vm = this;

    }

})();