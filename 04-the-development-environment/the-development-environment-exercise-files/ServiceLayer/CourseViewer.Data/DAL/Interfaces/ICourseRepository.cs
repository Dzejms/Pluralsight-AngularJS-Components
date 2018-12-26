using System;
using System.Collections.Generic;
using System.Linq;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data.Interfaces
{
    public interface ICourseRepository : ICourseViewerDataRepository<Course>
    {
        IEnumerable<Course> GetForAuthor(int authorId);
        IEnumerable<Course> GetComplete();
        Course GetComplete(int courseId);
    }
}
