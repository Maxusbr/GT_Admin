(function () {
    'use strict';

    function personNotesAdesController($rootScope, $cookieStore) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
        
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $rootScope.addPersonNotesAdapt = function add_person_notes_adapt(){
            app.closeFive();
            app.loadContentView('/main/person/r3/r4/r5/person.notes.ades.edit.html', 3800);
        }
    }

    angular
        .module('app')
        .controller('personNotesAdesController', personNotesAdesController);

    personNotesAdesController.$inject = ['$rootScope', '$cookieStore'];
})();