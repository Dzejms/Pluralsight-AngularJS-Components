using System;
using System.Collections.Generic;
using System.Linq;
using Melvicorp.Data;
using System.Runtime.Serialization;

namespace CourseViewer.Data.Entities
{
    [DataContract]
    public class Author : IIdentifiableEntity<int>
    {
        [DataMember]
        public int AuthorId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string ShortBio { get; set; }
        [DataMember]
        public string Bio { get; set; }

        public int EntityId
        {
            get { return AuthorId; }
            set { AuthorId = value; }
        }
    }
}
