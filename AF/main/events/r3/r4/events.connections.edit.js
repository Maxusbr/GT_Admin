(function () {
    'use strict';

    function EventsConnectionsCreateController($rootScope) {
        var vm = this;

        //редактируемая запись
        $rootScope.editedModel;

        //типы источников ссылок
        $rootScope.socialtypes = [
            {
                Id: 1,
                Name:'Facebook'
            }
        ];

        //назначения ссылок
        $rootScope.destinationtypes = [
            {
                Id: 1,
                Name: 'Публичная ссылка'
            },
            {
                Id: 2,
                Name: 'Для внутреннего использования'
            }
        ];

        $rootScope.saveInternet = function save_fact() {
            console.log('save link click');
            //TODO: save changes or create new
            //close this view
            app.closeMe('personInternetCreate');
            //TODO: refresh facts table
        }

        $rootScope.displayLinkTypes = function display_link_types() {
            app.loadContentView('/main/dictionary/dictionary.person.links.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('EventsConnectionsCreateController', EventsConnectionsCreateController);

    PersonInternetEditorController.$inject = ['$rootScope'];
})();