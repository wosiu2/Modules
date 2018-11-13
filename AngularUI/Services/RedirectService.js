app.service('AuthRedirect', ["$http", "$location", "$q", function($http, $location, $q) {

    this.invalidPath = '/Login';
    this.authenticationUrl = 'https://localhost:44308/api/Login/Authorization';
    this.DeauthUrl = 'https://localhost:44308/api/Login/Deauth';
    this.ValidUser = function() {

        var req = {
            method: 'POST',
            url: this.authenticationUrl,
            headers: {
                'Content-Type': 'application/json'
            },
            data: {
                Message: 'user check '
            },
            withCredentials: true,
        }
        var def = $q.defer();

        var res = $http(req).then(function successCallback(response) {
            def.resolve(true)
        }, function errorCallback(response) {
            def.resolve(false);
        });

        return def.promise;
    }

    this.DeauthUser = function() {
        var req = {
            method: 'POST',
            url: this.DeauthUrl,
            headers: {
                'Content-Type': 'application/json'
            },
            data: {
                Message: 'user deauth '
            },
            withCredentials: true,
        }


    }

    this.Redirect = function(path) {
        this.ValidUser().then(data => {
            if (data === false) {
                $location.path(this.invalidPath);
            } else {
                console.log(path);
                $location.path(path);
            }
        })

    }
}])