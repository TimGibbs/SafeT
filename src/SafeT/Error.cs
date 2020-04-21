using System;
using System.Collections.Generic;

namespace SafeT
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
        public IEnumerable<object> Offenders { get; set; }

        public static implicit operator Error(Exception e) => new Error() { StatusCode = 500, Message = e.Message, Content = e };
    }
}