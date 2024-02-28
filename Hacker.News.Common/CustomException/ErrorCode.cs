using Hacker.News.Common.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.Common.CustomException
{
    public class ErrorCode
    {
        public static ErrorInfo ValidationError { get { return new ErrorInfo { Code = "1001", Message = "Validation error" }; } }
        public static ErrorInfo DatabaseError { get { return new ErrorInfo { Code = "1002", Message = "Database Error." }; } }
        public static ErrorInfo NoRecordFound { get { return new ErrorInfo { Code = "1003", Message = "No Record Found!" }; } }
        public static ErrorInfo UnknownException { get { return new ErrorInfo { Code = "1004", Message = "Indicate unknown exception." }; } }
        public static ErrorInfo ThirdParty_Error { get { return new ErrorInfo { Code = "1005", Message = "HTTP error." }; } }
        public static ErrorInfo Timeout { get { return new ErrorInfo { Code = "1006", Message = "Timeout error." }; } }
    }
}
