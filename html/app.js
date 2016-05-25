(function () {
    'use strict';

    angular
        .module('app', [
            // 'ngRoute',
            'ui.router',
            'ngCookies',
            'vcRecaptcha',
            // 'ngMessages',
            'ngResource',
            // 'webix'
        ])
        .config(config);
    // .run(run);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {


        $urlRouterProvider.when("", "/main");
        $urlRouterProvider.when("/", "/main");

        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/login");

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
            })

        //$locationProvider.html5Mode(true);
    }


    // run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];
    // function run($rootScope, $location, $cookieStore, $http, $httpProvider) {
        // keep user logged in after page refresh
    /*

        $http.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
        delete $http.defaults.headers.common['X-Requested-With'];

        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in and trying to access a restricted page
            var restrictedPage = $.inArray($location.path(),
                    ['/main',
                        '/main/user',
                        '/main/user/register',
                        '/main/user/invite',
                        '/main/user/profile',
                        '/main/role',
                        '/main/events',
                        '/main/events-is',
                        '/main/platform',
                        '/main/halls',
                        '/sign-in', '/registration', '/registration/confirm', '/recovery', '/success']) === -1;
            var recovery = $location.path().indexOf('/recovery/') + 1;
            var loggedIn = $rootScope.globals.currentUser;
            if (restrictedPage && !loggedIn && !recovery) {
                $location.path('/sign-in');
            }
        });
     */
    // }

})();