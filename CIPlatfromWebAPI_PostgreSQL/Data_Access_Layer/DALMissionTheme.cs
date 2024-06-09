using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;


namespace Data_Access_Layer
{
    public class DALMissionTheme
    {
        private readonly AppDbContext _cIDbContext;
        public DALMissionTheme(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }
        public List<MissionTheme> GetMissionThemeList()
        {
            try
            {
                List<MissionTheme> missionTheme = new List<MissionTheme>();
                try
                {
                    missionTheme = _cIDbContext.MissionThemes.Where(m => m.IsDeleted == false).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return missionTheme;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MissionTheme GetMissionThemeById(int id)
        {
            try
            {
                MissionTheme missionThemeDetail = new MissionTheme();
                try
                {
                    missionThemeDetail = _cIDbContext.MissionThemes.SingleOrDefault(m => m.Id == id && !m.IsDeleted);
                    if(missionThemeDetail != null)
                    {
                        return missionThemeDetail;
                    }
                    else
                    {
                        throw new Exception("Mission Theme Not Found");
                    }
                }
                catch (Exception)
                {
                    throw;
                } 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string AddMissionTheme(MissionTheme missionTheme)
        {
            string result = "";
            try
            {
                missionTheme.CreatedDate = DateTime.UtcNow;
                missionTheme.IsDeleted = false;
                _cIDbContext.MissionThemes.Add(missionTheme);
                _cIDbContext.SaveChanges();
                result = "Mission Theme added successfully.";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public string UpdateMissionTheme(MissionTheme missionTheme)
        {
            string result = "";
            try
            {
                    var missionThemeToUpdate = _cIDbContext.MissionThemes.FirstOrDefault(m => m.Id == missionTheme.Id && !m.IsDeleted);

                    if (missionThemeToUpdate != null)
                    {
                        missionThemeToUpdate.ThemeName = missionTheme.ThemeName;
                        missionThemeToUpdate.Status = missionTheme.Status;
                        missionThemeToUpdate.ModifiedDate = DateTime.UtcNow;
                        _cIDbContext.SaveChanges();

                        result = "Update Mission Detail Successfully.";
                    }
                    else
                    {
                        throw new Exception("Mission Theme not found.");
                    }
                
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public string DeleteMissionTheme(int id)
        {
            try
            {
                string result = "";
                var mission = _cIDbContext.MissionThemes.FirstOrDefault(m => m.Id == id);
                if (mission != null)
                {
                    mission.IsDeleted = true;
                    _cIDbContext.SaveChanges();
                    result = "Delete Mission Detail Successfully.";
                }
                else
                {
                    result = "Mission Theme not found.";
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
