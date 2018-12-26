(function () {
    'use strict';

    angular.module('courseViewer').component('courseDiscussion', {
        bindings: {
            course: '<',
            loggedIn: '<'
        },
        controllerAs: 'vm',
        controller: function (authenticationService, courseService) {
            var vm = this;

            vm.discussion = undefined;
            vm.commentEntryVisible = false;

            vm.$onChanges = function (changes) {
                if (changes.course.currentValue == null && changes.loggedIn.currentValue == null) {
                    return;
                }

                if (!authenticationService.loggedIn || vm.course == null) {
                    return;
                }

                courseService.getCourseDiscussion(vm.course.CourseId).then(function (discussion) {
                    vm.discussion = discussion;
                });
            }

            vm.userIsLoggedIn = function () {
                return authenticationService.loggedIn;
            };

            vm.showCommentEntry = function () {
                vm.commentEntryVisible = true;
            }

            vm.commentSubmitted = function (comment) {
                if (authenticationService.loggedIn) {
                    courseService.addDiscussionItem(authenticationService.userName, vm.course.CourseId, comment).
                        then(function (discussionItem) {
                            vm.discussion.push(discussionItem);
                            vm.commentEntryVisible = false;
                        });
                }
            };

            vm.commentCancelled = function () {
                vm.commentEntryVisible = false;
            };

        },
        templateUrl: 'course-viewer/course/course-discussion.component.html'
    });
})();
