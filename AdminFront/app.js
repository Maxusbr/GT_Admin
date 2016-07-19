//set api adress
var apiUrl = 'http://localhost:35162/';


(function () {
    'use strict';

    angular
        .module('app', [
            // 'ngRoute',
            'ui.router',
            'ngCookies',
            'vcRecaptcha',
            'ngMessages',
            'ngResource'
            // 'webix'
        ])
        .config(config)
        .run(run);

    run.$inject = ['$rootScope', '$templateCache'];

    function run($rootScope, $templateCache) {
        $rootScope.$on('$viewContentLoaded', function () {
            $templateCache.removeAll();
        })
    }

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider', '$httpProvider'];
    function config($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {


        $urlRouterProvider.when("", "/main");
        $urlRouterProvider.when("/", "/main");
        
        

        // For any unmatched url, send to /route1
        //$urlRouterProvider.otherwise("/login");

        $stateProvider
            .state('main', {
                abstract: true,
                url: '/main',
                templateUrl: '/main/main.view.html',
                controller: 'MainController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter main abstract");
                }
            })
            .state('home', {
                url: '/',
                templateUrl: '/home/home.view.html',
                controller: 'HomeController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter home");
                }
            })
            .state('login', {
                url: '/sign-in',
                templateUrl: '/login/login.view.html',
                controller: 'LoginController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter login");
                }
            })
            .state('registration', {
                url: '/registration',
                templateUrl: '/register/register.view.html',
                controller: 'RegisterController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter register");
                }
            })
            .state('registration.confirm', {
                url: '/confirm',
                templateUrl: '/confirm/confirm.view.html',
                controller: 'ConfirmController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter confirm");
                }
            })
            .state('recovery', {
                url: '/recovery',
                templateUrl: '/recovery/recovery.view.html',
                controller: 'RecoveryController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter recovery");
                }
            })
            .state('recovery.congirm', {
                url: '/:key',
                templateUrl: '/recovery_confirm/recovery_confirm.view.html',
                controller: 'RecoveryConfirmController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter recovery_confirm");
                }
            })
            .state('change_password', {
                url: '/change_password',
                templateUrl: '/change_password/change_password.view.html',
                controller: 'ChangePasswordController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter change_password");
                }
            })
            .state('success', {
                url: '/success',
                templateUrl: '/success/success.view.html',
                controller: 'SuccessController',
                controllerAs: 'vm',
                onEnter: function () {
                    console.log("enter success");
                }
            });

        /**
         * Не даем браузеру кэшировать ангулярку, альтернатива -- правильная настройка бэкенда
         */
        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }

        $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';

        // $locationProvider.html5Mode(true).hashPrefix('#');
    }


})();