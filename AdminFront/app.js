﻿//set api adress
var apiUrl = 'http://localhost:35162/';
//var apiUrl = 'http://getticketwebapi.azurewebsites.net/';
var pageNumber = 1;
var pageSize = 20;

(function () {
    'use strict';

    var app = angular
        .module('app', [
            // 'ngRoute',
            'ui.router',
            'ngCookies',
            'vcRecaptcha',
            'ngMessages',
            'ngResource',
            'angularMoment', 'isteven-multi-select', 'datePicker', 'ui.bootstrap', 'ngTagsInput'
            // 'webix'
        ])
        .config(config)
        .run(run);

    run.$inject = ['$rootScope', '$templateCache', '$cookieStore', '$location', '$http', 'amMoment'];

    function run($rootScope, $templateCache, $cookieStore, $location, $http, amMoment) {
        amMoment.changeLocale('ru');
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Bearer ' + $rootScope.globals.currentUser.token; // jshint ignore:line
        }
        $rootScope.$on('$viewContentLoaded', function() {
            //$templateCache.removeAll();
            //addThemplates($templateCache);
            var restrictedPage = $.inArray($location.path(), ['/login', '/registration', '/sign-in']) === -1;
            var loggedIn = $rootScope.globals.currentUser;
            if (restrictedPage && !loggedIn) {
                $location.path('/sign-in');
            }
        });
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

    function addThemplates($templateCache) {
        var template =
        '<span class="multiSelect inlineBlock">' +
            // main button
            '<button id="{{directiveId}}" type="button"' +
                'ng-click="toggleCheckboxes( $event ); refreshSelectedItems(); refreshButton(); prepareGrouping; prepareIndex();"' +
                'ng-bind-html="varButtonLabel"' +
                'ng-disabled="disable-button"' +
            '>' +
            '</button>' +
            // overlay layer
            '<div class="checkboxLayer">' +
                // container of the helper elements
                '<div class="helperContainer" ng-if="helperStatus.filter || helperStatus.all || helperStatus.none || helperStatus.reset ">' +
                    // container of the first 3 buttons, select all, none and reset
                    '<div class="line" ng-if="helperStatus.all || helperStatus.none || helperStatus.reset ">' +
                        // select all
                        '<button type="button" class="helperButton"' +
                            'ng-disabled="isDisabled"' +
                            'ng-if="helperStatus.all"' +
                            'ng-click="select( \'all\', $event );"' +
                            'ng-bind-html="lang.selectAll">' +
                        '</button>' +
                        // select none
                        '<button type="button" class="helperButton"' +
                            'ng-disabled="isDisabled"' +
                            'ng-if="helperStatus.none"' +
                            'ng-click="select( \'none\', $event );"' +
                            'ng-bind-html="lang.selectNone">' +
                        '</button>' +
                        // reset
                        '<button type="button" class="helperButton reset"' +
                            'ng-disabled="isDisabled"' +
                            'ng-if="helperStatus.reset"' +
                            'ng-click="select( \'reset\', $event );"' +
                            'ng-bind-html="lang.reset">' +
                        '</button>' +
                    '</div>' +
                    // the search box
                    '<div class="line" style="position:relative" ng-if="helperStatus.filter">' +
                        // textfield                
                        '<input placeholder="{{lang.search}}" type="text"' +
                            'ng-click="select( \'filter\', $event )" ' +
                            'ng-model="inputLabel.labelFilter" ' +
                            'ng-change="searchChanged()" class="inputFilter"' +
                            '/>' +
                        // clear button
                        '<button type="button" class="clearButton" ng-click="clearClicked( $event )" >×</button> ' +
                    '</div> ' +
                '</div> ' +
                // selection items
                '<div class="checkBoxContainer">' +
                    '<div ' +
                        'ng-repeat="item in filteredModel | filter:removeGroupEndMarker" class="multiSelectItem"' +
                        'ng-class="{selected: item[ tickProperty ], horizontal: orientationH, vertical: orientationV, multiSelectGroup:item[ groupProperty ], disabled:itemIsDisabled( item )}"' +
                        'ng-click="syncItems( item, $event, $index );" ' +
                        'ng-mouseleave="removeFocusStyle( tabIndex );"> ' +
                        // this is the spacing for grouped items
                        '<div class="acol" ng-if="item[ spacingProperty ] > 0" ng-repeat="i in numberToArray( item[ spacingProperty ] ) track by $index">' +
                    '</div>  ' +
                    '<div class="acol">' +
                        '<label>' +
                            // input, so that it can accept focus on keyboard click
                            '<input class="checkbox focusable" type="checkbox" ' +
                                'ng-disabled="itemIsDisabled( item )" ' +
                                'ng-checked="item[ tickProperty ]" ' +
                                'ng-click="syncItems( item, $event, $index )" />' +
                            // item label using ng-bind-hteml
                            '<span ' +
                                'ng-class="{disabled:itemIsDisabled( item )}" ' +
                                'ng-bind-html="writeLabel( item, \'itemLabel\' )">' +
                            '</span>' +
                        '</label>' +
                    '</div>' +
                    // the tick/check mark
                    '<span class="tickMark" ng-if="item[ groupProperty ] !== true && item[ tickProperty ] === true" ng-bind-html="icon.tickMark"></span>' +
                '</div>' +
            '</div>' +
        '</div>' +
    '</span>';
        $templateCache.put('isteven-multi-select.htm', template);
    }

    app.directive('ngConfirmClick', [
        function () {
            return {
                link: function (scope, element, attr) {
                    var msg = attr.ngConfirmClick || "Вы уверены?";
                    var clickAction = attr.confirmedClick;
                    element.bind('click', function (event) {
                        if (window.confirm(msg)) {
                            scope.$eval(clickAction);
                        }
                    });
                }
            };
        }
    ]);
})();