(function () {
    'use strict';

    function personNotesSourceController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.savePersonNotesSource = function save_person_notes_source() {
            //TODO: save changes or create new source
            //TODO: update notes list
            //TODO: close this window
        }

        $rootScope.displayPersonWTF = function display_person_WTF() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.wtf.html', 3200);
        }
            
    }

    angular
        .module('app')
        .controller('personNotesSourceController', personNotesSourceController);

    personNotesSourceController.$inject = ['$rootScope', '$cookieStore'];
})();