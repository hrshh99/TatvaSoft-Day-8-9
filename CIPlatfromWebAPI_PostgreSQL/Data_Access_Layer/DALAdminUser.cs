using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer
{
    public class DALAdminUser
    {
        private readonly AppDbContext _cIDbContext;
        public DALAdminUser(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public List<UserDetail> UserDetailList()
        {
            List<UserDetail> userDetails = new List<UserDetail>();
            try
            {
                userDetails = (from u in _cIDbContext.User
                               join ud in _cIDbContext.UserDetail on u.Id equals ud.UserId into userDetailGroup
                               from userDetail in userDetailGroup.DefaultIfEmpty()
                               where u.IsDeleted == false && u.UserType == "user" && userDetail.IsDeleted == false
                               select new UserDetail
                               {
                                   Id = u.Id,
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   PhoneNumber = u.PhoneNumber,
                                   EmailAddress = u.EmailAddress,
                                   UserType = u.UserType,
                                   UserId = userDetail.Id,
                                   Name = userDetail.Name,
                                   Surname = userDetail.Surname,
                                   EmployeeId = userDetail.EmployeeId,
                                   Department = userDetail.Department,
                                   Title = userDetail.Title,
                                   Manager = userDetail.Manager,
                                   WhyIVolunteer = userDetail.WhyIVolunteer,
                                   CountryId = userDetail.CountryId,
                                   CityId = userDetail.CityId,
                                   Avilability = userDetail.Avilability,
                                   LinkdInUrl = userDetail.LinkdInUrl,
                                   MySkills = userDetail.MySkills,
                                   UserImage = userDetail.UserImage,
                                   Status = userDetail.Status
                               }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userDetails;
        }

        public string DeleteUserAndUserDetail(int userId)
        {
            try
            {
                string result = "";
                
                using (var transaction = _cIDbContext.Database.BeginTransaction())
                {
                    try
                    {
                        
                        var userDetail = _cIDbContext.UserDetail.FirstOrDefault(ud => ud.UserId == userId);
                        if (userDetail != null)
                        {
                            userDetail.IsDeleted = true;
                            _cIDbContext.SaveChanges();
                        }

                        var user = _cIDbContext.User.FirstOrDefault(u => u.Id == userId);
                        if (user != null)
                        {
                            user.IsDeleted = true;
                            _cIDbContext.SaveChanges();
                        }

                        
                        transaction.Commit();
                        result = "Delete User Successfully.";
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
