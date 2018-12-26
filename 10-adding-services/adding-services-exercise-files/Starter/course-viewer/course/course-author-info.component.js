(function () {
    'use strict';

    angular.module('courseViewer').component('courseAuthorInfo', {
        controllerAs: 'vm',
        controller: function () {
            var vm = this;

            vm.$onInit = function () {
                if (!vm.authorId)
                    vm.authorId = 101; // sample only
            }
        },
        templateUrl: 'course-viewer/course/course-author-info.component.html'
    });
})();
