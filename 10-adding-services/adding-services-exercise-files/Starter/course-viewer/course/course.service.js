(function () {
    'use strict';

    angular.module('courseViewer').factory('courseService', function (apiBase, $http) {

        var self = this;

        self.getAllCourses = function () {
            return $http.get(apiBase + 'courses').then(function (result) {
                return result.data;
            });
        };

        self.getCourseById = function (courseId) {
            return $http.get(apiBase + `courses/${courseId}/full`).then(function (result) {
                return result.data;
            });
        }

        return this;
    });
})();