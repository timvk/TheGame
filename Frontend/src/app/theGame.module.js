(function() {
    'use strict';

    angular.module('game', ['ui.router'])
        .config(function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('login', {
                    url: '/login',
                    templateUrl: 'app/account/login/login.html',
                    controller: 'LoginController',
                    controllerAs: 'login'
                })
                .state('signup', {
                    url: '/signup',
                    templateUrl: 'app/account/signup/signup.html',
                    controller: 'SignupController',
                    controllerAs: 'signup'
                });
        });
} ());