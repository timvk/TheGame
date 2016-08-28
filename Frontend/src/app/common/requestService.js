(function () {
    
    'use strict';
    
    angular.module('game')
    .factory('requester', [
        '$http',
        '$q'
    ,
    function ($http, $q) {
        
        function getItem(url, headers) {
            
            return makeRequest('GET', url, null, headers);
        }
        
        function postItem(url, data, headers) {
            
            return makeRequest('POST', url, data, headers);
        }
        
        function putItem(url, data, headers) {
            return makeRequest('PUT', url, data, headers);
        }
        
        function deleteItem(url, headers) {
            return makeRequest('DELETE', url, null, headers);
        }
        
        function makeRequest(method, url, data, headers) {
            var defer = $q.defer();
            
            $http({
                method: method,
                url: url,
                headers: headers,
                data: data
            }).then(function(data) {
                defer.resolve(data);
            }, function(error) {
                defer.reject(error);
            });
            
            return defer.promise;
        }
        
        // function setHeaders(headers) {
            
        //     if(!headers['Content-Type'] ) {
        //         headers['Content-Type'] = 'application/json';
        //     }
            
        //     return headers;
        // }
        
        return {
            get: getItem,
            post: postItem,
            put: putItem,
            delete: deleteItem
        }
    }]);
}());