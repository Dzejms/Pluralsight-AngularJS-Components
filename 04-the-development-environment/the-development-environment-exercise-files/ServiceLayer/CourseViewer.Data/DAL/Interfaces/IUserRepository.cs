using System;
using System.Collections.Generic;
using System.Linq;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data.Interfaces
{
    public interface IUserRepository : ICourseViewerDataRepository<User>
    {
        User GetByAspNetUsersId(string aspIdentityId);
    }
}
