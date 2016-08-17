(function () {
    'use strict';

    function UserStatisticController($rootScope, $scope, personService) {
        var vm = this;

        $rootScope.addStatistic = function addStatistic(){
            app.closeFour();
            app.loadContentView('/main/user/r3/r4/user.statistic.create.html', 3200);
        }
        $rootScope.editStatistic = function editStatistic(){
            app.closeFour();
            app.loadContentView('/main/user/r3/r4/user.statistic.editor.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('UserStatisticController', UserStatisticController);

    UserStatisticController.$inject = ['$rootScope', '$scope', 'personService'];
})();