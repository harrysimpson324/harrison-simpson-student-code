using System.Collections.Generic;
using System.IO;
using TodosServer.Models;

namespace TodosServer.DAO
{
    public class UserMemoryDao : IUserDao
    {
        private static readonly List<User> users = new List<User>();

        public UserMemoryDao()
        {
            if (users.Count == 0)
            {
                SetUsers();
            }
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            foreach (User u in users)
            {
                if (u.Username.Equals(username))
                {
                    user = u;
                }
            }
            return user;
        }

        private void SetUsers()
        {
            users.Add(new User(1, "admin", "uRl1apapRCSAzMvKJzIIR6z6L7o=", "PV09N/b0lz0=", "ADMIN"));
            users.Add(new User(2, "liam", "LGo7bWRRPL66WCttQUM/By4gv1g=", "JMdEpH4u/WU=", "USER"));
            users.Add(new User(3, "jessa", "LGo7bWRRPL66WCttQUM/By4gv1g=", "JMdEpH4u/WU=", "USER"));
            users.Add(new User(4, "antoni", "LGo7bWRRPL66WCttQUM/By4gv1g=", "JMdEpH4u/WU=", "USER"));
            users.Add(new User(5, "sofia", "LGo7bWRRPL66WCttQUM/By4gv1g=", "JMdEpH4u/WU=", "USER"));
            users.Add(new User(6, "mark", "LGo7bWRRPL66WCttQUM/By4gv1g=", "JMdEpH4u/WU=", "USER"));
            users.Add(new User(7, "susan", "LGo7bWRRPL66WCttQUM/By4gv1g=", "JMdEpH4u/WU=", "USER"));
            users.Add(new User(8, "jaden", "LGo7bWRRPL66WCttQUM/By4gv1g=", "JMdEpH4u/WU=", "USER"));
        }
    }
}
