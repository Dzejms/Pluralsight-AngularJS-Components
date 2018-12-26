using Melvicorp.Data;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace CourseViewer.Data.Entities
{
    [DataContract]
    public class DiscussionEntry : IIdentifiableEntity<int>
    {
        [DataMember]
        public int DiscussionEntryId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int CourseId { get; set; }
        [DataMember]
        public DateTime EnteredOn { get; set; }
        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public User User { get; set; }

        public int EntityId
        {
            get { return DiscussionEntryId; }
            set { DiscussionEntryId = value; }
        }
    }
}
