using BookDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Service
{
    [DataContract(IsReference = true)]
    public class SaveMemberResponse : ResponseBase
    {
        [DataMember]
        public Member Member { get; set; }
    }
}
