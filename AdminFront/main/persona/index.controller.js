(function () {
    'use strict';

    var app = angular
        .module('app')
        .controller('MainPersonaIndexController', MainPersonaIndexController);

    MainPersonaIndexController.$inject = ['$scope', '$stateParams', '$http', '$rootScope'];

    function MainPersonaIndexController($scope, $stateParams, $http, $rootScope) {
        function clearValues() {
            $scope.links = [];
            $scope.linklist = [];
            $scope.medias = [];
            $scope.medialist = [];
            $scope.descriptions = [];
            $scope.descriptionlist = [];
            $scope.facts = [];
            $scope.factlist = [];
            $scope.connections = [];
            $scope.connectionList = [];
            $scope.antro = [];
        };

        function getLinks(id) {
            $http.get(`${apiUrl}persons/social/${id}`).success(function (data) {
                data.forEach(function (item) {
                    if (item.List.length > 0)
                        $scope.links.push({
                            type: item.List[0].PersonSocialLinkType,
                            value: item.List[0].Link,
                            descript: item.List[0].Description,
                            count: item.Count - 1
                        });
                    $scope.linklist.push.apply($scope.linklist, item.List);
                });
            });
        };
        function getMedia(id) {
            $http.get(`${apiUrl}persons/media/${id}`).success(function (data) {
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
        };
        function getDescript(id) {
            $http.get(`${apiUrl}persons/description/${id}`).success(function (data) {
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
        function getFact(id) {
            $http.get(`${apiUrl}persons/fact/${id}`).success(function (data) {
                data.forEach(function (item) {
                    //if (item.List.length > 0)
                    //    $scope.facts.push({
                    //        type: item.List[0].FactType,
                    //        value: item.List[0].FactText,
                    //        count: item.Count - 1
                    //    });
                    $scope.factlist.push.apply($scope.factlist, item.List);
                });
            });
        };
        function getConnection(id) {
            $http.get(`${apiUrl}persons/connection/${id}`).success(function (data) {
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
                data.forEach(function (item) {
                    $scope.antro.push({ name: item.AntroName, value: item.Value });
                });
            });
        };

        function getYearText(age) {
            var year = age;
            while (year > 10) {
                year = year % 10;
            }
            if (year === 1) {
                return "год";
            }
            else {
                if (year > 1 && year < 5) {
                    return "года";
                }
                else {
                    return "лет";
                }
            }
        }
        $scope.id = $stateParams.id;
        if ($rootScope.persons !== undefined)
            $rootScope.persons.forEach(function (item) {
                if (item.Id == $scope.id) {
                    $scope.person = item;
                    $scope.yearText = getYearText(item.Age);
                    clearValues();
                    getDescript($scope.id);
                    getFact($scope.id);
                    getConnection($scope.id);
                    getMedia($scope.id);
                    getLinks($scope.id);
                    getAntro($scope.id);
                    return;
                }
            });
        else {
            $http({
                url: `${apiUrl}persons/${pageNumber}/${pageSize}`,
                method: "POST",
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }).success(function (data) {
                $rootScope.persons = data;
                $rootScope.persons.forEach(function (item) {
                    $scope.menuScope.push({
                        id: item.Id,
                        name: item.Name + ' ' + item.LastName,
                        type: item.EventType,
                        event: item.EventName
                    });
                });
            });
        }

        $scope.SwitchElements = function () {
            $('.persona-main__container').hide();

            $('.persona-info__full-block').hide();
            $('.persona-info__small-block').show();
        }
    }
})();