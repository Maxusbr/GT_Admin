(function () {
    'use strict';

    angular
        .module('app')
        .controller('PersonListController', PersonListController);

    PersonListController.$inject = ['$rootScope'];
    function PersonListController($rootScope) {
        var vm = this;

        $rootScope.createPreson = function create_person() {
            console.log('create person');
            app.closeSecond();
            app.loadContentView('/main/person/person.create.html', 1800);
        }
    }
})();