﻿using MyShopApp.Classes;
using MyShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyShopApp.Repositories
{
    public class UserRepository
    {
        private DbContextcs context;
        public UserRepository(DbContextcs context)=>this.context = context;
   
        public void Add(User user)
        {
           
            
            context.Users.Add(user);
            context.SaveChanges();
            
           
        }
        public void Update(User newUser)
        {
            context.Users.Update(newUser);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Users.Remove(context.Users.Find(id));
            context.SaveChanges();
        }
        public IEnumerable<User> GetAll() => context.Users.ToList();


    }
}
