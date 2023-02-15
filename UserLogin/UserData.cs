using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    // static -> cannot be instanciated
    internal static class UserData
    {
        private static User[] testUser;
        public static User[] TestUsers 
        { 
            get { ResetTestUserData(); return testUser; }
            set { } 
        }

        
        private static void ResetTestUserData()
        {
            if(testUser == null)
            {
                testUser = new User[3];

                testUser[0] = new User();
                testUser[0].username = "namefirst";
                testUser[0].password = "passfirst";
                testUser[0].number = 78626;
                testUser[0].role = 1;

                testUser[1] = new User();
                testUser[1].username = "namesecond";
                testUser[1].password = "passsecond";
                testUser[1].number = 78626;
                testUser[1].role = 4;

                testUser[2] = new User();
                testUser[2].username = "namethird";
                testUser[2].password = "passthird";
                testUser[2].number = 78626;
                testUser[2].role = 4;


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

    }
}
