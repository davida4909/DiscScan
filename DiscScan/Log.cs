using System.IO;

namespace DiscScan
{
    /// <summary>
    /// Logging
    /// </summary>
    public class Log
    {
        private readonly string logFilename;

        public Log()
        {
            logFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SyncLog.txt");
        }
       
        /// <summary>
        /// write a log entry
        /// </summary>
        /// <param name="log"></param>
        /// <exception cref="Exception"></exception>
        public async Task Write(string log)
        {
            try
            {
                // open log for append
                using (StreamWriter writer = new StreamWriter(logFilename, true))
                {
                    // log
                    await writer.WriteLineAsync(log);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Logit(string op, string source, string dest)
        {
            _ = Write(op + "," + source + "," + dest );
        }
    }
}
