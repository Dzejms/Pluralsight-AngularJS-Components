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
    public class AuthorRepository : CourseViewerDataRepositoryBase<Author>, IAuthorRepository
    {
        protected override DbSet<Author> DbSet(CourseViewerDbContext entityContext)
        {
            return entityContext.AuthorSet;
        }

        protected override Expression<Func<Author, bool>> IdentifierPredicate(CourseViewerDbContext entityContext, int id)
        {
            return (e => e.AuthorId == id);
        }

        public IEnumerable<Author> GetComplete()
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                IEnumerable<Author> authors = entityContext.AuthorSet
                                              .ToFullyLoaded();

                return authors;
            }
        }

        public Author GetComplete(int authorId)
        {
            using (CourseViewerDbContext entityContext = new CourseViewerDbContext())
            {
                Author author = entityContext.AuthorSet
                                .FirstOrDefault(item => item.AuthorId == authorId);

                return author;
            }
        }
    }
}