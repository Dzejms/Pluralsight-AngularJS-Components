using System;
using System.Collections.Generic;
using System.Linq;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data.Interfaces
{
    public interface IRecentlyViewedRepository : ICourseViewerDataRepository<RecentlyViewed>
    {
        IEnumerable<RecentlyViewed> GetForUser(int userId);
        RecentlyViewed GetComplete(int courseId);
        RecentlyViewed GetExistingCourseItem(int userId, int courseId);
        void ClearRecentlyViewed(int userId);
    }
}
