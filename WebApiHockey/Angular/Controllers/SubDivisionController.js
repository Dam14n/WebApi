(function () {
	var app = angular.module('app');

	app.controller('SubDivisionController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.subDivision = {};
			$scope.divisions = [];

			function initialize(subdivisionId) {
				var promises = subdivisionId ? getSubDivision(subdivisionId) : [];
				$http.get('webapi/api/divisions').then(function (response) {
					$scope.divisions = response.data;
				});
				$scope.ready = true;
			}

			var getSubDivision = function getSubDivision(id) {
				$http.get('webapi/api/subdivisions/' + id).then(function (response) {
					$scope.subDivision = response.data;
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};

			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != ""){
						$http.put('webapi/api/subdivisions/' + entityMode, JSON.stringify($scope.subDivision)).then(function (response) {
							$state.reload();
						});
					}else{
						$http.post('webapi/api/subdivisions/' + entityMode, JSON.stringify($scope.subDivision)).then(function (response) {
							$state.reload();
						});
					}
				}
				$scope.ready = true;
			};

			initialize($stateParams.id);
		}]);
})();
