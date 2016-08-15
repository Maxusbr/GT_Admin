(function () {
    'use strict';

    function personNotesStaticController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.savePersonNotesStatic = function save_person_notes_static(){
            
        }
    }

    angular
        .module('app')
        .controller('personNotesStaticController', personNotesStaticController);

    personNotesStaticController.$inject = ['$rootScope', '$cookieStore'];
})();