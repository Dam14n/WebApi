(function () {
	var app = angular.module('app');

	app.controller('ClubsController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listClubs = [];

		//get sample
		var getClubs = function getClubs() {
			$http.get('webapi/api/clubs').then(function (response) {
				$scope.listClubs = response.data;
			});
		}

		getClubs();

		$scope.deleteClub = function deleteClub(club) {
			$http.delete('webapi/api/clubs/delete/' + club.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
