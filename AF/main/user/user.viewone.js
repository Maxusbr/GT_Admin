(function () {
    'use strict';

   
    function UserViewoneController($rootScope, $scope, userService) {
        var vm = this;

        $rootScope.displayStatistic = function () {
            app.closeThird();
            app.loadContentView('/main/user/r3/user.statistic.html', 2500);
        }
        $rootScope.displayMessege = function () {
            app.closeThird();
            app.loadContentView('/main/user/r3/user.message.html', 2500);
        }
        $rootScope.displayEntry = function () {
            app.closeThird();
            app.loadContentView('/main/user/r3/user.entry.html', 2500);
        }
        // $rootScope.displayConnections = function display_connections() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.connections.html', 2500);
        // }
        // $rootScope.displayUser = function display_internet() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.users.html', 2500);
        // }
        // $rootScope.displayAntro = function display_antro() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.antro.html', 2500);
        // }

        //перепилить для user
        $scope.Id = $rootScope.userId;
        $scope.counts = { Statistic: 0, Messages: 0, Logins: 0}
        $scope.Promise = userService.getUser($scope.Id, function (data) {
            $scope.user = data;
            //userService.getCountes($rootScope.userId, function (counts) {
            //    $scope.counts = counts;
            //});
        });
        //
        
        $rootScope.editUser = function () {
            app.closeThird();
            app.loadContentView('/main/user/user.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('UserViewoneController', UserViewoneController);

    UserViewoneController.$inject = ['$rootScope', '$scope', 'userService'];
    
})();