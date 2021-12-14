using IRestaurantManageDAL;
using RestaurantManageEntity;

namespace RestaurantManageDAL
{
    public class Menu_RoleInfoDal : BaseDal<Menu_RoleInfo>, IMenu_RoleInfoDal
    {
        ManegeDbContext _DbContext;
        public Menu_RoleInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
