using BookingAppStore4.DALNew.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingAppStore4.DALNew.Identity;
using BookingAppStore4.DALNew;
using BookingAppStore4.DALNew.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using BookingAppStore4.DALNew.Entities;

namespace BookingAppStore4.DALNew.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _databaseApplicationContext;

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IClientManager _clientManager;

        public IdentityUnitOfWork(string connectionString)
        {
            _databaseApplicationContext = new ApplicationContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_databaseApplicationContext));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_databaseApplicationContext));
            _clientManager = new ClientManager(_databaseApplicationContext);
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }

        public IClientManager ClientManager
        {
            get { return _clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
        }

        public async Task SaveAsync()
        {
            await _databaseApplicationContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                    _clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
