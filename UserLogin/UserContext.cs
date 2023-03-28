﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }



        public UserContext() : base(Properties.Settings.Default.StudentInfoDatabaseConnectionString)
        {
            if (!Users.Any())
            {
                Users.AddRange(UserData.TestUsers);
                SaveChanges();
            }
        }

    }
}