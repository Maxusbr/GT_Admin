(function () {
    'use strict';

    function personAntroEditorController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

            $rootScope.saveAntro = function save_antro(){
                
            }

            $rootScope.displayAntroTypes = function display_antro_types(){
                app.closeFive();
                app.loadContentView('/main/dictionary/dictionary.antro.types.html', 3200);
            }
    }

    angular
        .module('app')
        .controller('personAntroEditorController', personAntroEditorController);

    personAntroEditorController.$inject = ['$rootScope', '$cookieStore'];
})();