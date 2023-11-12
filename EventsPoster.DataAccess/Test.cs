using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventsPoster.DataAccess
{
    public class Test
    {
        public void test(IDbContextFactory<EventsPosterDbContext> contextFactory)
        {
            using var context = contextFactory.CreateDbContext();
            context.Users.Add(new Entities.UserEntity() { });
            context.Users.Where(x => x.Id == 1);
            context.SaveChanges();
        }
    }
}
