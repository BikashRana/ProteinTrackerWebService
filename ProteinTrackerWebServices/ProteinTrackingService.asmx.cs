using System.Collections.Generic;
using System.Web.Services;

namespace ProteinTrackerWebServices
{
    /// <summary>
    /// Summary description for ProteinTrackingService
    /// </summary>
    [WebService(Namespace = "http://bikashrana.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProteinTrackingService : WebService
    {

        private UserRepository repository = new UserRepository();

        [WebMethod(Description = "Adds amount in the total", EnableSession = true)]
        public int AddProtein(int amount, int userId)
        {
            var user = repository.GetById(userId);
            if (user == null)
                return -1;
            user.Total += amount;
            repository.Save(user);


            return user.Total;
        }

        [WebMethod(Description = "Adds user and goal", EnableSession = true)]
        public int AddUser(string name, int goal)
        {

            var user = new User { Goal = goal, Name = name, Total = 0};

            repository.Add(user);            

            return user.UserId;

        }

        [WebMethod(Description = "Return List of users", EnableSession = true)]
        public List<User> ListUsers()
        {

            return new List<User>(repository.GetAll());

        }



    }
}
