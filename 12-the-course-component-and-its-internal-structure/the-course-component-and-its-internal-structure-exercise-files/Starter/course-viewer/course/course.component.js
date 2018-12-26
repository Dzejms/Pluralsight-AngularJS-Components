(function () {
    'use strict';

    angular.module('courseViewer').component('course', {
        bindings: {
            courseId: '<'
        },
        controllerAs: 'vm',
        controller: function (courseService) {
            var vm = this;

            vm.course = undefined;

            vm.$onInit = function () {
                if (vm.courseId) {
                    courseService.getCourse(vm.courseId).then(function (course) {
                        vm.course = course;
                      });
                }
            };
        },
        templateUrl: 'course-viewer/course/course.component.html'
    });
})();
