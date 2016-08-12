(function () {
    'use strict';

    function PeronViewoneController($rootScope) {
        var vm = this;

        $rootScope.editPerson = function edit_person(){
            app.closeThird();
            app.loadContentView('peron.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('PeronViewoneController', PeronViewoneController);

    PeronViewoneController.$inject = ['$rootScope'];
})();