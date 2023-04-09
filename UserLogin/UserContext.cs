using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }



        public UserContext() : base(Properties.Settings.Default.DbConnect)
        {
            if (!Users.Any())
            {
                Users.AddRange(UserData.TestUsers);
                SaveChanges();
            }
            {
                void CopyTestUsers()
                {
                    using (var context = new UserContext())
                    {
                        foreach (User user in UserData.TestUsers)
                        {
                            context.Users.Add(user);
                        }

                        context.SaveChanges();
                    }

                }
            }
            
        }

    }
}
