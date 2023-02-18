using System;
//using System.Runtime.Intrinsics.X86;

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

            // enables user to enter password and username on two linws of onr, devided by space
            Console.WriteLine("Enter username and password: ");
            string usernameInput = null;
            string passwordInput = null;

            string passNameInput = Console.ReadLine();
            if (passNameInput.Contains(' '))
            {
                string[] input = passNameInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                usernameInput = input[0];
                passwordInput = input[1];
            }
            else
            {
                usernameInput = passNameInput;
                passwordInput = Console.ReadLine();
            }

            

            User user = null;


            //LoginValidation loginValidation = new LoginValidation(Console.ReadLine(), Console.ReadLine());
            LoginValidation loginValidation = new LoginValidation(usernameInput, passwordInput, HandleErrorMessage);
            if (loginValidation.ValidateUserInput(ref user))
            {
                // prints the name of the class
                //Console.WriteLine(UserData.TestUser);
                //Console.WriteLine(UserData.TestUser.username + " " + UserData.TestUser.password + " " + UserData.TestUser.number + " " + UserData.TestUser.role);
                Console.WriteLine(user.username + " " + user.password + " " + user.number + " " + user.role);
                
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        Console.WriteLine("You are logged in as Administrator");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("You are logged in as Inspector");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("You are logged in as Administrator");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("You are logged in as a Student");
                        break;
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Your role is Anonymous");
                        break;
                    default:
                        break;
                }
                

                //Console.WriteLine(LoginValidation.currentUserRole);
            }



        }



        public static void HandleErrorMessage(string errormessage)
        {
            Console.WriteLine("!!! " + errormessage + " !!!");
        }

    }
}
