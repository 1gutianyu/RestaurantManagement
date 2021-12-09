using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManageEntity
{
    public class ManegeDbContext: DbContext
    {
        public ManegeDbContext(DbContextOptions<ManegeDbContext> options) : base(options) 
        { }


        

    }
}
