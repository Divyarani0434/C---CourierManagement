using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Entities
{
    internal class User
    {
        private static int nextUserID = 1;

        public User()
        {
            UserID = nextUserID++;
        }

        public int UserID { get; private set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
    

