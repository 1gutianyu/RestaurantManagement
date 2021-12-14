using IRestaurantManageDAL;
using RestaurantManageEntity;

namespace RestaurantManageDAL
{
    public class RoleInfoDal : BaseDal<RoleInfo>, IRoleInfoDal
    {
        ManegeDbContext _DbContext;
        public RoleInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
