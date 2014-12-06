using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Book))]
    [KnownType(typeof(PaperBook))]
    [KnownType(typeof(BookStateEntry))]
    //[KnownType(typeof(BookStates))]
    [KnownType(typeof(BookCondition))]
    [KnownType(typeof(ICollection<BookStateEntry>))]
    public class BookItem
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public DateTime Bought { get; set; }

        [DataMember]
        public virtual PaperBook BookData { get; set; }

        [DataMember]
        
        public List<BookStateEntry> BookStateEntries { get; set; }
        
        [DataMember]
        [NotMapped]
        public BookStates CurrentState
        {
            get
            {
                var lastState = BookStateEntries.LastOrDefault();

                if (lastState == null)
                    return BookStates.Free;

                if (lastState.Type == BookStateEntryType.Borrow)
                    return BookStates.Rent;

                return BookStates.Free;
            }
            private set { }
        }

        [DataMember]
        public BookCondition Condition { get; set; }

    }

    [DataContract]
    [Flags]
    public enum BookCondition
    {
        [EnumMember]
        New,
        [EnumMember]
        Good,
        [EnumMember]
        Bad,
        [EnumMember]
        VeryBad
    }

    [DataContract]
    [Flags]
    public enum BookStates
    {
        [EnumMember]
        Free,
        [EnumMember]
        Rent,
        [EnumMember]
        Expired
    }
}
