(function() {
    'use strict';

    angular.module('game')
        .directive('myNotifications',
        [
            '$timeout',
            function($timeout) {
                return {
                    restrict: 'A',
                    scope: {
                        message: '='
                    },
                    templateUrl: 'app/common/notification.html',
                    link: function($scope, $element, $attr) {
                        //console.log($element);

                        $scope.$watch('message', function(newValue, oldValue) {
                            if (newValue) {
                                $($element[0].firstChild).css('display', 'block');
                            }

                            $timeout(function() {
                                if (newValue) {
                                    $($element[0].firstChild).css('display', 'none');
                                }
                            }, 3000)
                        });
                    }
                };
            }]);
} ());