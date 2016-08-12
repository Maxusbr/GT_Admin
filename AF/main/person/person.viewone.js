(function () {
    'use strict';

    function personViewoneController($rootScope) {
        var vm = this;

        $rootScope.editPerson = function edit_person(){
            app.closeThird();
            app.loadContentView('peron.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('personViewoneController', personViewoneController);

    personViewoneController.$inject = ['$rootScope'];
})();