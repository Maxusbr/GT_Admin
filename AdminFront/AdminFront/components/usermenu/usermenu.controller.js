angular.module('app')
    .controller('userMenuCtrl', userMenuCtrl)
    .directive('userMenu', function () {
        return {
            restrict: 'E',
            templateUrl: '/components/usermenu/usermenu.view.html',
            controller: 'userMenuCtrl'
        };
    });

userMenuCtrl.$inject = ['$rootScope', '$location'];
function userMenuCtrl($rootScope, $location) {

    $rootScope.usermenu = [
        {
            "title": "Усманов Алишер",
            "id": "1"
        },
        {
            "title": "Монро Мэрилин",
            "id": "2"
        },
        {
            "title": "Филькинштейн Евгений",
            "id": "3"
        },
        {
            "title": "Емельяненько Федор",
            "id": "4"
        },
        {
            "title": "Поветкин Александр",
            "id": "5"
        },
        {
            "title": "Липницкая Юлия",
            "id": "6"
        },
        {
            "title": "Джонсон Брайн",
            "id": "7"
        },
    ];

    $rootScope.isActive = function (location) {
        return location === '/#' + $location.path()
    }

    $rootScope.HideUserMenu = function () {
        $('#usermenu').collapse('hide')
        $('#usercontent').addClass('col-md-12').removeClass('col-md-10');
    }
    $rootScope.PlusClick = function () {
        $('#plusbutton').hide();
        $('#addbutton').show();
    }
    $rootScope.UserAdd = function () {
        $('#usermenu').collapse('hide')
        $('#addbutton').hide();
        $('#plusbutton').show();
        $location.path("/main/user/register");
        // console.log($location);
    }
    $rootScope.UserInvite = function () {
        $('#usermenu').collapse('hide')
        $('#addbutton').hide();
        $('#plusbutton').show();
        $location.path("/main/user/invite");
        // console.log($location);
    }


}

