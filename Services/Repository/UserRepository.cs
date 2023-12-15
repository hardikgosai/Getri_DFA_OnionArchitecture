

using DAL.EntityFramework;
using Domain.Models;

namespace Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly GetriDfaonionArchiContext applicationDbContext;

        public UserRepository(GetriDfaonionArchiContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        public void DeleteUser(long id)
        {
            List<UserProfile> userProfiles = applicationDbContext.UserProfiles.Where(x => x.UserId == id).ToList();
            foreach (var item in userProfiles)
            {
                applicationDbContext.UserProfiles.Remove(item);
                applicationDbContext.SaveChanges();
            }

            User user = applicationDbContext.Users.Find(id);
            applicationDbContext.Users.Remove(user);
            applicationDbContext.SaveChanges();
        }

        public User Getuser(long id)
        {
            return applicationDbContext.Users.Where(s => s.UserId == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return applicationDbContext.Users.ToList();
        }

        public void InsertUser(User user)
        {
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
        }
    }
}
