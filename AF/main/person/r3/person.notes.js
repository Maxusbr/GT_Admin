(function () {
    'use strict';

    function personNotesController($rootScope, $cookieStore, $scope, personService) {
        var vm = this;
        if (!$rootScope.UserName)
            $rootScope.UserName = $cookieStore.get('username');

        personService.getFact($rootScope.personId, function (data) {
            $scope.descriptions = [];
            $scope.descriptionlist = [];
            data.forEach(function (item) {
                if (item.List.length > 0)
                    $scope.descriptions.push({
                        type: item.List[0].PersonDescriptionType,
                        value: item.List[0].DescriptionText,
                        count: item.Count - 1
                    });
                $scope.descriptionlist.push.apply($scope.descriptionlist, item.List);
            });
        });

        $rootScope.displaySource = function display_source() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.source.html', 3200);
        }

        $rootScope.displayNotesStatic = function display_source() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.notes.static.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('personNotesController', personNotesController);

    personNotesController.$inject = ['$rootScope', '$cookieStore', '$scope', 'personService'];
})();