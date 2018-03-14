using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppStore4.DALNew.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
        void Delete(int id);
        void Dispose();

    }
}
