using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace UserLogin
{
    public class User
    {
        #region Properties

        public System.Int32 UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string number { get; set; }
        public int role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ActiveTill { get; set; }

        #endregion
    }
}
