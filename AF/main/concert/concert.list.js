(function () {
    'use strict';

    function concertListController($rootScope, $scope, concertService) {
        var vm = this;
        $rootScope.loadConcerts = function () {
            $scope.Promise = concertService.getConcerts(function(data) {
                $rootScope.concerts = data;
                //TODO get change
            });
        }
        $rootScope.loadConcerts();

        $scope.createConcert = function () {
            console.log('create event');
            $rootScope.editedConcert = {IsOneProgramm: true}
            app.closeSecond();
            app.loadContentView('/main/concert/concert.edit.html', 1800);
        }

        $scope.selectConcert = function (id) {
            $rootScope.concertId = id;
            app.closeSecond();
            app.loadContentView('/main/concert/concert.viewone.html', 1800);
        }
    }

    angular
        .module('app')
        .controller('concertListController', concertListController);

    concertListController.$inject = ['$rootScope', '$scope', 'concertService'];
})();