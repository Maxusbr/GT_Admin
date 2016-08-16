(function () {
    'use strict';

    function EventsNotesController($rootScope, $cookieStore) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.displaySource = function display_source(){
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.notes.source.html', 3200);
        }

        $rootScope.displayNotesStatic = function display_source(){
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.notes.static.html', 3200);
        }

        $rootScope.addNotes = function add_fact() {
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.notes.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('EventsNotesController', EventsNotesController);

    EventsNotesController.$inject = ['$rootScope', '$cookieStore'];
})();