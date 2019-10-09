using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeppesen.Interfaces
{
    public interface IUserService
    {
        bool Login(string login, string password);
        int UserID { get; }
    }
}
