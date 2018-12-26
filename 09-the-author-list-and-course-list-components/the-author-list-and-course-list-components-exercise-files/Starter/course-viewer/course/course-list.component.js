(function () {
    'use strict';

    angular.module('courseViewer').component('courseList', {
        controllerAs: 'vm',
        controller: function (apiBase, $http) {
            var vm = this;

            vm.courses = null;

            vm.$onInit = function () {
                $http.get(apiBase + 'courses').then(function (result) {
                    vm.courses = result.data;
                });
            }
        },
        templateUrl: 'course-viewer/course/course-list.component.html'
    });
})();
