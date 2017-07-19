(function () {
	var app = angular.module('app');

	app.controller('DivisionController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.division = {};

			function initialize(divisionId) {
				var promises = divisionId ? getDivision(divisionId) : [];
				$scope.ready = true;
			}

			var getDivision = function getDivision(id) {
				$http.get('/api/divisions/' + id).then(function (response) {
					$scope.division = response.data;
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};

			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != "") {
						$http.put('/api/divisions/' + entityMode, JSON.stringify($scope.division)).then(function (response) {
							$state.reload();
						});
					} else {
						$http.post('/api/divisions/' + entityMode, JSON.stringify($scope.division)).then(function (response) {
							$state.reload();
						});
					}
					$scope.ready = true;
				};
			};

			initialize($stateParams.id);
		}]);
})();
