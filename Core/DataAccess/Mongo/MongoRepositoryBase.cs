using Core.DataAccess;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MongoDb
{
    public class MongoRepositoryBase <TDocument>: IEntityRepository<TDocument>
        where TDocument : class,IEntity,new()
    {
        public void Add(TDocument entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TDocument entity)
        {
            throw new NotImplementedException();
        }

        public TDocument Get(System.Linq.Expressions.Expression<Func<TDocument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TDocument> GetAll(System.Linq.Expressions.Expression<Func<TDocument, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(TDocument entity)
        {
            throw new NotImplementedException();
        }
    }
}
