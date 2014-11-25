using System;
using System.Collections.Generic;
using System.Globalization;
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
    [KnownType(typeof(ICollection<Book>))]
    [KnownType(typeof(ICollection<EBook>))]
    [KnownType(typeof(ICollection<PaperBook>))]
    public class Writer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public virtual ICollection<Book> Books { get; set; }

        //[DataMember]
        //public string FullName
        //{
        //    get
        //    {
        //        if (CultureInfo.CurrentCulture.ToString() == "hu")
        //        {
        //            return LastName + " " + FirstName;
        //        }
        //        else
        //        {
        //            return FirstName + " " + LastName;
        //        }
        //    }
        //}
    }
}
