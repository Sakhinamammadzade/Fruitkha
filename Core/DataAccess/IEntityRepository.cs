using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity>where TEntity : class,new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter = null);//x=>x. yazmaga  icaze versin

        TEntity Get(Expression<Func<TEntity, bool>> filter);//firstordefault
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
