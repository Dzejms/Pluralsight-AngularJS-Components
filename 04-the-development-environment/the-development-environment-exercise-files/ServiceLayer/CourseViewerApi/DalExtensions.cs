using CourseViewer.Data.Entities;
using CourseViewer.Data.Interfaces;
using CourseViewerWebApi.Models;

namespace CourseViewerWebApi.Extensions
{
    public static class DalExtensions
    {
        public static User GetByUserName(this IUserRepository userRepository, ApplicationUserManager userManager, string userName)
        {
            ApplicationUser applicationUser = userManager.FindByNameAsync(userName).Result;
            User user = userRepository.GetByAspNetUsersId(applicationUser.Id);

            return user;
        }
    }
}