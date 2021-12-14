using IRestaurantManageDAL;
using RestaurantManageEntity;

namespace RestaurantManageDAL
{
    public class Stasff_RoleInfoDal : BaseDal<Stasff_RoleInfo>, IStasff_RoleInfoDal
    {
        ManegeDbContext _DbContext;
        public Stasff_RoleInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
