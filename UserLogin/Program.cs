using System;
using System.Text.RegularExpressions;
//using System.Runtime.Intrinsics.X86;

namespace UserLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DadeTime type:
            // 15 септември 2017 г., 10 ч. 30 мин. (0 сек.)
            //DateTime(int year, int month, int day, int hour, int minute, int second)
            //int year = dateTime.Year;    // returns 2017
            //int month = dateTime.Month;  // returns 9
            //int day = dateTime.Day;      // returns 15
            //int hour = dateTime.Hour;    // returns 10
            //int minute = dateTime.Minute;// returns 30
            //int second = dateTime.Second;// returns 0
            //DateTime dateTime = new DateTime(2017, 9, 15, 10, 30, 0);

            //DateTime dt = new DateTime(1878, 3, 3);
            //DayOfWeek day = dt.DayOfWeek;
            //Console.WriteLine(day);      //Sunday

            //DateTime dt = DateTime.Now;
            //DayOfWeek day = dt.DayOfWeek;
            //Console.WriteLine(day);



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
                Console.WriteLine(user.username + " " + user.password + " " + user.number + " " + user.role + " " + user.Created);
                
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        Console.WriteLine("You are logged in as Administrator");
                        LoggedAsAdmin();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("You are logged in as Inspector");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("You are logged in as Professor");
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


        public static void LoggedAsAdmin()
        {
            Console.WriteLine("ADMINISTRATOR MENU: Choose an option: ");
            Console.WriteLine("[0] Exit Administator menu ");
            Console.WriteLine("[1] Change user ROLE ");
            Console.WriteLine("[2] Change user ACTIVITY ");
            Console.WriteLine("[3] Show Users ");
            Console.WriteLine("[4] Show Log Activity ");
            Console.WriteLine("[5] Show Current Activity ");

            int chosenItem = int.Parse(Console.ReadLine());
            if (chosenItem == 0)
            {
                // stops the program
            }
            else if (chosenItem == 1)
            {
                Console.WriteLine("Specify username: ");
                string username = Console.ReadLine();
                Console.WriteLine("New Role: ");
                UserRoles newrole;

                string roleinput = Console.ReadLine();
                int introle;

                while (true)
                {
                    if (int.TryParse(roleinput, out introle))
                    {
                        newrole = (UserRoles)introle;
                        break;
                    }
                    else if (roleinput.ToUpper() == "ADMIN")
                    {
                        newrole = UserRoles.ADMIN;
                        break;
                    }
                    else if (roleinput.ToUpper() == "INSPECTOR")
                    {
                        newrole = UserRoles.INSPECTOR;
                        break;
                    }
                    else if (roleinput.ToUpper() == "PROFESSOR")
                    {
                        newrole = UserRoles.PROFESSOR;
                        break;
                    }
                    else if (roleinput.ToUpper() == "STUDENT")
                    {
                        newrole = UserRoles.STUDENT;
                        break;
                    }
                    else if (roleinput.ToUpper() == "ANONYMOUS")
                    {
                        newrole = UserRoles.ANONYMOUS;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Role! Please try again");
                        Console.WriteLine("you can choose between:");
                        Console.WriteLine("[0] Anonymous");
                        Console.WriteLine("[1] Admin");
                        Console.WriteLine("[2] Inspector");
                        Console.WriteLine("[3] Professor");
                        Console.WriteLine("[4] Student");
                    }
                }


                UserData.AssignUserRole(Activities.UserChanged, username, newrole);


            }
            else if (chosenItem == 2)
            {
                Console.WriteLine("Specify username: ");
                string username = Console.ReadLine();

                int day = 0;
                int month = 0;
                int year = 0;

                Console.WriteLine("New date: dd.MM.yyyy ");
                string input = Console.ReadLine();
                string[] inputArguments;

                while (true)
                {
                    if (input.Contains(".") && !input.Contains("/") && !input.Contains("-"))
                    {
                        inputArguments = input.Split(".", StringSplitOptions.RemoveEmptyEntries);
                        day = int.Parse(inputArguments[0]);
                        month = int.Parse(inputArguments[1]);
                        year = int.Parse(inputArguments[2]);
                        break;
                    }
                    else if (input.Contains("/") && !input.Contains(".") && !input.Contains("-"))
                    {
                        inputArguments = input.Split("/", StringSplitOptions.RemoveEmptyEntries);
                        day = int.Parse(inputArguments[0]);
                        month = int.Parse(inputArguments[1]);
                        year = int.Parse(inputArguments[2]);
                        break;
                    }
                    else if (input.Contains("-") && !input.Contains(".") && !input.Contains("/"))
                    {
                        inputArguments = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                        day = int.Parse(inputArguments[0]);
                        month = int.Parse(inputArguments[1]);
                        year = int.Parse(inputArguments[2]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date! Please Try Again: ");
                    }
                }


                /*
                DateTime date;
                bool success = DateTime.TryParse(Console.ReadLine(), out date);
                if (success)
                {
                    // use the `date` variable
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                }
                */



                /*
                Console.WriteLine("Enter a date (yyyy-MM-dd):");
                // ^\d{2}\.\d{2}\.\d{4}$   ->   dd.MM.yyyy
                string input = Console.ReadLine();

                DateTime date;
                Regex regex = new Regex(@"^(\d{4})-(\d{2})-(\d{2})$");
                Match match = regex.Match(input);
                if (match.Success)
                {
                    int year = int.Parse(match.Groups[1].Value);
                    int month = int.Parse(match.Groups[2].Value);
                    int day = int.Parse(match.Groups[3].Value);
                    date = new DateTime(year, month, day);
                    Console.WriteLine("Date entered: " + date);
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                }
                */


                DateTime newdate = new DateTime(day, month, year);

                UserData.SetUserActiveTo(Activities.UserActiveToChange, username, newdate);

            }
            else if (chosenItem == 3)
            {
                // show list of users
            }
            else if (chosenItem == 4)
            {
                Console.WriteLine(Logger.PrintLogFile("logActivity.txt"));
            }
            else if (chosenItem == 5)
            {
                Console.WriteLine(Logger.GetCurrentSessionActivities());
            }






        }

    }
}
