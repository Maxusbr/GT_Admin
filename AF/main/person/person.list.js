(function () {
    'use strict';

    angular
        .module('app')
        .controller('PersonListController', PersonListController);

    PersonListController.$inject = ['$rootScope', '$scope', 'personService'];
    function PersonListController($rootScope, $scope, personService) {
        var vm = this;
        personService.getPersons();
        $rootScope.createPreson = function create_person() {
            console.log('create person');
            app.closeSecond();
            app.loadContentView('/main/person/person.create.html', 1800);
        }

        $scope.selectPerson = function (id) {
            $rootScope.Id = id;
            app.closeSecond();
            app.loadContentView('/main/person/person.viewone.html', 1800);
        }
    }
})();