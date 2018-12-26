(function () {
    'use strict';
    
    angular.module('courseViewer').factory('courseService', function (apiBase, $http) {

        var self = this;

        self.getAllCourses = function () {
            return $http.get(apiBase + 'courses')
                .then(function (result) {
                    return result.data;
                });
        }

        self.getCourse = function (courseId) {
            return $http.get(apiBase + 'course/' + courseId + '/full')
                .then(function (result) {
                    return result.data;
                });
        }

        self.timeFormat = function (module) {
            var hours = 0, minutes = 0, seconds = 0;

            hours = module.Hours;
            minutes = module.Minutes;
            seconds = module.Seconds;

            while (seconds > 59) {
                minutes++;
                seconds -= 60;
            }

            while (minutes > 59) {
                hours++;
                minutes -= 60;
            }

            var timeString = '';

            if (hours > 0) {
                timeString += hours.toString() + 'h ';
            }
            timeString += minutes.toString() + 'm ';
            timeString += seconds.toString() + 's';

            return timeString;
        };

        return this;
    });
})();