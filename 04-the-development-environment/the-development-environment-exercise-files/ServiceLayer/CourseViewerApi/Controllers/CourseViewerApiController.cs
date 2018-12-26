using CourseViewer.Data.Entities;
using CourseViewer.Data.Interfaces;
using CourseViewerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using CourseViewerWebApi.Extensions;

namespace CourseViewerWebApi.Controllers
{
    [RoutePrefix("api/courseviewer")]
    public class CourseViewerApiController : ApiController
    {
        public CourseViewerApiController(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        private ApplicationUserManager _userManager;

        IDataRepositoryFactory _DataRepositoryFactory;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [Route("test")]
        public HttpResponseMessage Test(HttpRequestMessage request)
        {
            var obj = new { FirstName = "Miguel", LastName = "Castro" };

            return request.CreateResponse(HttpStatusCode.OK, obj);
        }

        [HttpGet]
        [Route("authors")]
        public HttpResponseMessage GetAuthors(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            IAuthorRepository authorRepository = _DataRepositoryFactory.GetDataRepository<IAuthorRepository>();

            IEnumerable<Author> authors = authorRepository.Get();

            response = request.CreateResponse<Author[]>(HttpStatusCode.OK, authors.ToArray());

            return response;
        }

        [HttpGet]
        [Route("author/{authorId}")]
        public HttpResponseMessage GetAuthor(HttpRequestMessage request, int authorId)
        {
            HttpResponseMessage response = null;

            IAuthorRepository authorRepository = _DataRepositoryFactory.GetDataRepository<IAuthorRepository>();

            Author author = authorRepository.Get(authorId);

            response = request.CreateResponse<Author>(HttpStatusCode.OK, author);

            return response;
        }

        [HttpGet]
        [Route("author/{authorId}/courses")]
        public HttpResponseMessage GetCoursesForAuthor(HttpRequestMessage request, int authorId)
        {
            HttpResponseMessage response = null;

            ICourseRepository courseRepository = _DataRepositoryFactory.GetDataRepository<ICourseRepository>();

            IEnumerable<Course> courses = courseRepository.GetForAuthor(authorId);

            response = request.CreateResponse<Course[]>(HttpStatusCode.OK, courses.ToArray());

            return response;
        }

        [HttpGet]
        [Route("courses")]
        public HttpResponseMessage GetCourses(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            ICourseRepository courseRepository = _DataRepositoryFactory.GetDataRepository<ICourseRepository>();

            IEnumerable<Course> courses = courseRepository.GetComplete();

            response = request.CreateResponse<Course[]>(HttpStatusCode.OK, courses.ToArray());

            return response;
        }

        [HttpGet]
        [Route("courses/recent/{userName}/get")]
        [Authorize]
        public HttpResponseMessage GetRecents(HttpRequestMessage request, string userName)
        {
            HttpResponseMessage response = null;

            IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();
            IRecentlyViewedRepository recentlyViewedRepository = _DataRepositoryFactory.GetDataRepository<IRecentlyViewedRepository>();

            User user = userRepository.GetByUserName(UserManager, userName);
            if (user != null)
            {
                IEnumerable<RecentlyViewed> recents = recentlyViewedRepository.GetForUser(user.UserId);

                response = request.CreateResponse<RecentlyViewed[]>(HttpStatusCode.OK, recents.ToArray());
            }
            else
            {
                // TODO
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;
        }

        [HttpPost]
        [Route("courses/recent")]
        [Authorize]
        public HttpResponseMessage AddToRecents(HttpRequestMessage request, [FromBody]RecentItemModel recentItemModel)
        {
            HttpResponseMessage response = null;

            IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();
            IRecentlyViewedRepository recentlyViewedRepository = _DataRepositoryFactory.GetDataRepository<IRecentlyViewedRepository>();

            User user = userRepository.GetByUserName(UserManager, recentItemModel.UserName);
            if (user != null)
            {
                RecentlyViewed updatedEntity = null;
                RecentlyViewed recentlyViewed = recentlyViewedRepository.GetExistingCourseItem(user.UserId, recentItemModel.CourseId);
                if (recentlyViewed == null)
                {
                    recentlyViewed = new RecentlyViewed()
                    {
                        UserId = user.UserId,
                        CourseId = recentItemModel.CourseId,
                        ViewedOn = DateTime.Now
                    };

                    updatedEntity = recentlyViewedRepository.Add(recentlyViewed);
                }
                else
                {
                    recentlyViewed.ViewedOn = DateTime.Now;
                    updatedEntity = recentlyViewedRepository.Update(recentlyViewed);
                }

                response = request.CreateResponse<RecentlyViewed>(HttpStatusCode.OK, updatedEntity);
            }
            else
            {
                // TODO
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;
        }

        [HttpGet]
        [Route("courses/recent/{userName}/clear")]
        [Authorize]
        public HttpResponseMessage ClearRecents(HttpRequestMessage request, string userName)
        {
            HttpResponseMessage response = null;

            IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();
            IRecentlyViewedRepository recentlyViewedRepository = _DataRepositoryFactory.GetDataRepository<IRecentlyViewedRepository>();

            User user = userRepository.GetByUserName(UserManager, userName);
            if (user != null)
                recentlyViewedRepository.ClearRecentlyViewed(user.UserId);
            else
            {
                // TODO
            }

            response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        [HttpGet]
        [Route("course/{courseId}/modules")]
        public HttpResponseMessage GetCourseModules(HttpRequestMessage request, int courseId)
        {
            HttpResponseMessage response = null;

            ICourseModuleRepository courseModuleRepository = _DataRepositoryFactory.GetDataRepository<ICourseModuleRepository>();

            IEnumerable<CourseModule> modules = courseModuleRepository.GetForCourse(courseId);

            response = request.CreateResponse<CourseModule[]>(HttpStatusCode.OK, modules.ToArray());

            return response;
        }

        [HttpGet]
        [Route("course/{courseId}/discussion")]
        [Authorize]
        public HttpResponseMessage GetCourseDiscussion(HttpRequestMessage request, int courseId)
        {
            HttpResponseMessage response = null;

            IDiscussionEntryRepository discussionEntryRepository = _DataRepositoryFactory.GetDataRepository<IDiscussionEntryRepository>();

            IEnumerable<DiscussionEntry> discussion = discussionEntryRepository.GetForCourse(courseId);

            response = request.CreateResponse<DiscussionEntry[]>(HttpStatusCode.OK, discussion.ToArray());

            return response;
        }

        [HttpPost]
        [Route("course/{courseId}/discussion")]
        [Authorize]
        public HttpResponseMessage AddCourseDiscussion(HttpRequestMessage request, [FromBody]DiscussionEntryModel discussionEntryModel)
        {
            HttpResponseMessage response = null;

            IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();
            IDiscussionEntryRepository discussionEntryRepository = _DataRepositoryFactory.GetDataRepository<IDiscussionEntryRepository>();

            User user = userRepository.GetByUserName(UserManager, discussionEntryModel.UserName);
            if (user != null)
            {
                DiscussionEntry discussionEntry = new DiscussionEntry()
                {
                    UserId = user.UserId,
                    CourseId = discussionEntryModel.CourseId,
                    EnteredOn = DateTime.Now,
                    Comment = discussionEntryModel.Comment
                };

                DiscussionEntry newEntity = discussionEntryRepository.Add(discussionEntry);

                response = request.CreateResponse<DiscussionEntry>(HttpStatusCode.OK, newEntity);
            }
            else
            {
                // TODO
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;
        }
        
        [HttpGet]
        [Route("course/{courseId}/full")]
        public HttpResponseMessage GetCourseAndModules(HttpRequestMessage request, int courseId)
        {
            HttpResponseMessage response = null;

            ICourseRepository courseRepository = _DataRepositoryFactory.GetDataRepository<ICourseRepository>();

            Course course = courseRepository.GetComplete(courseId);

            response = request.CreateResponse<Course>(HttpStatusCode.OK, course);

            return response;
        }

        [HttpPost]
        [Route("user/add")]
        public HttpResponseMessage AddUser(HttpRequestMessage request, [FromBody]UserModel userModel)
        {
            HttpResponseMessage response = null;

            ApplicationUser applicationUser = UserManager.FindByNameAsync(userModel.UserName).Result;

            IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();
            User user = new User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                AspNetUsersId = applicationUser.Id
            };

            user = userRepository.Add(user);

            response = request.CreateResponse<User>(HttpStatusCode.OK, user);

            return response;
        }

        [HttpGet]
        [Route("user/{userName}/get")]
        public HttpResponseMessage GetUser(HttpRequestMessage request, string userName)
        {
            HttpResponseMessage response = null;

            IUserRepository userRepository = _DataRepositoryFactory.GetDataRepository<IUserRepository>();

            User user = userRepository.GetByUserName(UserManager, userName);

            response = request.CreateResponse<User>(HttpStatusCode.OK, user);

            return response;
        }

        public HttpResponseMessage Scaffold(HttpRequestMessage request, int authorId)
        {
            HttpResponseMessage response = null;



            return response;
        }
    }
}
