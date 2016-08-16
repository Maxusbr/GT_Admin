(function () {
    'use strict';

    function PersonInternetController($rootScope, $scope, personService) {
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
        }
        $scope.editLink = function(item) {
            $rootScope.EditedLink = item;
            $rootScope.addInternet();
        }
        $rootScope.addInternet = function() {
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.internet.editor.html', 3200);
        }
        $rootScope.getLinks();
    }

    angular
        .module('app')
        .controller('PersonInternetController', PersonInternetController);

    PersonInternetController.$inject = ['$rootScope', '$scope', 'personService'];
})();