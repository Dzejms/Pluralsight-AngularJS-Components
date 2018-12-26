(function () {
    'use strict';

    angular.module('courseViewer').component('courseDiscussionItem', {
        bindings: {
            commentSubmitted: '&',
            commentCancelled: '&'
        },
        controllerAs: 'vm',
        controller: function () {
            var vm = this;

            vm.comment = '';

            vm.submit = function () {
                if (!vm.commentSubmitted) {
                    vm.cancel();
                    return;
                }

                vm.commentSubmitted()(vm.comment);
                vm.comment = '';
            };

            vm.cancel = function () {
                if (!vm.commentCancelled) {
                    vm.comment = '';
                    return;
                }

                vm.commentCancelled()();
            };
        },
        templateUrl: 'course-viewer/course/course-discussion-item.component.html'
    })
})();