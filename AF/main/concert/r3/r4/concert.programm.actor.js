(function () {
    'use strict';

    function concertProgrammActorController($rootScope, $scope, concertService, personService) {
        var vm = this;
        $scope.actor = $rootScope.editedActor;
        if (!$rootScope.persons)
            $scope.Promise = personService.getPersons();

        $scope.editActorGroup = function () {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.concert.actorgroup.html', 3200);
        }

        $scope.saveActor = function () {
            if ($rootScope.AddActor)
                $rootScope.AddActor($scope.actor);
        }
    }

    angular
        .module('app')
        .controller('concertProgrammActorController', concertProgrammActorController);

    concertProgrammActorController.$inject = ['$rootScope', '$scope', 'concertService', 'personService'];
})();