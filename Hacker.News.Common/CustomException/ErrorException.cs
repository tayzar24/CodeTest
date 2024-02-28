using Hacker.News.Common.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.Common.CustomException
{
    public class ErrorException : Exception
    {
        public ErrorInfo ErrorInfo { get; }
        public int StatusCode { get; }


        public ErrorException(ErrorInfo errorCode, string message, int statusCode) : base(message)
        {
            ErrorInfo = errorCode;
            StatusCode = statusCode;
        }
        public ErrorException(ErrorInfo errorCode, string message, int statusCode, Exception innerException) : base(message, innerException)
        {
            ErrorInfo = errorCode;
            StatusCode = statusCode;

            if(innerException != null )
            {
                ErrorInfo.Message = innerException.Message;
            }
        }
    }
}
