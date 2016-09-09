(function () {
    'use strict';

    function PersonInternetController($rootScope, $scope, personService, $q) {
        var vm = this;
        //назначения ссылок
        $rootScope.destinationtypes = [
            {
                Id: 0,
                Name: 'Публичная ссылка'
            },
            {
                Id: 1,
                Name: 'Для внутреннего использования'
            }
        ];
        $rootScope.getLinks = function () {
            console.log('load links');
            personService.getLinks($rootScope.personId, function (data) {
                $scope.links = [];
                $scope.linklist = [];

                var deferred = $q.defer();
                var promise = deferred.promise;
                promise.then(function () {
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
                }).then(function () {
                    $scope.linklist.forEach(function (item) {
                        if (item.LastChange)
                            item.LastChange.localdate = new Date(item.LastChange.Date);
                    });
                });
                deferred.resolve();

            });
        }
        $scope.getDestination = function (id) {
            return $rootScope.destinationtypes.filter(function (item) { return item.Id === id; })[0].Name;
        }
        $rootScope.addInternet = function (item) {
            $rootScope.EditedLink = item;
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.internet.editor.html', 3200);
        }
        $rootScope.getLinks();
    }

    angular
        .module('app')
        .controller('PersonInternetController', PersonInternetController);

    PersonInternetController.$inject = ['$rootScope', '$scope', 'personService', '$q'];
})();