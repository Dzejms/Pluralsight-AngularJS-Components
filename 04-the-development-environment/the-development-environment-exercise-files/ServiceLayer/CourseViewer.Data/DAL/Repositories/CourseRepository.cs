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
    public class CourseRepository : CourseViewerDataRepositoryBase<Course>, ICourseRepository
    {
        protected override DbSet<Course> DbSet(CourseViewerDbContext entityContext)
        {
            return entityContext.CourseSet;
        }

        protected override Expression<Func<Course, bool>> IdentifierPredicate(CourseViewerDbContext entityContext, int id)
        {
            return (e => e.CourseId == id);
        }

        public IEnumerable<Course> GetForAuthor(int authorId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                IEnumerable<Course> courses = entityContext.CourseSet
                                              .Include(item => item.Author)
                                              .Where(item => item.AuthorId == authorId)
                                              .ToFullyLoaded();

                return courses;
            }
        }

        public IEnumerable<Course> GetComplete()
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                IEnumerable<Course> courses = entityContext.CourseSet
                                              .Include(item => item.Author)
                                              .ToFullyLoaded();

                return courses;
            }
        }

        public Course GetComplete(int courseId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                Course course = entityContext.CourseSet
                                .Include(item => item.Author)
                                .Include(item => item.Modules)
                                .FirstOrDefault(item => item.CourseId == courseId);

                return course;
            }
        }
    }
}