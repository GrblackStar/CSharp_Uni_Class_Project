﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Runtime.Intrinsics.X86;
//using System.Text;
//using System.Threading.Tasks;

namespace UserLogin
{
    // static -> cannot be instanciated
    public static class UserData
    {
        #region Properties
        private static List<User> testUser;
        public static List<User> TestUsers 
        { 
            get { ResetTestUserData(); return testUser; }
            set { } 
        }

        #endregion



        #region Methods
        private static void ResetTestUserData()
        {
            if(testUser == null)
            {
                testUser = new List<User>();

                testUser.Add(new User
                {
                    username = "namefirst",
                    password = "passfirst",
                    number = "78626",
                    role = 1,
                    Created = DateTime.Now,
                    ActiveTill = DateTime.MaxValue
                });

                testUser.Add(new User
                {
                    username = "namesecond",
                    password = "passsecond",
                    number = "78626",
                    role = 4,
                    Created = DateTime.Now,
                    ActiveTill = DateTime.MaxValue
                });

                testUser.Add(new User
                {
                    username = "namethird",
                    password = "passthird",
                    number = "78626",
                    role = 4,
                    Created = DateTime.Now,
                    ActiveTill = DateTime.MaxValue
                });

                /*
                testUser[0] = new User();
                testUser[0].username = "namefirst";
                testUser[0].password = "passfirst";
                testUser[0].number = 78626;
                testUser[0].role = 1;
                testUser[0].Created = DateTime.Now;
                testUser[0].ActiveTill = DateTime.MaxValue;

                testUser[1] = new User();
                testUser[1].username = "namesecond";
                testUser[1].password = "passsecond";
                testUser[1].number = 78626;
                testUser[1].role = 4;
                testUser[1].Created = DateTime.Now;
                testUser[1].ActiveTill = DateTime.MaxValue;

                testUser[2] = new User();
                testUser[2].username = "namethird";
                testUser[2].password = "passthird";
                testUser[2].number = 78626;
                testUser[2].role = 4;
                testUser[2].Created = DateTime.Now;
                testUser[2].ActiveTill = DateTime.MaxValue;
                */

            }

        }

        public static User IsUserPassCorrect(string username, string password)
        {
            //User user = TestUsers.FirstOrDefault(u => u.username == username && u.password == password);

            using (var context = new UserContext())
            {
                return context.Users.FirstOrDefault(user => user.username == username && user.password == password);
            }

            //return user;
            /*
            foreach(var user in TestUsers)
            {
                if (user.username == username && user.password == password)
                    return user;
            }
            return null;
            */
        }

        public static void SetUserActiveTo(Activities activity, string username, DateTime activetill)
        {
            /*
            User user = testUser.Where(u => u.username == username).FirstOrDefault();
            if (user != null)
            {
                user.ActiveTill = activetill;
            }
            */
            using (var context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    user.ActiveTill = activetill;
                    Logger.LogActivity(activity, username);
                    context.SaveChanges();
                }
            }
            /*
            for (int i = 0; i < testUser.Count; i++)
            {
                
                if (testUser[i].username == username)
                {
                    testUser[i].ActiveTill = activetill;
                    Logger.LogActivity(activity, username);
                    Console.WriteLine(Logger.ActivityProvides(activity, username));
                }

            }
            */
        }

        public static void AssignUserRole(Activities activity, string username, UserRoles role)
        {
            using (var context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    user.role = (int)role;
                    Logger.LogActivity(activity, username);
                    context.SaveChanges();
                }
            }
            /*
            for (int i = 0; i < testUser.Count; i++)
            {

                if (testUser[i].username == username)
                {
                    testUser[i].role = (int)role;
                    Logger.LogActivity(activity, username);
                    Console.WriteLine(Logger.ActivityProvides(activity, username));
                }

            }
            */

        }


        #endregion


    }
}
