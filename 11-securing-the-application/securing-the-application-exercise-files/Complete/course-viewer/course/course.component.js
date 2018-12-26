(function () {
    'use strict';

    angular.module('courseViewer').component('course', {
        bindings: {
            courseId: '<'
        },
        controllerAs: 'vm',
        controller: function () {
            var vm = this;

            vm.$onInit = function () {
                if (!vm.courseId)
                    vm.courseId = 200; // sample only
            }
        },
        templateUrl: 'course-viewer/course/course.component.html'
    });
})();
