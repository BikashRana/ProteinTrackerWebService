using System.Collections.ObjectModel;

namespace ProteinTrackerWebServices
{
    public interface IUserRepository
    {
        void Add(User user);
        ReadOnlyCollection<User> GetAll();
        User GetById(int id);
        void Save(User updatedUser);
    }
}
