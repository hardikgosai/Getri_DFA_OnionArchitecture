using Domain.Models;
using Getri_DFA_OnionArchitecture.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repository;

namespace Getri_DFA_OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository iUserRepository;
        private readonly IUserProfileRepository iUserProfileRepository;

        public UserController(IUserRepository _iUserRepository, IUserProfileRepository _iUserProfileRepository)
        {
            iUserRepository = _iUserRepository;
            iUserProfileRepository = _iUserProfileRepository;
        }

        [HttpPost("CreateUsers")]
        public int CreateUser(CreateUserDTO model)
        {
             User userEntity = new User();
             userEntity.UserName = model.UserName;
             userEntity.Password = model.Password;
             userEntity.Email = model.Email;
             userEntity.ModifiedDate = DateTime.UtcNow;
             userEntity.Ipaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
             UserProfile userProfile = new UserProfile();
             userEntity.UserProfiles = new List<UserProfile>();
             userProfile.FirstName = model.Firstname;
             userProfile.LastName = model.Lastname;
             userProfile.Address1 = model.Address1;
             userProfile.Address2 = model.Address2;
             userProfile.ContactNo = model.ContactNo;
             userProfile.ModifiedDate = DateTime.UtcNow;
             userProfile.Ipaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
             userEntity.UserProfiles.Add(userProfile);

            iUserRepository.InsertUser(userEntity);
            return 1;
        }

        [HttpPut("UpdateUser")]
        public int UpdateUser(UpdateUserDTO model)
        {
            User userEntity = new User();
            userEntity.UserId = model.UserId;
            userEntity.UserName = model.UserName;
            userEntity.Password = model.Password;
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.Ipaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            userEntity.UserProfiles.Add(iUserProfileRepository.GetUserProfile(model.UserId));

            userEntity.UserProfiles.FirstOrDefault().UserId = model.UserId;
            userEntity.UserProfiles.FirstOrDefault().FirstName = model.Firstname;
            userEntity.UserProfiles.FirstOrDefault().LastName = model.Lastname;
            userEntity.UserProfiles.FirstOrDefault().Address1 = model.Address1;
            userEntity.UserProfiles.FirstOrDefault().Address2 = model.Address2;
            userEntity.UserProfiles.FirstOrDefault().ContactNo = model.ContactNo;
            userEntity.UserProfiles.FirstOrDefault().ModifiedDate = DateTime.UtcNow;
            userEntity.UserProfiles.FirstOrDefault().Ipaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            iUserRepository.UpdateUser(userEntity);
            return 1;
        }

        [HttpDelete("DeleteUser")]
        public int DeleteUser(Int64 Id)
        {
            iUserRepository.DeleteUser(Id);
            return 1;
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(Int64 Id)
        {
            User user = new User();
            user = iUserRepository.Getuser(Id);
            UserProfile userProfile = iUserProfileRepository.GetUserProfile(Id);
            user.UserProfiles = new List<UserProfile>();
            UserProfile userProfileObj = new UserProfile();
            userProfileObj.UserProfileId = userProfile.UserProfileId;
            userProfileObj.UserId = userProfile.UserId;
            userProfileObj.FirstName = userProfile.FirstName;
            userProfileObj.LastName = userProfile.LastName;
            userProfileObj.Address1 = userProfile.Address1;
            userProfileObj.Address2 = userProfile.Address2;
            userProfileObj.ContactNo = userProfile.ContactNo;
            userProfileObj.ModifiedDate = userProfile.ModifiedDate;
            userProfileObj.Ipaddress = userProfile.Ipaddress;
            user.UserProfiles.Add(userProfileObj);
            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {            
            var lstUsers = iUserRepository.GetUsers().ToList();
                        
            var lstUserProfiles = iUserProfileRepository.GetAllUserProfiles().ToList();

            foreach (var user in lstUsers)
            {
                user.UserProfiles = new List<UserProfile>();
                foreach (var userProfile in lstUserProfiles.Where(x => x.UserId == user.UserId).ToList())
                {

                    UserProfile userProfileObj = new UserProfile();
                    userProfileObj.UserProfileId = userProfile.UserProfileId;
                    userProfileObj.FirstName = userProfile.FirstName;
                    userProfileObj.LastName = userProfile.LastName;
                    userProfileObj.Address1 = userProfile.Address1;
                    userProfileObj.Address2 = userProfile.Address2;
                    userProfileObj.ContactNo = userProfile.ContactNo;
                    userProfileObj.ModifiedDate = userProfile.ModifiedDate;
                    userProfileObj.Ipaddress = userProfile.Ipaddress;
                    userProfileObj.UserId = userProfile.UserId;
                    user.UserProfiles.Add(userProfileObj);
                }
            }

            return Ok(lstUsers);
        }
    }
}
