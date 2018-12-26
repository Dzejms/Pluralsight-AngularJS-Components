(function () {
    'use strict';

    angular.module('courseViewer').component('courseDiscussion', {
        bindings: {
            course: '<'
        },
        controllerAs: 'vm',
        controller: function (authenticationService, courseService) {
            var vm = this;

            vm.discussion = undefined;

            vm.$onChanges = function (changes) {
                if (changes.course.currentValue == null) {
                    return;
                }

                if (!authenticationService.loggedIn || vm.course == null) {
                    return;
                }

                vm.discussion = courseService.getCourseDiscussion(vm.course.CourseId).then(function (discussion) {
                    vm.discussion = discussion;
                });
            }

            vm.userIsLoggedIn = function () {
                return authenticationService.loggedIn;
            };
        },
        templateUrl: 'course-viewer/course/course-discussion.component.html'
    });
})();
