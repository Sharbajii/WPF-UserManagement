using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WPF_UserManagement.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);

        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(UserModel userModel);
        UserModel GetbyId(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetAll();
    }
}
