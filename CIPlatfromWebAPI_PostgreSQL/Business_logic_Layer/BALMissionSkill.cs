﻿using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;


namespace Business_logic_Layer
{
    public class BALMissionSkill
    {
        private readonly DALMissionSkill _dalMissionSkill;
        public BALMissionSkill(DALMissionSkill dalMissionSkill)
        {
            _dalMissionSkill = dalMissionSkill;
        }
        public List<MissionSkill> GetMissionSkillList()
        {
            return _dalMissionSkill.GetMissionSkillList();
        }
        public MissionSkill GetMissionSkillById(int id)
        {
            return _dalMissionSkill.GetMissionSkillById(id);
        }

        public string AddMissionSkill(MissionSkill missionSkill)
        {
            return _dalMissionSkill.AddMissionSkill(missionSkill);
        }
        public string UpdateMissionSkill(MissionSkill missionSkill)
        {
            return _dalMissionSkill.UpdateMissionSkill(missionSkill);
        }
        public string DeleteMissionSkill(int id)
        {
            return _dalMissionSkill.DeleteMissionSkill(id);
        }
    }
}
