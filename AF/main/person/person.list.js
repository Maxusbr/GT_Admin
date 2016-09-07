(function () {
    'use strict';

    angular
        .module('app')
        .controller('PersonListController', PersonListController);

    PersonListController.$inject = ['$rootScope', '$scope', 'personService', '$interval'];
    function PersonListController($rootScope, $scope, personService, $interval) {
        var vm = this;
        $scope.Promise = personService.getPersons();
        
        $rootScope.createPreson = function create_person() {
            console.log('create person');
            app.closeSecond();
            app.loadContentView('/main/person/person.create.html', 1800);
        }

        $scope.selectPerson = function (id) {
            $rootScope.personId = id;
            app.closeSecond();
            app.loadContentView('/main/person/person.viewone.html', 1800);
        }
        $scope.order = '';
        $scope.rever = false;
        $scope.arrows = [false,false,false,false,false];
        $scope.arrowId = ['name.lastName','name.firstName','name.middleName','type','event'];
        $scope.orders = function(name) {
            if (name == $scope.order) {
                if (!$scope.rever) {
                    $scope.order = name;    
                }
                else { $scope.order = '-' + name; }
                $scope.rever = !$scope.rever;
            }
            else {
                $scope.order = name;
                $scope.rever = true;
            }

            function arrowTrue(element, index, array) {
                if ((element == name)&&(!$scope.rever)) $scope.arrows[index] = true;
                else $scope.arrows[index] = false;
            }

            $scope.arrowId.forEach(arrowTrue);
           
        }
    }
})();