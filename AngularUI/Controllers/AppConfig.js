        var app = angular.module('AppModule', ["ngRoute"]);

        app.config(function($routeProvider) {

            $routeProvider
                .when("/", {
                    templateUrl: "SampleList.html",
                    controller: 'SampleListController'

                })
                .when("/SampleDefinition", {
                    templateUrl: "SampleDefinition.html",
                    controller: 'SampleDefController'
                });
        });