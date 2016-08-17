(function () {
    'use strict';

    function PersonMediaController($rootScope, $scope, personService) {
        var vm = this;

        personService.getMedia($rootScope.personId, function (data) {
            $scope.medias = [];
            $scope.medialist = [];
            data.forEach(function (item) {
                if (item.List.length > 0)
                    $scope.medias.push({
                        type: item.List[0].MediaType,
                        value: item.List[0].MediaLink,
                        count: item.Count - 1
                    });
                $scope.medialist.push.apply($scope.medialist, item.List);
            });
        });

        $rootScope.editMedia = function edit_media() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.media.editor.html', 3200)
        }
        $rootScope.addMedia = function add_media() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.media.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('PersonMediaController', PersonMediaController);

    PersonMediaController.$inject = ['$rootScope', '$scope', 'personService'];
})();