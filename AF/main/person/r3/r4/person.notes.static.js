(function () {
    'use strict';

    function personNotesStaticController($rootScope, $cookieStore, $scope, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        $scope.staticDescription = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc.StaticDescription :
            $rootScope.editableDesc;
        $scope.tizerId = $rootScope.editableDesc.id_DescriptionType === 1 ? $rootScope.editableDesc.Id : 0;

        $scope.savePersonNotesStatic = function () {

            $scope.staticDescription.id_Person = $rootScope.personId;
            $scope.staticDescription.id_DescriptionType = 2;
            personService.saveEntity($scope.tizerId, $scope.staticDescription, 'description', function (data) {
                $rootScope.getDescript();
                app.closeView('disPersonNotesStatic');
            });
        }
    }

    angular
        .module('app')
        .controller('personNotesStaticController', personNotesStaticController);

    personNotesStaticController.$inject = ['$rootScope', '$cookieStore', '$scope', 'personService'];
})();