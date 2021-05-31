using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        public Result(bool success,string messages):this(success)
        {
            Message = messages;
        }

        public Result(bool success)
        {
            Success = success;
        }
        
        public string Message { get; }
        public bool Success { get; }
    }
}
