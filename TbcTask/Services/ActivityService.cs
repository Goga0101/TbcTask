using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TbcTask.Interfaces;
using TbcTask.Models.ActivityModels;

namespace TbcTask.Services
{
    public class ActivityService: IActivityService
    {
        [HttpGet]

     
        public async Task<ActivityModel> GetActivity()
        {
            ActivityModel activityObject = new ActivityModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.boredapi.com/api/activity"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    activityObject = JsonConvert.DeserializeObject<ActivityModel>(apiResponse);
                }
            }
            return activityObject;
        }
    }
}
