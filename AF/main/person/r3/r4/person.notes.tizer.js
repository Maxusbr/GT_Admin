(function () {
    'use strict';

    function personNotesTizerController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.savePersonNotesTizer = function save_person_notes_tizer(){
            //TODO: save changes
            //TODO: update notes table
            //TODO: close window
        }
    }

    angular
        .module('app')
        .controller('personNotesTizerController', personNotesTizerController);

    personNotesTizerController.$inject = ['$rootScope', '$cookieStore'];
})();