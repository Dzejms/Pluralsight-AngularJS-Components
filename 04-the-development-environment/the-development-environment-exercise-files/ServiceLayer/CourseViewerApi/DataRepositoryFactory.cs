using CourseViewer.Data.Interfaces;
using System.Web.Http;

namespace CourseViewerWebApi.DAL
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            return (T)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(T));
        }
    }
}