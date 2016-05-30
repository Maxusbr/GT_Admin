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
            "href": "/main/events",
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
            "href": "/main/platform",
        },
        {
            "title": "Залы",
            "href": "/main/halls",
        },
        {
            "title": "Роли",
            "href": "/main/role",
        },
        {
            "title": "Пользователи",
            "href": "/main/user",
            "button": true,
            "menu": "#usermenu",
            "content": "#usercontent",
            "active": true
        }
    ];

    // $rootScope.isActive = isActive;
    $rootScope.ShowMenu = ShowMenu;
    // $rootScope.ClickMenu = ClickMenu;


    $rootScope.$watch(function () {
        return $location.path()
    }, function (params) {
        console.log(params);
        isActive();
    });


    function isActive() {
        $.each($('#mainmenu a'), function (key, val) {
            if (('/#' + $location.path()).indexOf($(val).attr('href')) >= 0) {
                $rootScope.menu[key].active = true;
            } else {
                $rootScope.menu[key].active = false;
            }
        });
    }


    function ShowMenu(menu, content) {
        // $location.path("/main/user/list");

        if (!$(menu).is(':visible')) {
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
        // $(menu).collapse('toggle');
        $(menu).toggle();
        $('#addbutton').hide();
        $('#plusbutton').show();
    }

}

