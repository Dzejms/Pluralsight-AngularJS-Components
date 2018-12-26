using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Melvicorp.Data;
using CourseViewer.Data.Entities;
using CourseViewer.Data.Interfaces;

namespace CourseViewer.Data.Repositories
{
    public class DiscussionEntryRepository : CourseViewerDataRepositoryBase<DiscussionEntry>, IDiscussionEntryRepository
    {
        protected override DbSet<DiscussionEntry> DbSet(CourseViewerDbContext entityContext)
        {
            return entityContext.DiscussionEntrySet;
        }

        protected override Expression<Func<DiscussionEntry, bool>> IdentifierPredicate(CourseViewerDbContext entityContext, int id)
        {
            return (e => e.DiscussionEntryId == id);
        }

        public IEnumerable<DiscussionEntry> GetForCourse(int courseId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                IEnumerable<DiscussionEntry> discussionEntries = entityContext.DiscussionEntrySet
                                                                 .Where(item => item.CourseId == courseId)
                                                                 .Include(item => item.User)
                                                                 .OrderByDescending(item => item.EnteredOn)
                                                                 .ToFullyLoaded();

                return discussionEntries;
            }
        }
    }
}