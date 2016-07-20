(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainPersonaIndexController', MainPersonaIndexController);

    MainPersonaIndexController.$inject = ['$scope', '$stateParams', '$http'];

    function MainPersonaIndexController($scope, $stateParams, $http) {
        function getMedia(id) {
            $http.get(`${apiUrl}persons/media/${id}`).success(function (data) {
                $scope.medias = [];
                $scope.medialist = [];
                data.forEach(function (item) {
                    if (item.List.length > 0)
                        $scope.dmedias.push({
                            type: item.List[0].PersonDescriptionType,
                            value: item.List[0].DescriptionText,
                            count: item.Count - 1
                        });
                    $scope.medialist.push(item.List);
                });
            });
        };

        function getDescript(id) {
            $http.get(`${apiUrl}persons/description/${id}`).success(function (data) {
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
        };
        function getConnection(id) {
            $http.get(`${apiUrl}persons/connection/${id}`).success(function (data) {
                $scope.connections = [];
                $scope.connectionList = [];
                data.forEach(function (item) {
                    if (item.List.length > 0)
                        var connection = item.Type > 1 ? {
                            name: item.List[0].PersonConnectionType,
                            descript: item.List[0].Description,
                            value: item.List[0].Event.Name,
                            count: item.Count - 1
                        } : {
                            name: item.List[0].PersonConnectionType,
                            descript: item.List[0].Description,
                            value: `${item.List[0].PersonConnectTo.LastName} ${item.List[0].PersonConnectTo.Name}`,
                            count: item.Count - 1
                        };
                    $scope.connectionList.push.apply($scope.connectionList, item.List);
                    $scope.connections.push(connection);
                });
            });
        };
        function getAntro(id) {
            $http.get(`${apiUrl}persons/antro/${id}`).success(function (data) {
                $scope.antro = [];
                data.forEach(function (item) {
                    $scope.antro.push({ name: item.AntroName, value: item.Value });
                });
            });
        };
        $scope.id = $stateParams.id;
        $scope.persons.forEach(function (item) {
            if (item.Id == $scope.id) {
                $scope.person = item;
                getDescript($scope.id);

                getConnection($scope.id);
                //getMedia($scope.id);
                getAntro($scope.id);
                return;
            }
        });

        $scope.SwitchElements = function () {
            $('.persona-main__container').hide();

            $('.persona-info__full-block').hide();
            $('.persona-info__small-block').show();
        }
    }
})();