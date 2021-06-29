using Core.CrossCuttingConcerns.Logging.Log4Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.logging.Log4Net.Loggers
{
   public class SeqLogger:LoggerServiceBase
    {
        public SeqLogger() : base("SeqAppender")
        {
        }

    }
}
