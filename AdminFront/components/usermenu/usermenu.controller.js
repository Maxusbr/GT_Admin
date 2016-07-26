angular.module('app')
    .controller('userMenuCtrl', userMenuCtrl)
    .directive('userMenu', function () {
        return {
            restrict: 'E',
            templateUrl: '/components/usermenu/usermenu.view.html',
            controller: 'userMenuCtrl'
        };
    });

userMenuCtrl.$inject = ['$rootScope', '$scope', '$location', '$stateParams', '$filter'];
function userMenuCtrl($rootScope, $scope, $location, $stateParams, $filter) {

    $scope.searchUserMenu = '';
    $rootScope.id = $stateParams.id;

    $scope.Hide = function () {
        $('.custom-menu__fixed_button').hide();
    };

    $scope.Show = function () {
        $('.custom-menu__fixed_button').show();
    };

    //$scope.userMenuList = [
    //    {
    //        "title": "Усманов Алишер",
    //        "id": "1",
    //        "active": true
    //    },
    //    {
    //        "title": "Монро Мэрилин",
    //        "id": "2"
    //    },
    //    {
    //        "title": "Филькинштейн Евгений",
    //        "id": "3"
    //    },
    //    {
    //        "title": "Емельяненько Федор",
    //        "id": "4"
    //    },
    //    {
    //        "title": "Поветкин Александр",
    //        "id": "5"
    //    },
    //    {
    //        "title": "Липницкая Юлия",
    //        "id": "6"
    //    },
    //    {
    //        "title": "Джонсон Брайн",
    //        "id": "7"
    //    },
    //    {
    //        "title": "Емельяненько Федор",
    //        "id": "4"
    //    },
    //    {
    //        "title": "Поветкин Александр",
    //        "id": "5"
    //    },
    //    {
    //        "title": "Липницкая Юлия",
    //        "id": "6"
    //    },
    //    {
    //        "title": "Джонсон Брайн",
    //        "id": "7"
    //    },
    //    {
    //        "title": "Емельяненько Федор",
    //        "id": "4"
    //    },
    //    {
    //        "title": "Поветкин Александр",
    //        "id": "5"
    //    },
    //    {
    //        "title": "Липницкая Юлия",
    //        "id": "6"
    //    },
    //    {
    //        "title": "Джонсон Брайн",
    //        "id": "7"
    //    },
    //    {
    //        "title": "Емельяненько Федор",
    //        "id": "4"
    //    },
    //    {
    //        "title": "Поветкин Александр",
    //        "id": "5"
    //    },
    //    {
    //        "title": "Липницкая Юлия",
    //        "id": "6"
    //    },
    //    {
    //        "title": "Джонсон Брайн",
    //        "id": "7"
    //    },
    //    {
    //        "title": "Емельяненько Федор",
    //        "id": "4"
    //    },
    //    {
    //        "title": "Поветкин Александр",
    //        "id": "5"
    //    },
    //    {
    //        "title": "Липницкая Юлия",
    //        "id": "6"
    //    },
    //    {
    //        "title": "Джонсон Брайн",
    //        "id": "7"
    //    }
    //];
    $rootScope.$watch('userMenuList', function (params) {
        if (!$rootScope.userMenuList) return;
        var filtered = $filter('filter')($rootScope.userMenuList, { id: $stateParams.id });
        if(filtered.length)
            filtered[0].active = true;
    });

    $scope.UserAdd = UserAdd;
    $scope.UserInvite = UserInvite;

    function UserAdd() {
        $location.path("/main/user/register");
    }

    function UserInvite() {
        $location.path("/main/user/invite");
    }


}

