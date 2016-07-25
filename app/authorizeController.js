(function() { 
     'use strict'; 
 
 
     angular 
         .module('Chirpapp') 
         .controller('authorizeController', authorizeController); 
 
 
     authorizeController.$inject = ['authorizeFactory', '$state']; 
 
 
     /* @ngInject */ 
     function authControllers(authorizeFactory, $state) { 
         var vm = this; 
         vm.title = 'authorizeController'; 
