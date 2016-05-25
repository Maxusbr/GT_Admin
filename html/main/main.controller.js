﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainController', MainController)
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.when("/main", "/main/user");

        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/main/user");

        $stateProvider
            .state('main.user', {
                abstract: true,
                url: '/user',
                // loaded into ui-view of parent's template
                templateUrl: '/main/user/user.view.html',
                // controller: 'MainUserController',
                onEnter: function () {
                    console.log("enter main.user");
                }
            })
            .state('main.events', {
                url: '/events',
                // loaded into ui-view of parent's template
                templateUrl: '/main/events/events.view.html',
                controller: 'MainEventsController',
                onEnter: function () {
                    console.log("enter main.events");
                }
            })
            .state('main.eventsis', {
                abstract: true,
                url: '/event-is',
                // loaded into ui-view of parent's template
                templateUrl: '/main/events-is/events-is.view.html',
                controller: 'MainEventsIsController',
                onEnter: function () {
                    console.log("enter main.events-is");
                }
            })
            .state('main.halls', {
                url: '/halls',
                // loaded into ui-view of parent's template
                templateUrl: '/main/halls/halls.view.html',
                controller: 'MainHallsController',
                onEnter: function () {
                    console.log("enter main.halls");
                }
            })
            .state('main.platform', {
                url: '/platform',
                // loaded into ui-view of parent's template
                templateUrl: '/main/platform/platform.view.html',
                controller: 'MainPlatformController',
                onEnter: function () {
                    console.log("enter main.platform");
                }
            })
            .state('main.role', {
                url: '/role',
                // loaded into ui-view of parent's template
                templateUrl: '/main/role/role.view.html',
                controller: 'MainRoleController',
                onEnter: function () {
                    console.log("enter main.role");
                }
            })

    }
    
    MainController.$inject = ['$rootScope'];
    function MainController($rootScope) {
    }


})();