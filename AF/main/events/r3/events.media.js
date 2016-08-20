(function () {
    'use strict';

    function EventsMediaController($rootScope, $scope, personService, eventService) {
        var vm = this;
        $rootScope.getMedias = function() {
            $scope.Promise = eventService.getMedia($rootScope.eventId, function (data) {
                $scope.medialist = [];
                data.forEach(function (item) {
                    $scope.medialist.push.apply($scope.medialist, item.List);
                });
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

    EventsMediaController.$inject = ['$rootScope', '$scope', 'personService', 'eventService'];
})();