using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Modules
{
    public class Response<Type>
    {
        public Boolean IsSuccess { get; set; }
        public String Message { get; set; }
        public Type Payload { get; set; }
    }
}