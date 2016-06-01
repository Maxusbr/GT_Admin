angular.module('app')
    .controller('userMenuCtrl', userMenuCtrl)
    .directive('userMenu', function () {
        return {
            restrict: 'E',
            templateUrl: '/components/usermenu/usermenu.view.html',
            controller: 'userMenuCtrl'
        };
    })

userMenuCtrl.$inject = ['$rootScope', '$location', '$stateParams'];
function userMenuCtrl($rootScope, $location, $stateParams) {

    $rootScope.searchUserMenu = '';
    $rootScope.id = $stateParams.id;


    $rootScope.usermenu = [
        {
            "title": "Усманов Алишер",
            "id": "1",
            "active": true
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

    // $rootScope.isActive = isActive;
    $rootScope.HideUserMenu = HideUserMenu;
    $rootScope.PlusOver = PlusOver;
    $rootScope.PlusOut = PlusOut;
    $rootScope.UserAdd = UserAdd;
    $rootScope.UserInvite = UserInvite;

    $rootScope.$watch(function () {
        return $location.path()
    }, function (params) {
        console.log(params);
        isActive();
    });


    function isActive(id) {
        /*
         $.each($('#usermenu a'), function(key,val) {
         if (('/#'+$location.path()).indexOf($(val).attr('href'))>=0){
         $rootScope.menu[key].active=true;
         } else {
         $rootScope.menu[key].active=false;
         }
         });
         */
    }

    function HideUserMenu() {
        // $('#usermenu').collapse('hide')
        $('#usermenu').hide();
        $('#usercontent').addClass('col-md-12 col-sm-12').removeClass('col-md-10 col-sm-10');
        $('#addbutton').hide();
        $('#plusbutton').show();
    }

    function PlusOver() {
        $('#plusbutton').hide();
        $('#addbutton').show();
    }

    function PlusOut() {
        $('#plusbutton').show();
        $('#addbutton').hide();
    }

    function UserAdd() {
        // console.log($location);
        // $('#usermenu').collapse('hide')
        $('#usermenu').hide();
        $('#usercontent').addClass('col-md-12 col-sm-12').removeClass('col-md-10 col-sm-10');
        $('#addbutton').hide();
        $('#plusbutton').show();
        $location.path("/main/user/register");
    }

    function UserInvite() {
        // $('#usermenu').collapse('hide')
        $('#usermenu').hide();
        $('#usercontent').addClass('col-md-12 col-sm-12').removeClass('col-md-10 col-sm-10');
        $('#addbutton').hide();
        $('#plusbutton').show();
        $location.path("/main/user/invite");
        // console.log($location);
    }


}

