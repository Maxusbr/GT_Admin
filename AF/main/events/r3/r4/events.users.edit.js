(function () {
    'use strict';

    function EventsUserCreateController($rootScope, $scope) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = 'Error';
		$scope.saveUser = function () {
            $scope.showMessage = true;
                $timeout(function () {
                    return app.closeView('personFactCreate');
                }, 3000);
            });
        }
    }

    angular
        .module('app')
        .controller('EventsUserCreateController', EventsUserCreateController);

    EventsUserCreateController.$inject = ['$rootScope', '$scope'];
})();