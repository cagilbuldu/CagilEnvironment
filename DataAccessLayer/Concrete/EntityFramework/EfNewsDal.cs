using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfNewsDal : GenericRepository<News>, INewsDal
    {
        public void NewsStatusToFalse(int id)
        {
            using var context = new CagilEnvironmentContext();
            News news = context.AllNews.Find(id);
            news.Status = false;
            context.SaveChanges();
        }

        public void NewsStatusToTrue(int id)
        {
            using var context = new CagilEnvironmentContext();
            News news = context.AllNews.Find(id);
            news.Status = true;
            context.SaveChanges();
        }
    }
}
