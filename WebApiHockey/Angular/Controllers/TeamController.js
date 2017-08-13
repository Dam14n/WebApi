(function () {
	var app = angular.module('app');

	app.controller('TeamController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.team = {};
			$scope.players = [];
			$scope.playersTeam = [];
			$scope.newPlayerTeam = [];
			var playersLeftTeam = [];
			$scope.clubs = [];

			function initialize(teamId) {
				var promises = teamId ? getTeam(teamId) : [];
				$http.get('/api/players').then(function (response) {
					$scope.players = response.data;
				});
				$scope.ready = true;
			};

			var getTeam = function getTeam(id) {
				$http.get('/api/teams/' + id).then(function (response) {
					$scope.team = response.data;
					$http.get('/api/teams/' + $scope.team.Id + '/players').then(function (response) {
						$scope.playersTeam = response.data;
					});
					$http.get('/api/clubs').then(function (response) {
						$scope.clubs = response.data;
						$scope.clubs.push({ Name: "SIN CLUB" });
					});
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};

			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != "") {
						$http.put('/api/teams/' + entityMode, JSON.stringify($scope.team)).then(function (response) {
							submitPlayers();
							$state.reload();
						});
					} else {
						$http.post('/api/teams/' + entityMode, JSON.stringify($scope.team)).then(function (response) {
							submitPlayers();
							$state.reload();
						});
					}
				}
				$scope.ready = true;
			};

			$scope.addPlayer = function (playerTeam) {
				$scope.newPlayerTeam.push(playerTeam);
			};

			var submitPlayers = function () {
				angular.forEach($scope.newPlayerTeam, function (player) {
					player.TeamId = $scope.team.Id;
					$http.put('/api/players/put', JSON.stringify(player)).then(function (response) {
						$state.reload();
					});
				})
				angular.forEach(playersLeftTeam, function (player) {
					player.TeamId = null;
					$http.put('/api/players/put', JSON.stringify(player)).then(function (response) {
						$state.reload();
					});
				})
			};

			initialize($stateParams.id);

			$scope.addNew = function () {
				$scope.playersTeam.push({});
			};

			$scope.remove = function () {
				var newDataList = [];
				angular.forEach($scope.playersTeam, function (player) {
					if (!player.selected) {
						newDataList.push(player);
					} else {
						playersLeftTeam.push(player);
					}
				});
				$scope.playersTeam = newDataList;
			};

			$scope.checkAll = function () {
				angular.forEach($scope.playersTeam, function (player) {
					player.selected = $scope.SelectedAll;
				});
			};
		}]);
})();
