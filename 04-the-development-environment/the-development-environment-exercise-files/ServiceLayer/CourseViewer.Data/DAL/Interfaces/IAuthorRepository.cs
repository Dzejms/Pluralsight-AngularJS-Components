using System;
using System.Collections.Generic;
using System.Linq;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data.Interfaces
{
    public interface IAuthorRepository : ICourseViewerDataRepository<Author>
    {
        IEnumerable<Author> GetComplete();
        Author GetComplete(int authorId);
    }
}
