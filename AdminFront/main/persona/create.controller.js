(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaCreateController', MainPersonaCreateController)
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider

    }

    MainPersonaCreateController.$inject = ['$scope', '$stateParams', '$rootScope', '$filter'];

    function MainPersonaCreateController($scope, $stateParams, $rootScope, $filter) {
        $scope.person = $rootScope.person;
        $scope.localLang = {
            "nothingSelected": "Другие персоны подборки",
            "selectAll": "Выбрать все",
            "selectNone": "Снять выделение",
            "reset": "Сброс",
            "search": "Поиск"
        };

        //$scope.selectedPerson = function (id) {
        //    $rootScope.person = $filter('filter')($rootScope.persons, { Id: id })[0];
        //}
        function reloadPersons() {
            var persons = $filter('filter')($rootScope.persons, { Id: '!' + $rootScope.person.Id });

            var morePerson = [];
            persons.forEach(function (item) {
                morePerson.push({ id: item.Id, name: item.LastName + ' ' + item.Name, ticked: false });
            });
            $scope.morePerson = morePerson;
            $rootScope.otherPerson = [];
        }

        if ($rootScope.person && $rootScope.persons)
            reloadPersons();

        function watchPersons() {
            if ($rootScope.persons && $rootScope.person)
                reloadPersons();
        }
        $rootScope.$watch('persons', watchPersons);
        $scope.$watch('person', function(item) {
            $rootScope.person = item;
            watchPersons();
        });
    }
})();