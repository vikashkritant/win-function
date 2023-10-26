using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace win_function
{
    public static class WinFunction
    {
        [FunctionName("WinFunction")]
        public static void Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"WinFunction- Received message with id: {myQueueItem}");
            try
            {               
                UnzipProcessor unzipper = new UnzipProcessor(log);
                unzipper.ProcessFileShare();
            }
            catch (Exception ex)
            {
                log.LogError($"Error is:  {ex.Message}");
            }
        }
    }
}
