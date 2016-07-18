angular.module('app')
    .directive('language', function () {
        return {
            restrict: 'AE',
            templateUrl: '/components/lang/lang.view.html',
            controller: function ($scope, $cookies, $cookieStore, UserService, $location, $rootScope, FlashService, vcRecaptchaService) {

                $scope.language = $cookieStore.get('lang');

                if (!$scope.language) {
                    $cookieStore.put('lang', 'ru');
                    $scope.language = 'ru';
                }

                $scope.set_ru = function () {
                    console.info('Set ru ready!');
                    $cookieStore.put('lang', 'ru');
                    $scope.language = 'ru'
                };
                $scope.set_us = function () {
                    console.info('Set us ready');
                    $cookieStore.put('lang', 'us');
                    $scope.language = 'us'
                };
            }
        };
    });