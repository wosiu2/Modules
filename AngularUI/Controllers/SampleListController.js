angular.module('AppModule')
    .controller('SampleListController', function($scope, $location) {
        $scope.isHidden = -1;
        $scope.data = [{
            name: 10,
            Cu: 10.5,
            Cc: 5.16
        }, {
            name: 12,
            Cu: 14,
            Cc: 5.9
        }, {
            name: 14,
            Cu: 17,
            Cc: 1
        }, {
            name: 20,
            Cu: 5,
            Cc: 5
        }];
        $scope.addItem = function() {

            //$location.path("/sampleDefinition");
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