(function () {
    'use strict';

    angular
        .module('app')
        .controller('PersonListController', PersonListController);

    PersonListController.$inject = ['$rootScope', '$scope', 'personService', '$interval'];
    function PersonListController($rootScope, $scope, personService, $interval) {
        var vm = this;
        $scope.Promise = personService.getPersons();
        $rootScope.createPreson = function create_person() {
            console.log('create person');
            app.closeSecond();
            app.loadContentView('/main/person/person.create.html', 1800);
        }

        $scope.selectPerson = function (id) {
            $rootScope.personId = id;
            app.closeSecond();
            app.loadContentView('/main/person/person.viewone.html', 1800);
        }
    }
})();