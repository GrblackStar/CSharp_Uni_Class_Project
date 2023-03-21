using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        #region Fields
        public static UserRoles currentUserRole { get; private set; }
        public static string currentUserUsername { get; private set; }
        

        private string Username;
        private string Password;
        private string ErrorMessage;

        public delegate void ActionOnError(string errorMsg);
        private ActionOnError ErrorDelegate;


        #endregion



        #region Methods
        public LoginValidation (string username, string password, ActionOnError errorDelegate)
        {
            Username = username;
            Password = password;
            ErrorDelegate = errorDelegate;
        }

        public bool ValidateUserInput (ref User user) 
        {
            user = new User();
            //user = null;
            //currentUserRole = (UserRoles)user.role;

            if (Username.Equals(String.Empty))
            {
                ErrorMessage = "Username is missing";
                //Console.Write(ErrorMessage);
                //ErrorDelegate?.Invoke(ErrorMessage);
                ErrorDelegate(ErrorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                currentUserUsername = string.Empty;
                return false;
            }
            if(Password.Equals(String.Empty))
            {
                ErrorMessage = "Password is missing";
                //Console.Write(ErrorMessage);
                //ErrorDelegate?.Invoke(ErrorMessage);
                ErrorDelegate(ErrorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                currentUserUsername = string.Empty;
                return false;
            }
            if (Username.Length < 5)
            {
                ErrorMessage = "Username is too short. Must be longer than 5 symbols";
                //Console.Write(ErrorMessage);
                //ErrorDelegate?.Invoke(ErrorMessage);
                ErrorDelegate(ErrorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                currentUserUsername = string.Empty;
                return false;
            }
            if (Password.Length < 5)
            {
                ErrorMessage = "Password is too short. Must be longer than 5 symbols";
                //Console.Write(ErrorMessage);
                //ErrorDelegate?.Invoke(ErrorMessage);
                ErrorDelegate(ErrorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                currentUserUsername = string.Empty;
                return false;
            }
            if (UserData.IsUserPassCorrect(Username, Password) == null)
            {
                ErrorMessage = "Incorrect Password or Username";
                //Console.Write(ErrorMessage);
                //ErrorDelegate?.Invoke(ErrorMessage);
                ErrorDelegate(ErrorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                currentUserUsername = string.Empty;
                return false;
            }
            if (UserData.IsUserPassCorrect(Username, Password) != null)
            {
                user = UserData.IsUserPassCorrect(Username, Password);
                currentUserRole = (UserRoles)user.role;
                currentUserUsername = Username;
                Logger.LogActivity(Activities.UserLogin, Username);
                return true;
            }
            

            return true;
        }



        #endregion

    }
}
