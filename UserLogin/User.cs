using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace UserLogin
{
    internal class User
    {
        #region Properties

        public string username { get; set; }
        public string password { get; set; }
        public int number { get; set; }
        public int role { get; set; }
        public DateTime Created { get; set; }
        public DateTime ActiveTill { get; set; }

        #endregion
    }
}
