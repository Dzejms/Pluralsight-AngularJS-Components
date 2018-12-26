using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Melvicorp.Data;
using CourseViewer.Data.Interfaces;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data.Repositories
{
    public class RecentlyViewedRepository : CourseViewerDataRepositoryBase<RecentlyViewed>, IRecentlyViewedRepository
    {
        protected override DbSet<RecentlyViewed> DbSet(CourseViewerDbContext entityContext)
        {
            return entityContext.RecentlyViewedSet;
        }

        protected override Expression<Func<RecentlyViewed, bool>> IdentifierPredicate(CourseViewerDbContext entityContext, int id)
        {
            return (e => e.RecentlyViewedId == id);
        }

        public IEnumerable<RecentlyViewed> GetForUser(int userId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                IEnumerable<RecentlyViewed> courses = entityContext.RecentlyViewedSet
                                              .Include(item => item.Course)
                                              .Include(item => item.Course.Author)
                                              .Where(item => item.UserId == userId)
                                              .ToFullyLoaded();

                return courses;
            }
        }

        public RecentlyViewed GetComplete(int recentlyViewedId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                RecentlyViewed course = entityContext.RecentlyViewedSet
                                .Include(item => item.Course)
                                .FirstOrDefault(item => item.RecentlyViewedId == recentlyViewedId);

                return course;
            }
        }

        public RecentlyViewed GetExistingCourseItem(int userId, int courseId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                RecentlyViewed course = entityContext.RecentlyViewedSet
                                .FirstOrDefault(item => item.UserId == userId && item.CourseId == courseId);

                return course;
            }
        }

        public void ClearRecentlyViewed(int userId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                IEnumerable<RecentlyViewed> recentList = GetForUser(userId);
                foreach (RecentlyViewed recentlyViewed in recentList)
                    Remove(recentlyViewed);
            }
        }
    }
}