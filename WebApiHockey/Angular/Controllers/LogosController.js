(function () {
	var app = angular.module('app');

	app.controller('LogosController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listLogos = [];

		//get sample
		var getLogos = function initialize() {
			$http.get('webapi/api/logos').then(function (response) {
				$scope.listLogos = response.data;
			});
		}

		getLogos();

		$scope.deleteLogo = function deleteLogo(logo) {
			$http.delete('webapi/api/logos/delete/' + logo.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
