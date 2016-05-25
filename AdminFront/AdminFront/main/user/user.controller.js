        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/main/user/list");
        $stateProvider
            .state('main.user.list', {
                url: '/list',
                // loaded into ui-view of parent's template
                templateUrl: '/main/user/list.view.html',
                controller: 'MainUserListController',
                onEnter: function () {
                    console.log("enter main.user.list");
                }
            })
            .state('main.user.invite', {
                url: '/invite',
                // loaded into ui-view of parent's template
                templateUrl: '/main/user/invite.view.html',
                controller: 'MainUserInviteController',
                onEnter: function () {
                    console.log("enter main.user.invite");
                }
            })
            .state('main.user.register', {
                url: '/register',
                // loaded into ui-view of parent's template
                templateUrl: '/main/user/register.view.html',
                controller: 'MainUserRegisterController',
                onEnter: function () {
                    console.log("enter main.user.register");
                }
            })
            .state('main.user.profile', {
                url: '/profile/:id',
                // loaded into ui-view of parent's template
                templateUrl: '/main/user/profile.view.html',
                controller: 'MainUserProfileController',
                onEnter: function () {
                    console.log("enter main.user.profile");
                }
            })
    MainUserController.$inject = [/*'UserService',*/ '$rootScope'];
    function MainUserController(/*UserService,*/ $rootScope) {
        var vm = this;

(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainUserController', MainUserController)
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.when("/main/user", "/main/user/list");
    }

})();
