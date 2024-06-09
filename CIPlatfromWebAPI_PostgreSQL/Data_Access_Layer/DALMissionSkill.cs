using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using System.Data;


namespace Data_Access_Layer
{
    public class DALMissionSkill
    {
        private readonly AppDbContext _cIDbContext;
        public DALMissionSkill(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }
        public List<MissionSkill> GetMissionSkillList()
        {
            try
            {
                List<MissionSkill> missionSkills = new List<MissionSkill>();
                try
                {
                    missionSkills = _cIDbContext.MissionSkills.Where(m => m.IsDeleted == false).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return missionSkills;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public MissionSkill GetMissionSkillById(int id)
        {
            try
            {
                MissionSkill missionSkillDetail = new MissionSkill();
                try
                {
                    missionSkillDetail = _cIDbContext.MissionSkills.SingleOrDefault(m => m.Id == id && !m.IsDeleted);
                    if (missionSkillDetail != null)
                    {
                        return missionSkillDetail;
                    }
                    else
                    {
                        throw new Exception("Mission Skill Not Found");
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

        public string AddMissionSkill(MissionSkill missionSkill)
        {
            string result = "";
            try
            {
                missionSkill.CreatedDate = DateTime.UtcNow;
                missionSkill.IsDeleted = false;
                _cIDbContext.MissionSkills.Add(missionSkill);
                _cIDbContext.SaveChanges();
                result = "Mission Skill added successfully.";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public string UpdateMissionSkill(MissionSkill missionSkill)
        {
            string result = "";
            try
            {
                
                var missionSkillToUpdate = _cIDbContext.MissionSkills.FirstOrDefault(m => m.Id == missionSkill.Id && !m.IsDeleted);

                if (missionSkillToUpdate != null)
                {
                    
                    missionSkillToUpdate.SkillName = missionSkill.SkillName;
                    missionSkillToUpdate.Status = missionSkill.Status;
                    missionSkillToUpdate.ModifiedDate = DateTime.UtcNow;
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
        public string DeleteMissionSkill(int id)
        {
            try
            {
                string result = "";
                var mission = _cIDbContext.MissionSkills.FirstOrDefault(m => m.Id == id);
                if (mission != null)
                {
                    mission.IsDeleted = true;
                    _cIDbContext.SaveChanges();
                    result = "Delete Mission Skill Successfully.";
                }
                else
                {
                    result = "Mission Skill not found.";
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
