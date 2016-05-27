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
            "countActive": "25",
            "countAll": "55",
            "menu": "#eventismenu",
            "content": "#eventiscontent",
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
        }
    ];

    $rootScope.isActive = function (location) {
        // console.log($location.path() +' ' +location);
        // console.log($location.path().search(location));
        // console.log($location.path().search(location)>=0);
        // return location === '/#' + $location.path()
        return $location.path().search(location) >= 0;
    }
    $rootScope.ShowMenu = function (menu, content) {
        if (!$(menu).is('.in')) {
            if ($(menu).is('.col-md-2')) {
                $(content).addClass('col-md-10 col-sm-10');
            }
            if ($(menu).is('.col-md-3')) {
                $(content).addClass('col-md-9 col-sm-9');
            }
            $(content).removeClass('col-md-12 col-sm-12');
        } else {
            $(content).removeClass('col-md-9 col-sm-9')
            $(content).removeClass('col-md-10 col-sm-10');
            $(content).addClass('col-md-12 col-sm-12');
        }
        $(menu).collapse('toggle');
    }

}

