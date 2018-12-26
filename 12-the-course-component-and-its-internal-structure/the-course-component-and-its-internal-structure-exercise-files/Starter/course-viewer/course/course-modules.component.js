(function () {
    'use strict';

    angular.module('courseViewer').component('courseModules', {
        bindings: {
            course: '<'
        },
        controllerAs: 'vm',
        controller: function (courseService) {
            var vm = this;

            vm.displayDuration = function (module) {
                return courseService.timeFormat(module);
            }
        },
        templateUrl: 'course-viewer/course/course-modules.component.html'
    });
})();
