﻿(function () {
    'use strict';

    function PersonMediaController($rootScope, $scope, personService, $q) {
        var vm = this;
        $rootScope.getMedias = function () {
            $scope.Promise = personService.getMedia($rootScope.personId, function (data) {
                $scope.medias = [];
                $scope.medialist = [];

                var deferred = $q.defer();
                var promise = deferred.promise;
                promise.then(function () {
                    data.forEach(function (item) {
                        if (item.List.length > 0)
                            $scope.medias.push({
                                type: item.List[0].MediaType,
                                value: item.List[0].MediaLink,
                                count: item.Count - 1
                            });
                        $scope.medialist.push.apply($scope.medialist, item.List);
                    });
                }).then(function () {
                    $scope.medialist.forEach(function (item) {
                        if (item.LastChange)
                            item.LastChange.localdate = new Date(item.LastChange.Date);
                    });
                });
                deferred.resolve();
            });
        }
        $rootScope.getMedias();

        $rootScope.editMedia = function (item) {
            $rootScope.editedMedia = item;
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.media.editor.html', 3200);
        }
        $rootScope.addMedia = function add_media() {
            $rootScope.editedMedia = { Id: 0, id_MediaType: 2, Tags: [], id_Person: $rootScope.personId, LastChange: null, Name: null, Description: null, MediaType: null }
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/person.media.editor.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('PersonMediaController', PersonMediaController);

    PersonMediaController.$inject = ['$rootScope', '$scope', 'personService', '$q'];
})();