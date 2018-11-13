        var app = angular.module('AppModule', ["ngRoute", 'ngCookies']);

        app.config(['$routeProvider', '$locationProvider', '$cookiesProvider',
            function($routeProvider, $locationProvider, $cookiesProvider) {
                $cookiesProvider.defaults = { path: '/' };
                //$locationProvider.html5Mode(true);
                $routeProvider
                    .when("/SampleList", {
                        templateUrl: "SampleList.html",
                        controller: 'SampleListController'

                    })
                    .when("/", {
                        templateUrl: "Home.html",
                        controller: 'HomeController'

                    })
                    .when("/SampleDefinition", {
                        templateUrl: "SampleDefinition.html",
                        controller: 'SampleDefController'
                    })
                    .when("/Login", {
                        templateUrl: "Login.html",
                        controller: 'LoginController'
                    })
                    .otherwise({
                        redirectTo: '/'
                    });

                $locationProvider.html5Mode(true);
                //$locationProvider.hashPrefix('');
            }
        ]);