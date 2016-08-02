(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaCreateController', MainPersonaCreateController)
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        
    }

    MainPersonaCreateController.$inject = ['$scope', '$stateParams', '$rootScope', '$filter', 'personService', '$location'];

    function MainPersonaCreateController($scope, $stateParams, $rootScope, $filter, personService, $location) {
        $scope.localLang = {
            "nothingSelected": "Другие персоны подборки",
            "selectAll": "Выбрать все",
            "selectNone": "Снять выделение",
            "reset": "Сброс",
            "search": "Поиск"
        };
        if (!$rootScope.person && $rootScope.persons)
            $rootScope.person = $rootScope.persons.filter(function (item) { return item.Id === $rootScope.id; })[0];
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

        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });
        $scope.personTags = [];

        $scope.loadTags = function (query) {
            var result = $scope.tags.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
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

        $scope.showSchema = function () {
            if (!$rootScope.person) return;
            personService.savePersonTags($rootScope.person.Id, $scope.personTags, function (data) {
                if (data.Message)
                    $scope.response = data.Message;
                else {
                    $location.path("/main/persona/create/schema");
                }
            });
        }
    }
})();