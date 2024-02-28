using log4net.Config;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hacker.News.Common.Log
{
    public class LogService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LogService));

        static LogService()
        {
            XmlConfigurator.Configure();
        }
        public void AppServiceStart([CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, string kbzRefNo = null)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Info(LogMessage(callingFrame, filePath, methodName, string.Format("{0} is start.", methodName)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }
        public void AppServiceEnd([CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, string kbzRefNo = null)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Info(LogMessage(callingFrame, filePath, methodName, string.Format("{0} is end.", methodName)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }


        public void Info(string message, [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Info(LogMessage(callingFrame, filePath, methodName, message));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }


        public void Warn(string message, [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Warn(LogMessage(callingFrame, filePath, methodName, message));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }

        public void Error(string message, [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame callingFrame = stackTrace.GetFrame(1);
                log.Error(LogMessage(callingFrame, filePath, methodName, message));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex}");
            }
        }

        private static string LogMessage(StackFrame callingFrame, string filePath, string methodName, string message)
        {
            return $"{GetCallingNamespace(callingFrame)}      {GetClassName(filePath)}     {methodName}        {message}";
        }

        private static string GetClassName(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                return Path.GetFileNameWithoutExtension(filePath);
            }

            return "UnknownClass";
        }
        public static string GetCallingNamespace(StackFrame callingFrame)
        {
            if (callingFrame != null)
            {
                System.Reflection.MethodBase callingMethod = callingFrame.GetMethod();

                if (callingMethod != null)
                {
                    Type declaringType = callingMethod.DeclaringType;

                    if (declaringType != null)
                    {
                        return declaringType.Namespace;
                    }
                }
            }

            return string.Empty;
        }
    }
}
