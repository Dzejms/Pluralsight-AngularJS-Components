(function () {
    'use strict';

    angular.module('courseViewer').component('author', {
        bindings: {
            authorId: '<'
        },
        controllerAs: 'vm',
        controller: function () {
            var vm = this;

            vm.author = null;

            vm.$onInit = function () {
                if (!vm.authorId)
                    vm.authorId = 101; // sample only
            }
        },
        templateUrl: 'course-viewer/author/author.component.html'
    });
})();
