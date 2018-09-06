using Lab_MVC.Interfaces.Repositories;

namespace Lab_MVC.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        public bool TheNameIsExist(string trainName)
        {
            if (trainName == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}