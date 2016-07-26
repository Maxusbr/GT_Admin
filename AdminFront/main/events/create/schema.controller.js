(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainEventCreateSchemaController', MainEventCreateSchemaController);

    MainEventCreateSchemaController.$inject = ['$scope', '$stateParams'];

    function MainEventCreateSchemaController($scope, $stateParams) {
        var vm = this;
    }
})();