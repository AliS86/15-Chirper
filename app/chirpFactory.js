(function() { 
     'use strict'; 
 
 
     angular 
         .module('chirpApp') 
         .factory('chirpFactory', chirpFactory); 
 
 
     chirpsService.$inject = ['$q', '$http', 'apiUrl']; 

 function chirpsService($q, $http, apiUrl) { 
         var service = { 
            
             addPosts: addPosts, 
             addComment: addComment
             };
             
             return service;
             
             ////////////////

            function addPosts(chirp) { 
            var defer = $q.defer(); 
             $http({ 
                 method: 'POST', 
                 url: apiUrl + 'chirp', 
                 data: chirp 
             })
             .then(function(result) {
             	defer.resolve(result);
             });
             return defer.promise;
             }
             


             function addComment(chirpId) {
             	
             } 
              
           
         
 
 

             
