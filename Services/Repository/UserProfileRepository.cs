using DAL.EntityFramework;
using Domain.Models;

namespace Services.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly GetriDfaonionArchiContext applicationDbContext;

        public UserProfileRepository(GetriDfaonionArchiContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        public UserProfile GetUserProfile(long id)
        {
            return applicationDbContext.UserProfiles.FirstOrDefault(s => s.UserId == id);
        }

        public List<UserProfile> GetAllUserProfiles()
        {
            return applicationDbContext.UserProfiles.ToList();
        }
    }
}
