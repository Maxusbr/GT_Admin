(function () {
    'use strict';

    function PersonInternetEditorController($rootScope, $scope, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

        //редактируемая запись
        $rootScope.editedModel = $rootScope.EditedLink ? $rootScope.EditedLink : { IdDestination: 1, Link: "", Description: "" };

        //типы источников ссылок

        $rootScope.getLinkTypes = function () {
            console.log('get link types');
            personService.getLinkTypes(function (data) {
                $rootScope.socialtypes = [];
                $rootScope.socialtypes.push.apply($rootScope.socialtypes, data);
            });
        }
        $rootScope.getLinkTypes();

        $rootScope.saveInternet = function () {
            console.log('save link click');

            var list = [$rootScope.editedModel];
            personService.saveEntities($rootScope.personId, list, 'social', $rootScope.getLinks, function (data) {
                $scope.errorYes = data.status !== "success";
                $scope.message = data.result;
                $scope.showMessage = true;
                $rootScope.getPersonCounts();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return $rootScope.closeMe('personInternetCreate');
                    }, timeoutMsgShow);
            });
            //close this view

        }

        $rootScope.displayLinkTypes = function display_link_types() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.links.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('PersonInternetEditorController', PersonInternetEditorController);

    PersonInternetEditorController.$inject = ['$rootScope', '$scope', 'personService', '$timeout'];
})();