(function () {
	var app = angular.module('app');

	app.controller('DivisionsController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listDivisions = [];

		//get sample
		var getDivisions = function initialize() {
			$http.get('/api/divisions').then(function (response) {
				$scope.listDivisions = response.data;
			});
		}

		getDivisions();

		$scope.deleteDivision = function deleteDivision(division) {
			$http.delete('/api/divisions/delete/' + division.Id).then(function (response) {
				$scope.listDivisions = response.data;
				$state.reload();
			});
		};
	}]);
})();
