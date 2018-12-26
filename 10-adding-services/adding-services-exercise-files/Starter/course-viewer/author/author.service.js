(function () {
    'use strict';

    angular.module('courseViewer').factory('authorService', function (apiBase, $http) {

        var self = this;

        self.getAllAuthors = function () {
            return $http.get(apiBase + '/authors').then(function (result) {
                return result.data;
            });
        };

        self.getAuthorById = function (authorId) {
            return $http.get(apiBase + `/author/${authorId}`).then(function (result) {
                return result.data;
            });
        };
        
        return this;
    });

})();