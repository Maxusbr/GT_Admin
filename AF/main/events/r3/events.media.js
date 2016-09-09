(function () {
    'use strict';

    function EventsMediaController($rootScope, $scope, personService, eventService, $q) {
        var vm = this;
        $rootScope.getMedias = function() {
            $scope.Promise = eventService.getMedia($rootScope.eventId, function (data) {
                $scope.medialist = [];
                
                var deferred = $q.defer();
                var promise = deferred.promise;
                promise.then(function () {
                    data.forEach(function (item) {
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

        $rootScope.addMedia = function (item) {
            $rootScope.editedMedia = item ? item : {};
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.media.edit.html', 3200);
        }

        if (!$rootScope.persons)
            personService.getPersons();
    }

    angular
        .module('app')
        .controller('EventsMediaController', EventsMediaController);

    EventsMediaController.$inject = ['$rootScope', '$scope', 'personService', 'eventService', '$q'];
})();