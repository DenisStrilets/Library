using BookingAppStore4.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingAppStore4.DALNew.Interfaces;
using BookingAppStore4.DALNew.Repositories;
using BookingAppStore4.DALNew.Services;

namespace BookingAppStore4.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
