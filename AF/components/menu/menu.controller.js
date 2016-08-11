angular.module('app')
    .controller('mainMenuCtrl', mainMenuCtrl)
    .directive('mainMenu', function () {
        return {
            restrict: 'E',
            templateUrl: '/components/menu/menu.view.html',
            controller: 'mainMenuCtrl'
        };
    });

mainMenuCtrl.$inject = ['$scope', '$location', '$timeout', '$http', '$compile'];
function mainMenuCtrl($scope, $location, $timeout, $http, $compile) {

    $scope.HideCustomMenu = function () {
        $timeout(function () {
            angular.element('.main-menu__list li.active > button').triggerHandler('click');
        });
    };
    var link = '/app-content/images/MainMenu.svg#';
    $scope.showWidth = true;
    $scope.menu = [
        {
            title: 'Мероприятия',
            href: '/main/events/base.html',
            customMenu: {
                expand: '.custom-menu__container',
                toggle: '#events__container'
            },
            refSvg: link + 'Events'
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
            },
            refSvg: link + 'ActiveEvents'
        },
        {
            "title": "Площадки",
            "href": "/main/platform",
            refSvg: link + 'Venues'
        },
        {
            "title": "Залы",
            "href": "/main/halls",
            refSvg: link + 'Halls'
        },
        {
            "title": "Роли",
            "href": "/main/role",
            refSvg: link + 'Roles-Rights'
        },
        {
            "title": "Пользователи",
            "href": "/main/user",
            customMenu: {
                expand: '.custom-menu__container',
                toggle: '#user__container'
            },
            "content": "#usercontent",
            refSvg: link + 'Users'
        },
        {
            title: 'Персоны',
            href: '/main/persona',
            customMenu: {
                expand: '.custom-menu__container',
                toggle: '#persona__container'
            },
            refSvg: link + 'Persons'
        },
        {
            "title": "Загрузка",
            "href": "/main/download",
            refSvg: link + 'Persons'
        },

    ];

    $timeout(function () {
        isActive();
    });

    $scope.ToggleCustomMenu = function (customMenu) {
        if (customMenu) {
            var menu = $(customMenu.expand);
            var content = $(customMenu.toggle);

            menu.toggle();
            content.toggleClass('col-md-19 col-md-24');
        }
        $scope.showWidth = !$scope.showWidth;
        $('#main-menu__container').toggleClass('col-md-3 col-md-1');
    };

    $scope.$watch(function () {
        return $location.path();
    }, function (params) {
        app.loadContentView($location.path(), 2500);
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