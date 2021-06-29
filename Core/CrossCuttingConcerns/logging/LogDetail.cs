using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public LogDetail()
        {
            Date_ = DateTime.Now;
        }

        public string MethodName { get; set; }
        public DateTime Date_ { get; set; }
        public List<LogParameter> LogParameters { get; set; }
        
    }


}
