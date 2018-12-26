using CourseViewer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseViewer.Data.Interfaces
{
    public interface IDiscussionEntryRepository : ICourseViewerDataRepository<DiscussionEntry>
    {
        IEnumerable<DiscussionEntry> GetForCourse(int courseId);
    }
}
