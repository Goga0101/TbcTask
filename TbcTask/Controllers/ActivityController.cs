using Microsoft.AspNetCore.Mvc;
using TbcTask.Interfaces;
using TbcTask.Models.ActivityModels;

namespace TbcTask.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        [HttpGet("getActivity")]
        public async Task<ActivityModel> GetActivity() => await  _activityService.GetActivity();

       
    }
}
