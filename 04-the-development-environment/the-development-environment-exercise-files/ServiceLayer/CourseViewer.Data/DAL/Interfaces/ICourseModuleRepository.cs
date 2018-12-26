using System;
using System.Collections.Generic;
using System.Linq;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data.Interfaces
{
    public interface ICourseModuleRepository : ICourseViewerDataRepository<CourseModule>
    {
        IEnumerable<CourseModule> GetForCourse(int courseId);
    }
}
