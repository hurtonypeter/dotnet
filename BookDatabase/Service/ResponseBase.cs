﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Service
{
    [DataContract(IsReference = true)]
    public class ResponseBase
    {
        [DataMember]
        public bool Error { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
