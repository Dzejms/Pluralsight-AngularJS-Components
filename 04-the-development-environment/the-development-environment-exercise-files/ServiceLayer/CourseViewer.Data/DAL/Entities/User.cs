using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;
using System.Runtime.Serialization;

namespace CourseViewer.Data.Entities
{
    [DataContract]
    public class User : IIdentifiableEntity<int>
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string AspNetUsersId { get; set; }

        public int EntityId
        {
            get { return UserId; }
            set { UserId = value; }
        }
    }
}
