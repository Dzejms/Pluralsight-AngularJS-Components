using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;
using System.Runtime.Serialization;

namespace CourseViewer.Data.Entities
{
    [DataContract]
    public class Course : IIdentifiableEntity<int>
    {
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public string CourseName { get; set; }
        [DataMember]
        public string Summary { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime Released { get; set; }
        [DataMember]
        public int AuthorId { get; set; }
        [DataMember]
        public ICollection<CourseModule> Modules { get; set; }

        [DataMember]
        public Author Author { get; set; }

        public int EntityId
        {
            get { return CourseId; }
            set { CourseId = value; }
        }
    }
}
