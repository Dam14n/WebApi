(function () {
	var app = angular.module('app');

	app.controller('TeamsController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listTeams = [];

		//get sample
		var getTeams = function getTeams() {
			$http.get('/api/teams').then(function (response) {
				$scope.listTeams = response.data;
			});
		}

		getTeams();

		$scope.deleteTeam = function deleteTeam(team) {
			$http.delete('/api/teams/delete/' + team.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
