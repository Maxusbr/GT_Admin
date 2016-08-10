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
            $scope.descriptionlist = [];

            data.forEach(function(item) {
                item.List.forEach(function(el) {
                    el.Name = el.DescriptionText.length > 28 ? el.DescriptionText.substr(0, 25) + '...' : el.DescriptionText;
                    if(item.Type === 1)
                        $scope.tizerlist.push(el);
                    if (item.Type === 2)
                        $scope.descriptionlist.push(el);
                });
            });
        }
        var indx = 0;
        var fact = { id: indx++, Tags: [], IdPerson: $scope.id };
        $scope.dimension = "см";
        $scope.factlist = [];
        $scope.factlist.push(fact);
        $scope.existDescription = true;
        function collectLastFact() {
            if (!$scope.antro) return;
            fact.IdAntroName = $scope.antro.Id;
            fact.AntroName = $scope.antro.Name;
            fact.IsMoreThan = $scope.IsMoreThan;
            fact.Value = $scope.FeatureValue;
            fact.dimension = $scope.dimension;
        }


        $scope.tizer = { id_DescriptionType: 1, DescriptionText: "", id_Person: $scope.id };
        personService.getDescript($scope.id, getDescript);

        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });
        $scope.FeatureName = "Антропометрия";
        $scope.loadTags = function (query) {
            var result = $scope.tags.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }
        $scope.showOverwiew = function () {
            $rootScope.tizer = $scope.tizer;
            $rootScope.tizerTags = $scope.TizerTags;
            $rootScope.staticDescription = $scope.staticDescription;
            $rootScope.factlist = $scope.factlist;
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
            personService.saveDescriptions(result, function (data) {
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
        .controller('MainPersonaCreateSchemaController', MainPersonaCreateSchemaController)
        .filter('join', function () {
            return function (arr, glue) {
                if (!Array.isArray(arr)) { return arr; }
                return arr.join(glue);
            };
        });

    MainPersonaCreateSchemaController.$inject = ['$scope', '$rootScope', 'personService', '$location', '$filter'];
})();