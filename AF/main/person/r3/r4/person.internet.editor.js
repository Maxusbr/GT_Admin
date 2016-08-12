(function () {
    'use strict';

    function PersonInternetEditorController($rootScope) {
        var vm = this;

        $rootScope.editedModel;


        $rootScope.socialtypes = [
            {
                Id: 1,
                Name:'Facebook'
            }
        ];


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
            console.log('save fact click');
            //TODO: save changes or create new
            //close this view
            app.closeMe('personInternetCreate');
            //TODO: refresh facts table
        }
    }

    angular
        .module('app')
        .controller('PersonInternetEditorController', PersonInternetEditorController);

    PersonInternetEditorController.$inject = ['$rootScope'];
})();