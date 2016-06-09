(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaController', MainPersonaController)
        .config(config);


    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.when("/main/persona", "/main/persona/1");

        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/main/event-is/detail/1");

        $stateProvider
            .state('main.persona.index', {
                url: '/:id',
                templateUrl: '/main/persona/index.view.html',
                controller: 'MainPersonaIndexController'
            })
    }

    MainPersonaController.$inject = ['$scope', '$rootScope', '$stateParams'];

    function MainPersonaController($scope, $rootScope, $stateParams) {
        $rootScope.id = $stateParams.id;

        $rootScope.HidePersonaMenu = function () {
            $('#persona-menu').hide();
            $('#personacontent').addClass('col-md-24').removeClass('col-md-18');
        };

        $rootScope.personaMenuFilter = '';

        $scope.menuScope = [
            {
                id: 1,
                name: 'Абакачева Светлана',
                type: 'Театр',
                event: 'Современник'
            },
            {
                id: 2,
                name: 'Абакачева Светлана',
                type: 'Театр',
                event: 'Современник'
            },
            {
                id: 3,
                name: 'Абакачева Светлана',
                type: 'Театр',
                event: 'Современник'
            },
            {
                id: 4,
                name: 'Абакачева Светлана',
                type: 'Театр',
                event: 'Современник'
            },
            {
                id: 5,
                name: 'Абакачева Светлана',
                type: 'Театр',
                event: 'Современник'
            },
            {
                id: 6,
                name: 'Абакачева Светлана',
                type: 'Театр',
                event: 'Современник'
            },
            {
                id: 7,
                name: 'Абакачева Светлана',
                type: 'Театр',
                event: 'Современник'
            },
            {
                id: 8,
                name: 'Тимберлейк Джастин',
                nameTranslated: 'Timberlake Justin',
                type: 'Музыка',
                event: 'Justify'
            },
            {
                id: 9,
                name: 'Тимберлейк Джастин',
                nameTranslated: 'Timberlake Justin',
                type: 'Музыка',
                event: 'Justify'
            },
            {
                id: 10,
                name: 'Тимберлейк Джастин',
                nameTranslated: 'Timberlake Justin',
                type: 'Музыка',
                event: 'Justify'
            },
            {
                id: 11,
                name: 'Тимберлейк Джастин',
                nameTranslated: 'Timberlake Justin',
                type: 'Музыка',
                event: 'Justify'
            },
            {
                id: 12,
                name: 'Тимберлейк Джастин',
                nameTranslated: 'Timberlake Justin',
                type: 'Музыка',
                event: 'Justify'
            },
            {
                id: 13,
                name: 'Тимберлейк Джастин',
                nameTranslated: 'Timberlake Justin',
                type: 'Музыка',
                event: 'Justify'
            },
            {
                id: 14,
                name: 'Тимберлейк Джастин',
                nameTranslated: 'Timberlake Justin',
                type: 'Музыка',
                event: 'Justify'
            }
        ];

        $scope.predicate = 'name';
        $scope.reverse = false;

        $scope.order = function (predicate) {
            $scope.reverse = ($scope.predicate == predicate) ? !$scope.reverse : false;
            $scope.predicate = predicate;
        };

        $rootScope.person = {
            id: 1,
            name: {
                firstName: 'Анна',
                lastName: 'Сидорова',
                middleName: 'Владимировна'
            },
            nameTranslated: {
                firstName: 'Anna',
                lastName: 'Sidorova',
                middleName: 'Vladimirova'
            }
        };
    }
})();