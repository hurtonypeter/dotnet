using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Entities
{
    [DataContract]
    [KnownType(typeof(PaperBook))]
    [KnownType(typeof(EBook))]
    [KnownType(typeof(Category))]
    [KnownType(typeof(Writer))]
    [KnownType(typeof(ICollection<Category>))]
    [KnownType(typeof(ICollection<Writer>))]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string OriginalTitle { get; set; }

        [DataMember]
        public string ISBN { get; set; }

        [DataMember]
        public virtual ICollection<Category> Category { get; set; }

        [DataMember]
        public virtual ICollection<Writer> Writer { get; set; }
    }
}
