(function () {
    'use strict';


    angular
        .module('app')
        .controller('MainUserProfileController', MainUserProfileController);

    MainUserProfileController.$inject = ['$rootScope', '$stateParams', '$filter'];
    function MainUserProfileController($rootScope, $stateParams, $filter) {
        var vm = this;

        $rootScope.users = [
            {
                "name": "Усманов Алишер",
                "id": "1"
            },
            {
                "name": "Монро Мэрилин",
                "id": "2"
            },
            {
                "name": "Филькинштейн Евгений",
                "id": "3"
            },
            {
                "name": "Емельяненько Федор",
                "id": "4"
            },
            {
                "name": "Поветкин Александр",
                "id": "5"
            },
            {
                "name": "Липницкая Юлия",
                "id": "6"
            },
            {
                "name": "Джонсон Брайн",
                "id": "7"
            },
        ];
        var filtered = $filter('filter')($rootScope.users, {id: $stateParams.id});
        $rootScope.person = filtered.length ? filtered[0] : null;

        // $rootScope.person = $rootScope.users[$stateParams.id];
    }

})();
