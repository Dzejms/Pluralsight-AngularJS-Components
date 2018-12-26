using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;
using System.Runtime.Serialization;

namespace CourseViewer.Data.Entities
{
    [DataContract]
    public class RecentlyViewed : IIdentifiableEntity<int>
    {
        [DataMember]
        public int RecentlyViewedId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public DateTime ViewedOn { get; set; }

        [DataMember]
        public Course Course { get; set; }

        public int EntityId
        {
            get { return RecentlyViewedId; }
            set { RecentlyViewedId = value; }
        }
    }
}
