(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaCreateController', MainPersonaCreateController)
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        
    }

    MainPersonaCreateController.$inject = ['$scope', '$stateParams', '$rootScope', '$filter'];

    function MainPersonaCreateController($scope, $stateParams, $rootScope, $filter) {
        $scope.localLang = {
            "nothingSelected": "Другие персоны подборки",
            "selectAll": "Выбрать все",
            "selectNone": "Снять выделение",
            "reset": "Сброс",
            "search": "Поиск"
        };

        $scope.person = $rootScope.person;
        $scope.otherPerson = $rootScope.otherPerson;

        function reloadPersons() {
            var persons = $filter('filter')($rootScope.persons, { Id: '!' + $rootScope.person.Id });

            var morePerson = [];
            persons.forEach(function (item) {
                var el = $filter('filter')($scope.otherPerson, { id: item.Id });
                var ticked = el && el.length > 0;
                morePerson.push({ id: item.Id, name: item.LastName + ' ' + item.Name, ticked: ticked === true });
            });
            $scope.morePerson = morePerson;
            console.log("reload other Persons");
        }

        function watchPersons() {
            if ($rootScope.persons && $rootScope.person)
                reloadPersons();
        }

        $rootScope.$watch('persons', watchPersons);
        $scope.$watch('person', function (item) {
            if($rootScope.person == item) return;
            $rootScope.person = item;
            watchPersons();
        });
        $scope.$watch('otherPerson', function (items) {
            $rootScope.otherPerson = items;
        });
    }
})();