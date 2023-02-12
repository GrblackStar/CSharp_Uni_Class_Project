using System;
using System.Runtime.Intrinsics.X86;

namespace UserLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // example for administrator
            /*
            User user1 = new User();
            user1.username = "name";
            user1.password = "pass";
            user1.number = 78626;
            user1.role = 1;
            */
            //Console.WriteLine(user1.username + " " + user1.password);
            

            LoginValidation loginValidation = new LoginValidation();
            if (loginValidation.ValidateUserInput())
            {
                //Console.WriteLine(user1.username + " " + user1.password + " " + user1.number + " " + user1.role);
                Console.WriteLine(UserData.TestUser.username + " " + UserData.TestUser.password + " " + UserData.TestUser.number + " " + UserData.TestUser.role);
                Console.WriteLine(LoginValidation.currentUserRole);
            }



        }
    }
}
