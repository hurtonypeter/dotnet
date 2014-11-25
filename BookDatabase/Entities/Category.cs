using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Entities
{

    [DataContract]
    [KnownType(typeof(Book))]
    [KnownType(typeof(EBook))]
    [KnownType(typeof(PaperBook))]
    [KnownType(typeof(Category))]
    [KnownType(typeof(ICollection<Category>))]
    [KnownType(typeof(ICollection<Book>))]
    [KnownType(typeof(ICollection<EBook>))]
    [KnownType(typeof(ICollection<PaperBook>))]
    public class Category
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual Category Parent { get; set; }

        [DataMember]
        public virtual ICollection<Category> Children { get; set; }

        [DataMember]
        public virtual ICollection<Book> Books { get; set; }

        public Category() { }

        public Category(string name)
        {
            Name = name;
        }
    }
}
