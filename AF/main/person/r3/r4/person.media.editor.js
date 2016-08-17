(function () {
    'use strict';

    function PersonMediaEditController($rootScope, $scope, Upload) {
        var vm = this;
        $scope.file = $rootScope.editedMedia.MediaLink;
        $scope.upload = function (file) {
            Upload.upload({
                url: `${serviceUrl}persons/upload/image`,
                data: { file: file}
            }).then(function (resp) {
                console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
            }, function (resp) {
                console.log('Error status: ' + resp.status);
            }, function (evt) {
                var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
            });
        };
        $scope.saveMedia = function() {
            Upload.upload({
                url: `${serviceUrl}persons/upload/image`,
                data: { file: file }
            }).then(function (resp) {
                console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
            }, function (resp) {
                console.log('Error status: ' + resp.status);
            }, function (evt) {
                var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
            });
        }
    }

    angular
        .module('app')
        .controller('PersonMediaEditController', PersonMediaEditController);

    PersonMediaEditController.$inject = ['$rootScope', '$scope', 'Upload'];
})();