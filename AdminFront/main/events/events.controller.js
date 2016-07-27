(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainEventsController', MainEventsController)
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.when("/main/events", "/main/events/1");

        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/main/events/1");

        $stateProvider
            .state('main.events.schema', {
                url: '/create/schema',
                templateUrl: '/main/enets/create/schema.view.html',
                controller: 'MainEventCreateSchemaController'
            })
            .state('main.events.overview', {
                url: '/create/overview',
                templateUrl: '/main/enets/create/overview.view.html',
                controller: 'MainEventCreateOverviewController'
            })
            .state('main.events.create', {
                url: '/create',
                templateUrl: '/main/events/create.view.html',
                controller: 'MainEventsCreateController'
            });
        //.state('main.persona.index', {
        //    url: '/:id',
        //    templateUrl: '/main/persona/index.view.html',
        //    controller: 'MainPersonaIndexController'
        //});
    }




    MainEventsController.$inject = ['$scope', '$rootScope', '$stateParams', '$location', '$http'];
    function MainEventsController($scope, $rootScope, $stateParams, $location, $http) {
        var vm = this;
        //$rootScope.eventsMenuFilter = '';


        //display view for create new event
        $scope.CreateEvent = function () {
            $location.path("/main/events/create");
        }
    }

})();