using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer;

namespace Business_logic_Layer
{
    public class BALAdminUser
    {
        private readonly DALAdminUser _dalAdminUser;
        public BALAdminUser(DALAdminUser dalAdminUser)
        {
            _dalAdminUser = dalAdminUser;
        }

        public List<UserDetail> UserDetailList()
        {
            return _dalAdminUser.UserDetailList();
        }

        public string DeleteUserAndUserDetail(int userId)
        {
            return _dalAdminUser.DeleteUserAndUserDetail(userId);
        }
    }
}
