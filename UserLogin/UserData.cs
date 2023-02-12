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
        private static User _testUser;
        public static User TestUser 
        { 
            get { ResetTestUserData(); return _testUser; }
            set { } 
        }

        

        private static void ResetTestUserData()
        {
            if(_testUser == null)
            {
                _testUser = new User();
                _testUser.username = "name";
                _testUser.password = "pass";
                _testUser.number = 78626;
                _testUser.role = 1;
            }

        }

    }
}
