(function () {
    'use strict';

    angular
        .module('app')
        .controller('PersonListController', PersonListController);

    PersonListController.$inject = ['$rootScope', 'personService'];
    function PersonListController($rootScope, personService) {
        var vm = this;
        personService.getPersons();
        $rootScope.createPreson = function create_person() {
            console.log('create person');
            app.closeSecond();
            app.loadContentView('/main/person/person.create.html', 1800);
        }
    }
})();