(function() { 
     'use strict'; 
 
 
     angular 
         .module('chirpApp') 
         .controller('chirpController', chirpController); 
 
 
     chirpController.$inject = [ 'chirpsService', '$state']; 
 
 
     /* @ngInject */ 
     function chirpController( chirpsService, $state) { 
         var vm = this; 
         vm.title = 'chirpController'; 
 
 
 
 
         //////////////// 
        
 
         vm.addPosts = function(text) {        	 
             chirpsService.addPosts(vm.chrip) 
                          .then(function(response) { 
                            vm.chrips.unshift(response.data);
                          }); 
         }; 

         vm.addComment = function(ChirpId, text) { 
            chirpsService.addComment(ChirpId, Text) 
                 .then(function(response) { 
                     vm.comments.unshift(response.data); 
                     
                 }); 
         }; 

