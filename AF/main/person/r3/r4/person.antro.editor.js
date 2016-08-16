(function () {
    'use strict';

    function personAntroEditorController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

            $rootScope.saveAntro = function save_antro(){
                
            }

            $rootScope.displayAntroTypes = function display_antro_types(){
                
            }
    }

    angular
        .module('app')
        .controller('personAntroEditorController', personAntroEditorController);

    personAntroEditorController.$inject = ['$rootScope', '$cookieStore'];
})();