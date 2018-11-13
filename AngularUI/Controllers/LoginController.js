angular.module('AppModule')
    .controller('LoginController', ["$scope", "$location", "$http", function($scope, $location, $http) {
        $scope.Login = function() {

            var req = {
                method: 'POST',
                url: 'https://localhost:44308/api/Login/Authenticate',
                headers: {
                    'Content-Type': 'application/json'
                },
                withCredentials: true,
                data: { Login: $scope.login, Password: $scope.passwd }
            }

            var res = $http(req).then(function successCallback(response) {
                $location.url("/Home");
            }, function errorCallback(response) {
                $location.url("/Login");
            });;
        }


    }]);