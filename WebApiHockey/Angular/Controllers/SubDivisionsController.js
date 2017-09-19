(function () {
	var app = angular.module('app');

	app.controller('SubDivisionsController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listSubDivisions = [];

		//get sample
		var getSubDivisions = function initialize() {
			$http.get('webapi/api/subdivisions').then(function (response) {
				$scope.listSubDivisions = response.data;
			});
		}

		getSubDivisions();

		$scope.deleteSubDivision = function deleteSubDivision(subdivision) {
			$http.delete('webapi/api/subdivisions/delete/' + subdivision.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
