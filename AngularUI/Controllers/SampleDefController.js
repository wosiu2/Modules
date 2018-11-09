        app.controller('SampleDefController', function($scope) {
            $scope.isHidden = -1;
            $scope.data = [{
                x: 10,
                y: 10
            }, {
                x: 12,
                y: 14
            }, {
                x: 14,
                y: 17
            }, {
                x: 20,
                y: 5
            }];
            $scope.addItem = function() {
                $scope.data.push({
                    x: $scope.inputSize,
                    y: $scope.inputAmount
                })
                drawChart($scope.data)
            }
            $scope.deleteItem = function(x) {
                $scope.data.splice(x, 1);
                drawChart($scope.data)
            }
            $scope.editItem = function(x) {
                if (x === $scope.isHidden) {
                    $scope.isHidden = -1;
                } else {
                    $scope.isHidden = x;
                }
                drawChart($scope.data)
            }

            var drawChart = function(data) {
                var ctx = $("#Chart");
                var scatterChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        datasets: [{
                            label: 'Sieve Curve',
                            data: data
                        }]
                    },
                    options: {
                        scales: {
                            xAxes: [{
                                type: 'logarithmic',
                                ticks: {
                                    min: 0.05,
                                    callback: function(tick, index, ticks) {
                                        return tick.toLocaleString()
                                    }
                                }
                            }]
                        }
                    }
                });
            }
            drawChart($scope.data)
        });