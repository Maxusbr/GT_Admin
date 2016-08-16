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
        $rootScope.editedModel = $rootScope.EditedLink ? $rootScope.EditedLink : { IdDestination: 1, Link: "", Description: ""};

        //типы источников ссылок
        
        $rootScope.getLinkTypes = function () {
            console.log('get link types');
            personService.getLinkTypes(function (data) {
                $rootScope.socialtypes = [];
                $rootScope.socialtypes.push.apply($rootScope.socialtypes, data);
            });
        }
        $rootScope.getLinkTypes();

        $rootScope.saveInternet = function() {
            console.log('save link click');
            //TODO: save changes or create new
            var list = [$rootScope.editedModel];
            personService.saveEntities($rootScope.personId, list, 'social', $rootScope.getLinks);
            //close this view
            $rootScope.closeMe('personInternetCreate');
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