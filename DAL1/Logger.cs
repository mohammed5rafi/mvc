using System;
using System.Text;

namespace DAL1
{
    public class Logger
    {


        public static void Log(Exception exception)
        {
            try
            {
                // Create an instance of StringBuilder. This class is in System.Text namespace
                StringBuilder sbExceptionMessage = new StringBuilder();
                sbExceptionMessage.Append("Exception Type" + Environment.NewLine);
                // Get the exception type
                sbExceptionMessage.Append(exception.GetType().Name);
                // Environment.NewLine writes new line character - \n
                sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
                sbExceptionMessage.Append("Message" + Environment.NewLine);
                // Get the exception message
                sbExceptionMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
                sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
                // Get the exception stack trace
                sbExceptionMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);

                // Retrieve inner exception if any
                Exception innerException = exception.InnerException;
                // If inner exception exists
                while (innerException != null)
                {
                    sbExceptionMessage.Append("Exception Type" + Environment.NewLine);
                    sbExceptionMessage.Append(innerException.GetType().Name);
                    sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
                    sbExceptionMessage.Append("Message" + Environment.NewLine);
                    sbExceptionMessage.Append(innerException.Message + Environment.NewLine + Environment.NewLine);
                    sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
                    sbExceptionMessage.Append(innerException.StackTrace + Environment.NewLine + Environment.NewLine);

                    // Retrieve inner exception if any
                    innerException = innerException.InnerException;
                }

                // If the Event log source exists

                //if (!EventLog.SourceExists("IhitsHrms"))
                //{
                //    EventLog.CreateEventSource
                //   ("hrms", "IhitsHrms");
                //}

                //// Create an instance of the eventlog
                //EventLog log = new EventLog("IhitsHrms");
                //// set the source for the eventlog
                //log.Source = "hrms";
                // Write the exception details to the event log as an error
                //log.WriteEntry(sbExceptionMessage.ToString(), EventLogEntryType.Error);
                string Result = new CommonDA().SaveErrorLog(sbExceptionMessage.ToString());


            }
            catch (Exception EX)
            {
                throw EX;

            }
        }

    }
}
