using TbcTask.Models.ActivityModels;

namespace TbcTask.Interfaces
{
    public interface IActivityService
    {

         Task<ActivityModel>  GetActivity();

    }
}
