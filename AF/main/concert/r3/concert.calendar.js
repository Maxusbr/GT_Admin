(function () {
    'use strict';

    function concertCalendarController($rootScope, $scope, concertService, $q) {
        var vm = this;
        $scope.concert = $rootScope.editedConcert;
        $scope.weekDay = 1;
        function sharpDate(date) {
            if (!date) return null;
            return `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
        }
        $scope.weekDays = [
            { Id: 1, Name: 'Понедельник' }, { Id: 2, Name: 'Вторник' },
            { Id: 3, Name: 'Среда' }, { Id: 4, Name: 'Четверг' }, { Id: 5, Name: 'Пятница' },
            { Id: 6, Name: 'Суббота' }, { Id: 0, Name: 'Воскресенье' }
        ];
        $scope.$watch('oneSchedule', function (data) {
            if (!data || !data.DateStart || !data.TimeStart) return;
            data.timeStart = new Date(data.DateStart);
            var times = data.TimeStart.split(':');
            data.timeStart.setHours(times[0], times[1]);
        });

        $scope.changeRepeat = function () {
            $scope.calendar.IsRepeated = !$scope.calendar.IsRepeated;
            $scope.dateStart = new Date($scope.calendar.DateStart);
            $scope.schedule = undefined;
            $scope.weekSchedule = undefined;
        }
        $scope.getCalendar = function () {
            concertService.getSchedules($scope.concert.Id, function (data) {
                $scope.calendar = data ? data : { IsRepeated: false, DateStart: new Date() };
                if ($scope.calendar.DateStart)
                    $scope.dateStart = new Date($scope.calendar.DateStart);
                else {
                    $scope.dateStart = new Date();
                    $scope.calendar.DateStart = sharpDate($scope.dateStart);
                }
                $scope.dateEnd = $scope.calendar.DateEnd ? new Date($scope.calendar.DateEnd) : $scope.dateStart;

                $scope.weekSchedules = $scope.calendar.WeekSchedules ? $scope.calendar.WeekSchedules : [];
                $scope.rangeSchedules = $scope.calendar.RangeSchedules ? $scope.calendar.RangeSchedules : [];
                $scope.previewWeek = $scope.calendar.PreviewWeek;
                $scope.previewRange = $scope.calendar.PreviewRange;
                $scope.oneSchedule = $scope.calendar.OneSchedule;
            });
        }
        $scope.getCalendar();

        // Time & Date convertion
        $scope.$watch('dateStart', function (date) {
            if (!date) return;
            if (date > $scope.dateEnd)
                $scope.dateEnd = date;
            if (!$scope.timeStart) return;
            var dt = $scope.timeStart;
            $scope.timeStart = date;
            $scope.timeStart.setHours(dt.getHours(), dt.getMinutes());
        });
        $scope.$watch('dateEnd', function (date) {
            if (!date) return;
            if (date < $scope.dateEnd)
                $scope.dateStart = date;
            if (!$scope.timeEnd) return;
            var dt = $scope.timeEnd;
            $scope.timeEnd = date;
            $scope.timeEnd.setHours(dt.getHours(), dt.getMinutes());
        });
        $scope.$watch('timeStart', function (date) {
            if (!date) return;
            if (date > $scope.timeEnd)
                $scope.timeEnd = date;
        });
        $scope.$watch('timeEnd', function (date) {
            if (!date) return;
            if (date < $scope.timeStart)
                $scope.timeStart = date;
        });

        $scope.selectWeekSchedule = function () {
            $scope.schedule = undefined;
            $scope.weekSchedule = $scope.weekSchedules ? $scope.weekSchedules : [];
            var weekDayStart = new Date();
            var weekDayEnd = new Date();
            if ($scope.weekSchedule.length) {
                weekDayStart = $scope.weekSchedule.sort(function (d1, d2) {
                    var dt1 = new Date(d1.DateStart);
                    var dt2 = new Date(d2.DateStart);
                    return (dt2 - dt1);
                })[0].DateStart;
                weekDayEnd = $scope.weekSchedule.sort(function (d1, d2) {
                    var dt1 = new Date(d1.DateEnd);
                    var dt2 = new Date(d2.DateEnd);
                    return (dt2 - dt1);
                })[$scope.weekSchedule.length - 1].DateEnd;
            }

            $scope.weekDayStart = new Date(weekDayStart);
            $scope.weekDayEnd = new Date(weekDayEnd);
        }
        $scope.selectSchedule = function (item) {
            $scope.weekSchedule = undefined;
            if (!$scope.rangeSchedules || !item) {
                $scope.schedule = { dateStart: new Date(), dateEnd: undefined };
                $scope.changeOneDay();
                return;
            }

            var schedule = $scope.rangeSchedules.filter(function (el) {
                return el.DateRange === item.Dates;
            })[0];
            $scope.schedule = schedule ? schedule : {};
            if ($scope.schedule.DateStart)
                $scope.schedule.dateStart = new Date($scope.schedule.DateStart);
            if ($scope.schedule.DateEnd)
                $scope.schedule.dateEnd = new Date($scope.schedule.DateEnd);
            var time = $scope.schedule.DateStart;

        }
        $scope.getTime = function (item) {
            var times = item.TimeStart.split(':');
            return `${times[0]}:${times[1]}`;
        }
        function getTimeSpan(date) {
            var h = date.getHours();
            var m = date.getMinutes();
            return (h < 10 ? '0' : '') + h + ':' + (m < 10 ? '0' : '') + m;
        }
        $scope.addTimeWeek = function () {
            if (!$scope.timeStartWeek) return;
            var time = getTimeSpan($scope.timeStartWeek);
            var res = $scope.weekSchedule.filter(function (item) {
                var dt = $scope.getTime(item);
                return time === dt;
            })[0];
            if (!res)
                $scope.weekSchedule.push({
                    TimeStart: time,
                    WeekDays: [$scope.weekDay],
                    DateStart: sharpDate($scope.weekDayStart),
                    DateEnd: sharpDate($scope.weekDayEnd)
                });
            else {
                var day = res.WeekDays.filter(function (item) {
                    return item === $scope.weekDay;
                })[0];
                if (!day)
                    res.WeekDays.push($scope.weekDay);
            }
            $scope.previewWeek = [];
            concertService.getScheduleWeekPreviews($scope.weekSchedule, function (data) {
                $scope.previewWeek = data;
            });
        }
        function getName(weekDay) {
            switch (weekDay) {
                case 1:
                    return 'Пн';
                case 2:
                    return 'Вт';
                case 3:
                    return 'Ср';
                case 4:
                    return 'Чт';
                case 5:
                    return 'Пт';
                case 6:
                    return 'Сб';
                default: return 'Вс';
            }
        };

        $scope.clearWeek = function () {
            var dayName = getName($scope.weekDay);
            $scope.previewWeek.forEach(function (item) {
                var indx = item.Range.indexOf(dayName);
                if (indx >= 0)
                    item.Range.splice(indx, 1);
            });
            $scope.weekSchedules.forEach(function (item) {
                var indx = item.WeekDays.indexOf($scope.weekDay);
                if (indx >= 0)
                    item.WeekDays.splice(indx, 1);
            });
        }
        function getstrDate(date) {
            var d = date.getDate();
            var m = date.getMonth() + 1;
            var y = date.getFullYear();
            return `${d < 10 ? '0' + d : d}.${m < 10 ? '0' + m : m}.${y}`;
        };


        $scope.changeOneDay = function (date) {
            $scope.schedule.dateEnd = date;
            $scope.schedule.DateRange = getstrDate($scope.schedule.dateStart) + ($scope.schedule.dateEnd ? `-${getstrDate($scope.schedule.dateEnd)}` : '');
            if (!$scope.addedTime) {
                $scope.addedTime = $scope.schedule.dateStart;
                $scope.addedTime.setHours(0, 0);
            }
        }
        $scope.$watch('schedule.dateEnd', function (date) {
            if (!$scope.schedule || !$scope.schedule.dateStart) return;
            $scope.schedule.DateRange = getstrDate($scope.schedule.dateStart) + (date ? `-${getstrDate(date)}` : '');
            $scope.schedule.DateEnd = sharpDate(date);
        });
        $scope.addToRange = function () {
            if (!$scope.addedTime) return;
            var tm = getTimeSpan($scope.addedTime);
            var sched = $scope.schedule;
            var range = getstrDate(sched.dateStart) + (sched.dateEnd ? `-${getstrDate(sched.dateEnd)}` : '');
            var found = $scope.rangeSchedules.filter(function (item) {
                return item.DateRange === range;
            })[0];
            sched.DateStart = sharpDate(sched.dateStart);
            sched.DateEnd = sched.dateEnd ? sharpDate(sched.dateEnd) : null;
            sched.DateRange = range;
            if (!found) {
                sched.Schedules = [{ TimeStart: tm, DateStart: sched.DateStart, DateEnd: sched.DateEnd, IsRepeated: true }];
                $scope.rangeSchedules.push(sched);
            }
            else {
                var times = $scope.schedule.Schedules.filter(function (item) {
                    var dt = $scope.getTime(item);
                    return tm === dt;
                })[0];
                if (!times) $scope.schedule.Schedules.push({ TimeStart: tm, DateStart: sched.DateStart, DateEnd: sched.DateEnd, IsRepeated: true });
            }
            concertService.getSchedulePreviews($scope.rangeSchedules, function (data) {
                $scope.previewRange = data;
            });
        }
        $scope.clearRange = function () {
            var found = $scope.previewRange.filter(function (item) {
                return item.Dates === $scope.schedule.DateRange;
            });
            if (found.length)
                found.forEach(function (item) {
                    var indx = $scope.previewRange.indexOf(item);
                    if (indx >= 0) $scope.previewRange.splice(indx, 1);
                });
            found = $scope.rangeSchedules.filter(function (item) {
                return item.DateRange === $scope.schedule.DateRange;
            });
            if (found.length)
                found.forEach(function (item) {
                    var indx = $scope.rangeSchedules.indexOf(item);
                    if (indx >= 0) $scope.rangeSchedules.splice(indx, 1);
                });
            $scope.schedule.Schedules = [];
        }

        $scope.saveCalendar = function () {
            var deferred = $q.defer();
            var promise = deferred.promise;
            var calendar = {
                IdEvent: $scope.concert.Id,
                IsRepeated: $scope.calendar.IsRepeated,
                DateStart: sharpDate($scope.dateStart),
            }
            promise.then(function () {
                if (calendar.IsRepeated && $scope.weekSchedules.length)
                    $scope.weekSchedules.forEach(function (item) {
                        item.DateStart = sharpDate($scope.weekDayStart);
                        item.DateEnd = sharpDate($scope.weekDayEnd);
                    });
            }).then(function () {
                if (calendar.IsRepeated) {
                    calendar.DateEnd = sharpDate($scope.dateEnd);
                    calendar.WeekSchedules = $scope.weekSchedules;
                    calendar.RangeSchedules = $scope.rangeSchedules;
                } else {
                    calendar.OneSchedule = {
                        TimeStart: getTimeSpan($scope.oneSchedule.timeStart),
                        DateStart: calendar.DateStart,
                        DateEnd: null,
                        IsRepeated: false
                    }
                }
                concertService.saveSchedule($scope.concert.Id, calendar, function (data) {
                    $rootScope.getConcert($scope.concert.Id);
                    app.closeView('concertCalendarEdit');
                });
            });
            deferred.resolve();
        }
    }

    angular
        .module('app')
        .controller('concertCalendarController', concertCalendarController);

    concertCalendarController.$inject = ['$rootScope', '$scope', 'concertService', '$q'];
})();