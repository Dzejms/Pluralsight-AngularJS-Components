(function () {
    'use strict';

    angular.module('courseViewer').component('course', {
        bindings: {
            courseId: '<'
        },
        controllerAs: 'vm',
        controller: function (courseService, authenticationService) {
            var vm = this;

            vm.course = undefined;
            vm.authenticationService = authenticationService;

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
