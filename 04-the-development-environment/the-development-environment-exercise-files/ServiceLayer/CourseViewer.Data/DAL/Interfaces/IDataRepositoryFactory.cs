using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;

namespace CourseViewer.Data.Interfaces
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IDataRepository;
    }
}
