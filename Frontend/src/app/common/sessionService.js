(function() {

    'use strict';

    angular.module('game')
        .factory('sessionService',
            function() {
                
                function setToken(token) {
                    sessionStorage.accessToken = token;
                }
                
                function getToken() {
                    if(sessionStorage.accessToken) {
                        return sessionStorage.accessToken;
                    } else {
                        return null;
                    }
                }
                
                return {
                    setToken: setToken,
                    getToken: getToken
                };
            });
} ());