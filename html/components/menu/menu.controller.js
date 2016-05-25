angular.module('app')
    .controller('mainMenuCtrl', mainMenuCtrl)
    .directive('mainMenu', function () {
        return {
            restrict: 'E',
            templateUrl: '/components/menu/menu.view.html',
            controller: 'mainMenuCtrl'
        };
    });

mainMenuCtrl.$inject = ['$rootScope', '$location'];
function mainMenuCtrl($rootScope, $location) {

    $rootScope.menu = [
        {
            "title": "Мероприятия",
            "href": "/main/events"
        },
        {
            "title": "События",
            "href": "/main/event-is",
            "button": true,
            "menu": "#eventismenu",
            "content": "#eventiscontent",
            "w": 3
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
            "button": true,
            "menu": "#usermenu",
            "content": "#usercontent",
            "w": 2
        }
    ];

    $rootScope.isActive = function (location) {
        // console.log($location.path() +' ' +location);
        // console.log($location.path().search(location));
        // console.log($location.path().search(location) > -1);
        // return location === '/#' + $location.path()
        return $location.path().search(location) > -1
    }
    $rootScope.ShowMenu = function (menu, content, w) {
        var nw = 12 - w
        console.log(menu, ' ', content, ' ', 'col-md-' + nw);
        $(menu).collapse('toggle');
        if ($(menu).is(':visible')) {
            $(content).removeClass('col-md-12');
            $(content).addClass('col-md-' + nw);
        } else {
            $(content).removeClass('col-md-' + nw);
            $(content).addClass('col-md-12');
        }

    }

}

