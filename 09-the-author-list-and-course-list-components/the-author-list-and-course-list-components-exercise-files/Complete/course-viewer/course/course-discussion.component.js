(function () {
    'use strict';

    angular.module('courseViewer').component('courseDiscussion', {
        bindings: {
            course: '<'
        },
        controllerAs: 'vm',
        controller: function () {
            var vm = this;

        },
        templateUrl: 'course-viewer/course/course-discussion.component.html'
    });
})();
