using System;
using System.Linq;

namespace CourseViewerWebApi.Models
{
    public class DiscussionEntryModel
    {
        public string UserName { get; set; }
        public int CourseId { get; set; }
        public string Comment { get; set; }
    }
}
