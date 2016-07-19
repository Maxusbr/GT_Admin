(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaIndexController', MainPersonaIndexController);

    MainPersonaIndexController.$inject = ['$scope', '$stateParams'];

    function MainPersonaIndexController($scope, $stateParams) {
        $scope.id = $stateParams.id;

        $scope.SwitchElements = function () {
            $('.persona-main__container').hide();

            $('.persona-info__full-block').hide();
            $('.persona-info__small-block').show();
        }
    }
})();