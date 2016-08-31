(function() {
    angular.module('game')
        .controller('LoginController', [
            'accountService', 
            'sessionService',
            function(accountService, sessionService) {
            var vm = this;
            

            vm.login = function(user) {
                var data = 'grant_type=password&username=' + user.username + '&password=' + user.password;
                
                accountService.login(data)
                .then(function(response) {
                    console.log(response.data);
                    sessionService.setToken(response.data.access_token);
                    vm.message = {
                        text:'logna se!',
                        success: true
                    };
                }, function(error) {
                    console.log(error);
                    vm.message = {
                        text:'mi ne se logna!',
                        success: false
                    };
                });
            }    
            //console.log('blaba');
        }]);
} ());