using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Intrinsics.X86;
//using System.Text;
//using System.Threading.Tasks;

namespace UserLogin
{
    // static -> cannot be instanciated
    internal static class UserData
    {
        private static List<User> testUser;
        public static List<User> TestUsers 
        { 
            get { ResetTestUserData(); return testUser; }
            set { } 
        }

        
        private static void ResetTestUserData()
        {
            if(testUser == null)
            {
                testUser = new List<User>();

                testUser.Add(new User
                {
                    username = "namefirst",
                    password = "passfirst",
                    number = 78626,
                    role = 1,
                    Created = DateTime.Now,
                    ActiveTill = DateTime.MaxValue
                });

                testUser.Add(new User
                {
                    username = "namesecond",
                    password = "passsecond",
                    number = 78626,
                    role = 4,
                    Created = DateTime.Now,
                    ActiveTill = DateTime.MaxValue
                });

                testUser.Add(new User
                {
                    username = "namethird",
                    password = "passthird",
                    number = 78626,
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
            foreach(var user in TestUsers)
            {
                if (user.username == username && user.password == password)
                    return user;
            }
            return null;
        }

        public static void SetUserActiveTo(string username, DateTime activetill)
        {
            /*
            User user = testUser.Where(u => u.username == username).FirstOrDefault();
            if (user != null)
            {
                user.ActiveTill = activetill;
            }
            */

            for (int i = 0; i < testUser.Count; i++)
            {
                
                if (testUser[i].username == username)
                {
                    testUser[i].ActiveTill = activetill;
                    Logger.LogActivity("Cganging the activity of " + username);
                }

            }
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            for (int i = 0; i < testUser.Count; i++)
            {

                if (testUser[i].username == username)
                {
                    testUser[i].role = (int)role;
                    Logger.LogActivity("Cganging the role of " + username);
                }

            }
        }





    }
}
