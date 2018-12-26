using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;
using System.Runtime.Serialization;

namespace CourseViewer.Data.Entities
{
    [DataContract]
    public class CourseModule : IIdentifiableEntity<int>
    {
        [DataMember]
        public int CourseModuleId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Minutes { get; set; }
        [DataMember]
        public int Seconds { get; set; }
        [DataMember]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int EntityId
        {
            get { return CourseModuleId; }
            set { CourseModuleId = value; }
        }
    }
}
