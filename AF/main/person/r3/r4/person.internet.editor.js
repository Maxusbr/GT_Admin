(function () {
    'use strict';

    function PersonInternetEditorController($rootScope, $scope, personService) {
        var vm = this;
        //назначения ссылок
        $scope.destinationtypes = [
            {
                Id: 1,
                Name: 'Публичная ссылка'
            },
            {
                Id: 2,
                Name: 'Для внутреннего использования'
            }
        ];
        //редактируемая запись
        $rootScope.editedModel = $rootScope.EditedLink ? $rootScope.EditedLink : {IdDestination: 1};

        //типы источников ссылок
        personService.getLinkTypes(function (data) {
            $scope.socialtypes = [];
            $scope.socialtypes.push.apply($scope.socialtypes, data);
        });

        

        $rootScope.saveInternet = function save_fact() {
            console.log('save link click');
            //TODO: save changes or create new
            //close this view
            app.closeMe('personInternetCreate');
            //TODO: refresh facts table
        }

        $rootScope.displayLinkTypes = function display_link_types() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.person.links.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('PersonInternetEditorController', PersonInternetEditorController);

    PersonInternetEditorController.$inject = ['$rootScope', '$scope', 'personService'];
})();