angular.module('AppModule')
    .controller('NavBarController', ["$scope", "$cookies", "$location", 'AuthRedirect', function($scope, $cookies, $location, AuthRedirect) {

        $scope.LogOut = function() {

            var cookies = $cookies.getAll();
            //debugger;
            if (cookies == null) {
                console.log("no cookies");
            } else {
                angular.forEach(cookies, function(val, key) {
                    console.log(key);
                    $cookies.remove(key);
                });
                //$location.url("/SampleDefinition");

            }
            //AuthRedirect.DeauthUser();
        }
        $scope.redirectT = function() {
            AuthRedirect.Redirect("/");

        }
    }]);