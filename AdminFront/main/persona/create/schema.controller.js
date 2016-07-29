(function () {
    'use strict';

    function MainPersonaCreateSchemaController($scope, $rootScope, personService, $location, $filter) {
        var vm = this;
        if (!$rootScope.person) {
            $location.path("/main/persona/create");
            return;
        }
        $scope.id = $rootScope.person.Id;
        function getDescript(data) {
            $scope.tizerlist = [];
            var item = $filter('filter')(data, { Type: 1 })[0];
            if (item != undefined) {
                item.List.forEach(function(el) {
                    el.Name = el.DescriptionText.length > 28 ? el.DescriptionText.substr(0, 25) + '...' : el.DescriptionText;
                    $scope.tizerlist.push(el);
                });
            }
            //data.forEach(function (item) {
            //    if (item.List.length > 0)
            //        $scope.descriptions.push({
            //            type: item.List[0].PersonDescriptionType,
            //            value: item.List[0].DescriptionText,
            //            count: item.Count - 1
            //        });
            //    $scope.descriptionlist.push.apply($scope.descriptionlist, item.List);
            //});
        }

        personService.getDescript($scope.id, getDescript);

        $scope.showOverwiew = function () {
            $rootScope.tizer = $scope.tizer;
            $rootScope.staticDescription = $scope.staticDescription;
            $location.path("/main/persona/create/overview");
        }

    }

    
    angular
        .module('app')
        .controller('MainPersonaCreateSchemaController', MainPersonaCreateSchemaController);

    MainPersonaCreateSchemaController.$inject = ['$scope', '$rootScope', 'personService', '$location', '$filter'];
})();