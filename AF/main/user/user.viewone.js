(function () {
    'use strict';

   
    function UserViewoneController($rootScope, $scope, personService) {
        var vm = this;

        $rootScope.displayStatistic = function display_statistic() {
            app.closeThird();
            app.loadContentView('/main/user/r3/user.statistic.html', 2500);
        }
        $rootScope.displayMessege = function display_messege() {
            app.closeThird();
            app.loadContentView('/main/user/r3/user.message.html', 2500);
        }
        $rootScope.displayEntry = function display_entry() {
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
        $scope.Id = $rootScope.eventId;
        $scope.counts = { CountDescriptions: 0, CountFacts: 0, CountConnects: 0, CountMedias: 0, CountLinks: 0, CountAntros: 0 }
        $scope.Promise = personService.getPerson($scope.Id, function (data) {
            $scope.person = data;
            personService.getCountes($scope.Id, function (counts) {
                $scope.counts = counts;
            });
        });
        //
        
        $rootScope.editUser = function edit_user() {
            app.closeThird();
            app.loadContentView('/main/user/user.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('UserViewoneController', UserViewoneController);

    UserViewoneController.$inject = ['$rootScope', '$scope', 'personService'];
    
})();