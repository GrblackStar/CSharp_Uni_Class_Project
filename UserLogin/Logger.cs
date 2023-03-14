using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();


        #region Methods


        static public void LogActivity(Activities activity, string username)
        {
            string activityLine = DateTime.Now + ";  "
                + LoginValidation.currentUserUsername + ";  "
                + LoginValidation.currentUserRole + ";  "
                + ActivityProvides(activity, username);
            currentSessionActivities.Add(activityLine);

            string logFilePath = "logActivity.txt";
            // new string[] { activityLine }  -->  new[] { activityLine }
            // -> to pass an array of values to a method that expects an array, but you only have one value to pass
            //File.AppendAllLines(logFilePath, new string[] { activityLine });
            File.AppendAllText(logFilePath, activityLine);

        }

        public static IEnumerable<string> PrintLogFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
            /*
            //  the using statement is used to ensure that the StreamReader is properly disposed of when we're done with it.
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            return sb.ToString();
            
            // alternatively:
            
            StreamReader reader = new StreamReader(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            reader.Close();
            */
            
        }

        public static IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            /*
            // Вместо да предоставим на ползвателя на класа Logger монолитен string, е по- редно да му предоставим 
            // данните в структуриран вид. Ако ползвателя трябва да формира един string от тях, то отговорността как
            // ще го направи остава негова
            // making the return type to IEnumerable<string>
            */
            /*
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            */

            List<string> filteredActivities = currentSessionActivities.Where(activity => activity.Contains(filter)).ToList();

            return filteredActivities;
        }

        public static string ActivityProvides(Activities activity, string username)
        {
            string message = String.Empty;
            // for every role, to write what the log does
            if (activity == Activities.UserLogin)
            {
                message = "User loged in";
            }
            else if (activity == Activities.UserChanged)
            {
                message = "Changing user " + username;
            }
            else if (activity == Activities.UserActiveToChange)
            {
                message = "Changing activity of " + username;
            }

            return message;
        }



        #endregion
    }
}
