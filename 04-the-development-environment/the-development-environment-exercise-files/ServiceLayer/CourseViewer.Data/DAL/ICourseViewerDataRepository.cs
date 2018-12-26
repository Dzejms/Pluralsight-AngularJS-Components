using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;

namespace CourseViewer.Data
{
    public interface ICourseViewerDataRepository<T> : IDataRepository<T, CourseViewerDbContext, int>
            where T : class, IIdentifiableEntity<int>, new()
    {
    }
}
