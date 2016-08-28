(function() {
    'use strict';

    angular.module('game')
        .factory('accountService', [
            'requester',
            function(requester) {

                function login(data) {
                    
                    return requester.post('http://localhost:8080/token', data, {'Content-Type': 'application/x-www-form-urlencoded'});
                }

                function register(data) {
                    
                    return requester.post('http://localhost:8080/api/account/register', data, {'Content-Type': 'application/json'});                   
                }

                return {
                    login: login, 
                    register: register
                }
            }])
} ());