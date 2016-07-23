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
            .state('main.persona.schema', {
                url: '/create/schema',
                templateUrl: '/main/persona/create/schema.view.html',
                controller: 'MainPersonaCreateSchemaController'
            })
            .state('main.persona.overview', {
                url: '/create/overview',
                templateUrl: '/main/persona/create/overview.view.html',
                controller: 'MainPersonaCreateOverviewController'
            })
            .state('main.persona.create', {
                url: '/create',
                templateUrl: '/main/persona/create.view.html',
                controller: 'MainPersonaCreateController'
            })
            .state('main.persona.index', {
                url: '/:id',
                templateUrl: '/main/persona/index.view.html',
                controller: 'MainPersonaIndexController'
            });
    }

    

    MainPersonaController.$inject = ['$scope', '$rootScope', '$stateParams', '$location', '$http'];

    function MainPersonaController($scope, $rootScope, $stateParams, $location, $http) {
        $rootScope.id = $stateParams.id;
        var indx = 0;
        $rootScope.HidePersonaMenu = function () {
            $('#persona-menu').hide();
            $('#personacontent').addClass('col-md-24').removeClass('col-md-18');
        };

        $rootScope.personaMenuFilter = '';

        $scope.menuScope = [
            //{
            //    id: 1,
            //    name: 'Абакачева Светлана',
            //    type: 'Театр',
            //    event: 'Современник'
            //},
            //{
            //    id: 2,
            //    name: 'Абакачева Светлана',
            //    type: 'Театр',
            //    event: 'Современник'
            //},
            //{
            //    id: 3,
            //    name: 'Абакачева Светлана',
            //    type: 'Театр',
            //    event: 'Современник'
            //},
            //{
            //    id: 4,
            //    name: 'Абакачева Светлана',
            //    type: 'Театр',
            //    event: 'Современник'
            //},
            //{
            //    id: 5,
            //    name: 'Абакачева Светлана',
            //    type: 'Театр',
            //    event: 'Современник'
            //},
            //{
            //    id: 6,
            //    name: 'Абакачева Светлана',
            //    type: 'Театр',
            //    event: 'Современник'
            //},
            //{
            //    id: 7,
            //    name: 'Абакачева Светлана',
            //    type: 'Театр',
            //    event: 'Современник'
            //},
            //{
            //    id: 8,
            //    name: 'Тимберлейк Джастин',
            //    nameTranslated: 'Timberlake Justin',
            //    type: 'Музыка',
            //    event: 'Justify'
            //},
            //{
            //    id: 9,
            //    name: 'Тимберлейк Джастин',
            //    nameTranslated: 'Timberlake Justin',
            //    type: 'Музыка',
            //    event: 'Justify'
            //},
            //{
            //    id: 10,
            //    name: 'Тимберлейк Джастин',
            //    nameTranslated: 'Timberlake Justin',
            //    type: 'Музыка',
            //    event: 'Justify'
            //},
            //{
            //    id: 11,
            //    name: 'Тимберлейк Джастин',
            //    nameTranslated: 'Timberlake Justin',
            //    type: 'Музыка',
            //    event: 'Justify'
            //},
            //{
            //    id: 12,
            //    name: 'Тимберлейк Джастин',
            //    nameTranslated: 'Timberlake Justin',
            //    type: 'Музыка',
            //    event: 'Justify'
            //},
            //{
            //    id: 13,
            //    name: 'Тимберлейк Джастин',
            //    nameTranslated: 'Timberlake Justin',
            //    type: 'Музыка',
            //    event: 'Justify'
            //},
            //{
            //    id: 14,
            //    name: 'Тимберлейк Джастин',
            //    nameTranslated: 'Timberlake Justin',
            //    type: 'Музыка',
            //    event: 'Justify'
            //}
        ];

        //$http({
        //    url: `${apiUrl}persons`,///${pageNumber}/${pageSize}
        //    method: "POST",
        //    headers: { 'Content-Type': 'application/json; charset=UTF-8' }
        //}).success(function (data) {
        //    $rootScope.persons = data;
        //    $rootScope.persons.forEach(function (item) {
        //        $scope.menuScope.push({
        //            id: item.Id,
        //            name: {
        //                firstName: item.Name,
        //                lastName: item.LastName,
        //                middleName: item.Patronymic
        //            },
        //            nameTranslated: {
        //                firstName: item.NameLatin,
        //                lastName: item.LastNameLatin,
        //                middleName: item.PatronymicLatin
        //            },
        //            type: item.EventType,
        //            event: item.EventName
        //        });
        //    });
        //});
        $http.get(`${apiUrl}persons`).success(function (data) {
            $rootScope.persons = data;
            $rootScope.persons.forEach(function (item) {
                if (indx > 20) return ;
                    $scope.menuScope.push({
                        id: item.Id,
                        name: {
                            firstName: item.Name,
                            lastName: item.LastName,
                            middleName: item.Patronymic
                        },
                        nameTranslated: {
                            firstName: item.NameLatin,
                            lastName: item.LastNameLatin,
                            middleName: item.PatronymicLatin
                        },
                        type: item.EventType,
                        event: item.EventName
                    });
                    indx++;
                });
        });

        $scope.predicate = 'name.lastName';
        $scope.reverse = false;

        $scope.order = function (predicate) {
            $scope.reverse = ($scope.predicate == predicate) ? !$scope.reverse : false;
            $scope.predicate = predicate;
        };
        function getTypes() {
            if (!$rootScope.descriptiontypes) {
                $rootScope.descriptiontypes = [];
                $http.get(`${apiUrl}persons/description/types`).success(function (data) {
                    $rootScope.descriptiontypes.push.apply($rootScope.descriptiontypes, data);
                });
            }
            if (!$rootScope.facttypes) {
                $rootScope.facttypes = [];
                $http.get(`${apiUrl}persons/fact/types`).success(function (data) {
                    $rootScope.facttypes.push.apply($rootScope.facttypes, data);
                });
            }
            if (!$rootScope.connectiontypes) {
                $rootScope.connectiontypes = [];
                $http.get(`${apiUrl}persons/connection/types`).success(function (data) {
                    $rootScope.connectiontypes.push.apply($rootScope.connectiontypes, data);
                });
            }
            if (!$rootScope.mediatypes) {
                $rootScope.mediatypes = [];
                $http.get(`${apiUrl}persons/media/types`).success(function (data) {
                    $rootScope.mediatypes.push.apply($rootScope.mediatypes, data);
                });
            }
            if (!$rootScope.socialtypes) {
                $rootScope.socialtypes = [];
                $http.get(`${apiUrl}persons/social/types`).success(function (data) {
                    $rootScope.socialtypes.push.apply($rootScope.socialtypes, data);
                });
            }
            if (!$rootScope.antronames) {
                $rootScope.antronames = [];
                $http.get(`${apiUrl}persons/antro/names`).success(function (data) {
                    $rootScope.antronames.push.apply($rootScope.antronames, data);
                });
            }
        };
        getTypes();

        //$rootScope.person = {
        //    id: 1,
        //    name: {
        //        firstName: 'Анна',
        //        lastName: 'Сидорова',
        //        middleName: 'Владимировна'
        //    },
        //    nameTranslated: {
        //        firstName: 'Anna',
        //        lastName: 'Sidorova',
        //        middleName: 'Vladimirova'
        //    }
        //};

        $scope.CreatePersona = function () {
            $location.path("/main/persona/create");
        }
    }
})();