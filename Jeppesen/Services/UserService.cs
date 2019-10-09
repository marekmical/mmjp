using Jeppesen.Data;
using Jeppesen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen.Services
{
    public class UserService : IUserService
    {
        private RecordStoreContext context;

        public UserService(RecordStoreContext context)
        {
            this.context = context;
        }

        public int UserID { get; private set; } = 0;

        public bool Login(string login, string password)
        {
            var user = context.Users.Where(usr => usr.Login == login && usr.Password == password).FirstOrDefault();
            this.UserID = user != null ? user.ID : 0;

            return user != null;
        }
    }
}
