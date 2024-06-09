
using Data_Access_Layer.Common;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer
{
    public class DALMission
    {
        private readonly AppDbContext _cIDbContext;
        public DALMission(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }
        public List<DropDown> GetMissionThemeList()
        {
            List<DropDown> missionthemeList = new List<DropDown>();
            List<MissionTheme> missionTheme = _cIDbContext.MissionThemes.ToList();
            DropDown dropDown = new DropDown();
            foreach (var item in missionTheme)
            {
                
            }
            return missionthemeList;
        }
        public List<DropDown> GetMissionSkillList()
        {
            List<DropDown> missionskillList = new List<DropDown>();
            
            return missionskillList;
        }
        public List<Missions> MissionList()
        {
            List<Missions> missions = new List<Missions>();
            try
            {
                missions = _cIDbContext.Missions.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return missions;
        }
        public string AddMission(Missions mission)
        {
            string result = "";
            try
            {
                mission.IsDeleted = false;
                mission.CreatedDate = DateTime.UtcNow;
                _cIDbContext.Missions.Add(mission);
                _cIDbContext.SaveChanges();
                result = "Mission added successfully.";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public Missions MissionDetailById(int id)
        {
            try
            {
                Missions mission = new Missions();
                mission = _cIDbContext.Missions.FirstOrDefault(m => m.Id == id && !m.IsDeleted);
                if (mission != null)
                {
                    return mission;
                }
                else
                {
                    throw new Exception("Mission not found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string UpdateMission(Missions mission)
        {
            string result = "";
            try
            {
                // Check if the mission with the same title, city, start date, and end date already exists
                bool missionExists = _cIDbContext.Missions.Any(m => m.MissionTitle == mission.MissionTitle
                                                                    && m.CityId == mission.CityId
                                                                    && m.StartDate == mission.StartDate
                                                                    && m.EndDate == mission.EndDate
                                                                    && m.Id != mission.Id
                                                                    && !m.IsDeleted);

                if (!missionExists)
                {
                    // Find the mission in the database to update
                    var missionToUpdate = _cIDbContext.Missions.FirstOrDefault(m => m.Id == mission.Id && !m.IsDeleted);

                    if (missionToUpdate != null)
                    {
                        // Update the mission details
                        missionToUpdate.MissionTitle = mission.MissionTitle;
                        missionToUpdate.MissionDescription = mission.MissionDescription;
                        missionToUpdate.MissionOrganisationName = mission.MissionOrganisationName;
                        missionToUpdate.MissionOrganisationDetail = mission.MissionOrganisationDetail;
                        missionToUpdate.CountryId = mission.CountryId;
                        missionToUpdate.CityId = mission.CityId;
                        missionToUpdate.StartDate = mission.StartDate;
                        missionToUpdate.EndDate = mission.EndDate;
                        missionToUpdate.MissionType = mission.MissionType;
                        missionToUpdate.TotalSheets = mission.TotalSheets;
                        missionToUpdate.RegistrationDeadLine = mission.RegistrationDeadLine;
                        missionToUpdate.MissionThemeId = mission.MissionThemeId;
                        missionToUpdate.MissionSkillId = mission.MissionSkillId;
                        missionToUpdate.MissionImages = mission.MissionImages;
                        missionToUpdate.MissionDocuments = mission.MissionDocuments;
                        missionToUpdate.MissionAvilability = mission.MissionAvilability;
                        missionToUpdate.MissionVideoUrl = mission.MissionVideoUrl;
                        missionToUpdate.ModifiedDate = DateTime.UtcNow;

                        _cIDbContext.SaveChanges();

                        result = "Update Mission Detail Successfully.";
                    }
                    else
                    {
                        throw new Exception("Mission not found.");
                    }
                }
                else
                {
                    throw new Exception("Mission with the same title, city, start date, and end date already exists.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string DeleteMission(int id)
        {
            try
            {
                string result = "";
                var mission = _cIDbContext.Missions.FirstOrDefault(m => m.Id == id);
                if (mission != null)
                {
                    mission.IsDeleted = true;
                    _cIDbContext.SaveChanges();
                    result = "Delete Mission Detail Successfully.";
                }
                else
                {
                    result = "Mission not found."; // Or any other appropriate message
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
