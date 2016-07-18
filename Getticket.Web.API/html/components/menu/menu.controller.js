angular.module('app')
    .controller('mainMenuCtrl', mainMenuCtrl)
    .directive('mainMenu', function () {
        return {
            restrict: 'E',
            templateUrl: '/components/menu/menu.view.html',
            controller: 'mainMenuCtrl'
        };
    });

    mainMenuCtrl.$inject = ['$scope', '$location', '$timeout'];
function mainMenuCtrl($scope, $location, $timeout) {

    $scope.HideCustomMenu = function () {
        $timeout(function () {
            angular.element('.main-menu__list li.active > button').triggerHandler('click');
        });
    };

    $scope.menu = [
        {
            "title": "Мероприятия",
            "href": "/main/events"
        },
        {
            "title": "События",
            "href": "/main/event-is",
            "countActive": "25",
            "countAll": "55",
            "content": "#eventiscontent",
            customMenu: {
                expand: '.custom-menu__container',
                toggle: '#eventIs__content'
            }
        },
        {
            "title": "Площадки",
            "href": "/main/platform"
        },
        {
            "title": "Залы",
            "href": "/main/halls"
        },
        {
            "title": "Роли",
            "href": "/main/role"
        },
        {
            "title": "Пользователи",
            "href": "/main/user",
            customMenu: {
                expand: '.custom-menu__container',
                toggle: '#user__container'
            },
            "content": "#usercontent"
        },
        {
            title: 'Персоны',
            href: '/main/persona',
            button: true,
            customMenu: {
                expand: '.custom-menu__container',
                toggle: '#persona__container'
            }
        }

    ];

    $timeout(function() {
        isActive();
    });

    $scope.ToggleCustomMenu = function (menuSelector, toggleSelector) {
        var menu = $(menuSelector);
        var content = $(toggleSelector);

        menu.toggle();
        content.toggleClass('col-md-19 col-md-24');
    };

    $scope.$watch(function () {
        return $location.path()
    }, function (params) {
        isActive();
    });

    function isActive() {
        $.each($('#main-menu__container a'), function (key, val) {
            if (('/#' + $location.path()).indexOf($(val).attr('href')) >= 0) {
                $scope.menu[key].active = true;
            }
            else {
                $scope.menu[key].active = false;
            }
        });

    }
}