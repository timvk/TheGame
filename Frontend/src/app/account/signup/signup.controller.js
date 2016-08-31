(function() {
    'use strict';

    angular.module('game')
        .controller('SignupController', [
            'accountService',
            'sessionService',
            function(accountService, sessionService) {
                var vm = this;

                vm.register = function(user) {

                    accountService.register(user)
                        .then(function(response) {
                            console.log(response);

                            var data = 'grant_type=password&username=' + user.username + '&password=' + user.password;

                            accountService.login(data)
                                .then(function(response) {
                                    console.log(response.data);
                                    sessionService.setToken(response.data.access_token);
                                    vm.message = 'bravo registrira se';
                                }, function(error) {
                                    console.log(error);

                                });
                        }, function(error) {
                            vm.message = 'mi ne uspq da se registirrash';
                        });
                };
            }]);
})();