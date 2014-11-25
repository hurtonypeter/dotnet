using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BookDatabase.Entities
{
    [DataContract]
    [KnownType(typeof(Book))]
    [KnownType(typeof(Category))]
    [KnownType(typeof(Writer))]
    [KnownType(typeof(ICollection<Category>))]
    [KnownType(typeof(ICollection<Writer>))]
    public class EBook : Book
    {
        [DataMember]
        public string FilePath { get; set; }


        [DataMember]
        public bool Downloadable { get; set; }
    }
}
