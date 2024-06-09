using Data_Access_Layer.Repository.Entities;
using Business_logic_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController : ControllerBase
    {
        private readonly BALMissionTheme _balMissionTheme;
        ResponseResult result = new ResponseResult();
        public MissionThemeController(BALMissionTheme balMissionTheme)
        {
            _balMissionTheme = balMissionTheme;
        }

        [HttpGet]
        [Route("GetMissionThemeList")]
        [Authorize]
        public ResponseResult GetMissionThemeList()
        {
            try
            {
                result.Data = _balMissionTheme.GetMissionThemeList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("GetMissionThemeById/{id}")]
        [Authorize]
        public ResponseResult GetMissionThemeById(int id)
        {
            try
            {
                result.Data = _balMissionTheme.GetMissionThemeById(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("AddMissionTheme")]
        [Authorize]
        public ResponseResult AddMissionTheme(MissionTheme missionTheme)
        {
            try
            {
                result.Data = _balMissionTheme.AddMissionTheme(missionTheme);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("UpdateMissionTheme")]
        [Authorize]
        public ResponseResult UpdateMissionTheme(MissionTheme missionTheme)
        {
            try
            {
                result.Data = _balMissionTheme.UpdateMissionTheme(missionTheme);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpDelete]
        [Route("DeleteMissionTheme/{id}")]
        [Authorize]
        public ResponseResult DeleteMissionTheme(int id)
        {
            try
            {
                result.Data = _balMissionTheme.DeleteMissionTheme(id);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
