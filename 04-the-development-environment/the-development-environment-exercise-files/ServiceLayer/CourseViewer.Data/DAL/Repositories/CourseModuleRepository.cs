using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CourseViewer.Data.Interfaces;
using CourseViewer.Data.Entities;
using Melvicorp.Data;

namespace CourseViewer.Data.Repositories
{
    public class CourseModuleRepository : CourseViewerDataRepositoryBase<CourseModule>, ICourseModuleRepository
    {
        protected override DbSet<CourseModule> DbSet(CourseViewerDbContext entityContext)
        {
            return entityContext.CourseModuleSet;
        }

        protected override Expression<Func<CourseModule, bool>> IdentifierPredicate(CourseViewerDbContext entityContext, int id)
        {
            return (e => e.CourseId == id);
        }

        public IEnumerable<CourseModule> GetForCourse(int courseId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                IEnumerable<CourseModule> modules = entityContext.CourseModuleSet
                                                    .Where(item => item.CourseId == courseId)
                                                    .ToFullyLoaded();

                return modules;
            }
        }
    }
}
