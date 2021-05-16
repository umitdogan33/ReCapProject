using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        SuccessResult(string message) : base(true, message)
        {

        }

        SuccessResult() : base(true)
        {

        }

    }
}
