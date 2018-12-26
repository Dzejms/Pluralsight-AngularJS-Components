using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CourseViewer.Data.Interfaces;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data.Repositories
{
    public class UserRepository : CourseViewerDataRepositoryBase<User>, IUserRepository
    {
        protected override DbSet<User> DbSet(CourseViewerDbContext entityContext)
        {
            return entityContext.UserSet;
        }

        protected override Expression<Func<User, bool>> IdentifierPredicate(CourseViewerDbContext entityContext, int id)
        {
            return (e => e.UserId == id);
        }

        public User GetByAspNetUsersId(string aspNetUsersId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                User user = entityContext.UserSet
                              .FirstOrDefault(item => item.AspNetUsersId.ToLower() == aspNetUsersId.ToLower());

                return user;
            }
        }
    }
}
