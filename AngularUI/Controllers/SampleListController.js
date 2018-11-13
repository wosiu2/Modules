angular.module('AppModule')
    .controller('SampleListController', function($scope, $location, $http) {
        $scope.isHidden = -1;
        $scope.data = [{
            name: 10,
            uscs: "SW",
            Cu: 10.5,
            Cc: 5.16,
            Fines: 5
        }, {
            name: 12,
            uscs: "SW",
            Cu: 14,
            Cc: 5.9,
            Fines: 5
        }, {
            name: 14,
            uscs: "SW",
            Cu: 17,
            Cc: 1,
            Fines: 5
        }, {
            name: 20,
            uscs: "SP",
            Cu: 5,
            Cc: 5,
            Fines: 5
        }];
        $scope.addItem = function() {
            //var res = $http.get('http://localhost:49286/api/SieveSamples/TestPost', $scope.data);
            // var res = $http.post('http://localhost:49286/api/SieveSamples/TestPost', $scope.data);
            $location.url("/SampleDefinition");
        }
        $scope.deleteItem = function(x) {
            $scope.data.splice(x, 1);

        }
        $scope.editItem = function(x) {
            if (x === $scope.isHidden) {
                $scope.isHidden = -1;
            } else {
                $scope.isHidden = x;
            }

        }

    });