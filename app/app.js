(function(){
	'use strict';

	angular
		.module('chirpApp',['ui.router'])
)

.config(['$stateProvider', '$urlRouterProvider', '$httpProvider',  function($stateProvider, $urlRouterProvider, $httpProvider){ 

        	$urlRouterProvider.otherwise(''); 
})();