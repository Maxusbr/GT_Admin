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
        }
        var indx = 0;
        var fact = { id: indx++, Tags: [], IdPerson: $scope.id };
        $scope.factlist = [];
        $scope.factlist.push(fact);
        $scope.existDescription = true;
        function collectLastFact() {
            fact.IdAntroName = $scope.IdAntroName;
            fact.IsMoreThan = $scope.IsMoreThan;
            fact.Value = $scope.FeatureValue;
        }


        $scope.tizer = { id_DescriptionType: 1, DescriptionText: "", id_Person: $scope.id};
        personService.getDescript($scope.id, getDescript);

        personService.getTags(function(data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });
        $scope.FeatureName = "Антропометрия";
        $scope.loadTags = function (query) {
            return $scope.tags.filter(function(item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
        }
        $scope.showOverwiew = function () {
            $rootScope.tizer = $scope.tizer;
            $rootScope.staticDescription = $scope.staticDescription;
            collectLastFact();
            var result = {
                IdPerson: $scope.id,
                TagDescription: {
                    Tizer: $scope.tizer,
                    Tags: $scope.TizerTags,
                    ExistDescription: !$scope.existDescription,
                    StaticDescription: $scope.staticDescription
                },
                TagAntroList: $scope.factlist
        }

            personService.saveDescriptions(result, function(data) {
                if (data.Message)
                    $scope.response = data.Message;
                else {
                    $location.path("/main/persona/create/overview");
                }
            });
        }

    }

    
    angular
        .module('app')
        .controller('MainPersonaCreateSchemaController', MainPersonaCreateSchemaController);

    MainPersonaCreateSchemaController.$inject = ['$scope', '$rootScope', 'personService', '$location', '$filter'];
})();