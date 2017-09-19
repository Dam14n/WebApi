(function () {
	var app = angular.module('app');

	app.controller('DatesController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listDates = [];

		//get sample
		var getDates = function initialize() {
			$http.get('webapi/api/dates').then(function (response) {
				$scope.listDates = response.data;
			});
		}

		getDates();

		$scope.deleteDate = function deleteDate(date) {
			$http.delete('webapi/api/dates/delete/' + date.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
