using IRestaurantManageDAL;
using RestaurantManageEntity;

namespace RestaurantManageDAL
{
    public class StaffInfoDal : BaseDal<StaffInfo>, IStaffInfoDal
    {
        ManegeDbContext _DbContext;
        public StaffInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
