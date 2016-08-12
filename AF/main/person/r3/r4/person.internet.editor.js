(function () {
    'use strict';

    function PersonInternetEditorController($rootScope) {
        var vm = this;

        $rootScope.saveInternet = function save_fact() {
            console.log('save fact click');
            //TODO: save changes or create new
            //TODO: close this view
            //TODO: refresh facts table
        }
    }

    angular
        .module('app')
        .controller('PersonInternetEditorController', PersonInternetEditorController);

    PersonInternetEditorController.$inject = ['$rootScope'];
})();