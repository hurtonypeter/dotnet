using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BookDatabase.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Book))]
    [KnownType(typeof(Category))]
    [KnownType(typeof(Writer))]
    [KnownType(typeof(BookItem))]
    [KnownType(typeof(ICollection<Category>))]
    [KnownType(typeof(ICollection<Writer>))]
    [KnownType(typeof(ICollection<BookItem>))]
    public class PaperBook : Book
    {
        [DataMember]
        public virtual ICollection<BookItem> Copies { get; set; }
    }
}
