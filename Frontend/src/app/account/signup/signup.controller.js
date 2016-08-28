(function() {
    'use strict';

    angular.module('game')
        .controller('SignupController', [
            'accountService',
            'sessionService',
            function(accountService, sessionService) {
                var vm = this;
                //vm.message = 'Signupa sam as';

                vm.register = function(user) {

                    accountService.register(user)
                        .then(function(response) {
                            console.log(response);

                            var data = 'grant_type=password&username=' + user.username + '&password=' + user.password;

                            accountService.login(data)
                                .then(function(response) {
                                    console.log(response.data);
                                    sessionService.setToken(response.data.access_token);
                                }, function(error) {
                                    console.log(error);
                                });
                        });
                };
            }]);
})();