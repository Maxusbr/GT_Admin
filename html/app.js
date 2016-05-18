(function () {
    'use strict';

    angular
        .module('app', [
          'ngRoute',
          'ngCookies',
          'vcRecaptcha',
          'ngResource',
            // 'webix'
        ])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController',
                templateUrl: 'home/home.view.html',
                controllerAs: 'vm'
            })

            .when('/sign-in', {
                controller: 'LoginController',
                templateUrl: 'login/login.view.html',
                controllerAs: 'vm'
            })

            .when('/registration', {
                controller: 'RegisterController',
                templateUrl: 'register/register.view.html',
                controllerAs: 'vm'
            })

            .when('/registration/confirm', {
                controller: 'ConfirmController',
                templateUrl: 'confirm/confirm.view.html',
                controllerAs: 'vm'
            })

            .when('/recovery', {
              controller: 'RecoveryController',
              templateUrl: 'recovery/recovery.view.html',
              controllerAs: 'vm'
            })

            .when('/recovery/:key', {
              controller: 'RecoveryConfirmController',
              templateUrl: 'recovery_confirm/recovery_confirm.view.html',
              controllerAs: 'vm'
            })

            .when('/change_password', {
              controller: 'ChangePasswordController',
              templateUrl: 'change_password/change_password.view.html',
              controllerAs: 'vm'
            })

            .when('/success', {
              controller: 'SuccessController',
              templateUrl: 'success/success.view.html',
              controllerAs: 'vm'
            })

            .otherwise({ redirectTo: '/login' });

        //$locationProvider.html5Mode(true);
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];
    function run($rootScope, $location, $cookieStore, $http, $httpProvider) {
        // keep user logged in after page refresh

        $http.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
        delete $http.defaults.headers.common['X-Requested-With'];

        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in and trying to access a restricted page
            var restrictedPage = $.inArray($location.path(), ['/sign-in', '/registration', '/registration/confirm', '/recovery', '/success']) === -1;
            var recovery = $location.path().indexOf('/recovery/') + 1;
            var loggedIn = $rootScope.globals.currentUser;
            if (restrictedPage && !loggedIn && !recovery) {
                $location.path('/sign-in');
            }
        });
    }

})();