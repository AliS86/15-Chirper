﻿using Chirper.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Chirper.API.Infrastructure
{
    public class AuthorizationRepository
    {
        private UserManager<ChirperUser> _userManager;
        private DataContext _dataContext;

        public AuthorizationRepository()
        {
            _dataContext = new DataContext();
            var userStore = new UserStore<ChirperUser>(_dataContext);
            _userManager = new UserManager<ChirperUser>(userStore);
        }

        //task for registering new user
        public async Task<IdentityResult> RegisterUser(RegistrationModel userModel)
        {
            //instantiate new ChirperUser
            ChirperUser user = new ChirperUser
            {
                UserName = userModel.EmailAddress,
                Email = userModel.EmailAddress
            };
         

        //creates the user, stores the password in encrypted formate
        var result = await _userManager.CreateAsync(user, userModel.Password);

        return result;
            }
        //passes registration fields to user manager to do a search, return null if no result
        public async Task<ChirperUser> FindUser(string username, string password)
        {
            return await _userManager.FindAsync(username, password);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
            _userManager.Dispose();
        }
}
}