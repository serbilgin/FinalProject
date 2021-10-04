using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //for void
        bool Success { get; }
        string Message { get; }
    }
}
