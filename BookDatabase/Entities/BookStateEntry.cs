using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Entities
{

    [DataContract]
    [Flags]
    public enum BookStateEntryType
    {
        [EnumMember]
        Borrow,
        [EnumMember]
        Back
    }

    [DataContract(IsReference = true)]
    [KnownType(typeof(BookStateEntryType))]
    [KnownType(typeof(Member))]
    public class BookStateEntry
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public BookStateEntryType Type { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public virtual Member Member { get; set; }

        [DataMember]
        public int MemberId { get; set; }
    }
}
