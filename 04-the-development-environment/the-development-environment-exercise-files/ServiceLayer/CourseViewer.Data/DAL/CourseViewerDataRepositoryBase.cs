using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;

namespace CourseViewer.Data
{
    public abstract class CourseViewerDataRepositoryBase<T> : DataRepositoryBase<T, CourseViewerDbContext, int>
        where T : class, IIdentifiableEntity<int>, new()
    {
    }
}
