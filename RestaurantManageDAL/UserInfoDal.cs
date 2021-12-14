using IRestaurantManageDAL;
using RestaurantManageEntity;

namespace RestaurantManageDAL
{
    public class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
    {
        ManegeDbContext _DbContext;
        public UserInfoDal(ManegeDbContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }
    }
}
