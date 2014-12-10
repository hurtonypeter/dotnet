using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(BookItem))]
    [KnownType(typeof(BookStateEntry))]
    [KnownType(typeof(ICollection<BookStateEntry>))]
    public class Member
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Telephone { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public DateTime Registration { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [Timestamp]
        [DataMember]
        public byte[] RowVersion { get; set; }

        [DataMember]
        public virtual ICollection<BookStateEntry> BookStates { get; set; }

        //[DataMember]
        //public List<BookItem> CurrentBorrowings
        //{
        //    //TODO: gettert rendesen implementálni
        //    get
        //    {
        //        return new List<BookItem>();
        //    }
        //}
    }
}
