﻿(function () {
    'use strict';

    function personNotesController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.displaySource = function display_source(){
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.source.html', 3200);
        }

        $rootScope.displayNotesStatic = function display_source(){
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.static.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('personNotesController', personNotesController);

    personNotesController.$inject = ['$rootScope', '$cookieStore'];
})();