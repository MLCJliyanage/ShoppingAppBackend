using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Common.Dtos;

namespace ShoppingApp.Business.ManagerClasses.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> Register(UserDto user);

        Task<ReturnUser> Login(UserDto user);

    }
}
