(function () {
	var app = angular.module('app');

	app.controller('ClubController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.logoClub = {};
			$scope.club = {};
			$scope.logos = [];

			function initialize(clubId) {
				var promises = clubId ? getClub(clubId) : [];
				$http.get('/api/logos').then(function (response) {
					$scope.logos = response.data;
				});
				$scope.ready = true;
			};

			var getClub = function getClub(id) {
				$http.get('/api/clubs/' + id).then(function (response) {
					$scope.club = response.data;
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};


			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != "") {
						$http.put('/api/clubs/' + entityMode, JSON.stringify($scope.club)).then(function (response) {
							$state.reload();
						});
					} else {
						$http.post('/api/clubs/' + entityMode, JSON.stringify($scope.club)).then(function (response) {
							$state.reload();
						});
					}
				}
				$scope.ready = true;
			};

			initialize($stateParams.id);
		}]);
})();
