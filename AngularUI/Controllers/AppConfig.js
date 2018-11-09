        var app = angular.module('AppModule', ["ngRoute"]);

        app.config(function($routeProvider) {

            $routeProvider
                .when("/", {
                    templateUrl: "D:\Projekty\Modules\AngularUI\SampleList.html",
                    controller: 'SampleListController'

                })
                .when("/sampleDefinition", {
                    templateUrl: "D:\Projekty\Modules\AngularUI\SampleDefinition.html",
                    controller: 'SampleDefController'
                });
        });