using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer;

namespace Business_logic_Layer
{
    public class BALMissionTheme
    {
        private readonly DALMissionTheme _dalMissionTheme;
        public BALMissionTheme(DALMissionTheme dalMissionTheme)
        {
            _dalMissionTheme = dalMissionTheme;
        }

        public List<MissionTheme> GetMissionThemeList()
        {
            return _dalMissionTheme.GetMissionThemeList();
        }
        public MissionTheme GetMissionThemeById(int id)
        {
            return _dalMissionTheme.GetMissionThemeById(id);
        }

        public string AddMissionTheme(MissionTheme missionTheme)
        {
            return _dalMissionTheme.AddMissionTheme(missionTheme);
        }
        public string UpdateMissionTheme(MissionTheme missionTheme)
        {
            return _dalMissionTheme.UpdateMissionTheme(missionTheme);
        }
        public string DeleteMissionTheme(int id)
        {
            return _dalMissionTheme.DeleteMissionTheme(id);
        }
    }
}
