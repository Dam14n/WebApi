(function () {
	var app = angular.module('app');

	app.controller('PlayersController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listPlayers = [];

		//get sample
		var getPlayers = function getPlayers() {
			$http.get('webapi/api/players').then(function (response) {
				$scope.listPlayers = response.data;
			});
		}

		getPlayers();

		$scope.deletePlayer = function deletePlayer(player) {
			$http.delete('webapi/api/players/delete/' + player.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
