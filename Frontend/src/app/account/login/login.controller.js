(function() {
    angular.module('game')
        .controller('LoginController', [
            'accountService', 
            'sessionService',
            function(accountService, sessionService) {
            var vm = this;
            //vm.hello = 'hehe2';

            vm.login = function(user) {
                var data = 'grant_type=password&username=' + user.username + '&password=' + user.password;
                
                accountService.login(data)
                .then(function(response) {
                    console.log(response.data);
                    sessionService.setToken(response.data.access_token);
                }, function(error) {
                    console.log(error);
                });
            }    
            //console.log('blaba');
        }]);
} ());