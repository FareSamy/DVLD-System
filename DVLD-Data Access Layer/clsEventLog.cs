using System;
using System.Diagnostics;


namespace DVLD_Data_Access_Layer
{
    public static class clsEventLog
    {
        public static void Log(Exception ex)
        {

            try
            {
                string SourceName = "DVLD_SYSTEM";

                if (!EventLog.SourceExists(SourceName))

                {
                    EventLog.CreateEventSource(SourceName, "Application");
                    
                }
                string message = ex?.ToString() ?? "An unknown error occurred with no exception details.";
                EventLog.WriteEntry(SourceName, message, EventLogEntryType.Error);
            }
            catch
            { 
            }
        }

    }
}
