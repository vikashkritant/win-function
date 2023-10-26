using Microsoft.Extensions.Logging;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Readers;
using System.IO;

namespace win_function
{
    public class UnzipProcessor
    {
        ILogger logger;
        public UnzipProcessor(ILogger log)
        {            
            logger = log;            
        }
        public void ProcessFileShare()
        {
            logger.LogInformation($"ProcessFileShare Started");
            var di = new DirectoryInfo(@"/fx-files/input");
            var fi = di.GetFiles();
            using (SevenZipArchive archive = SevenZipArchive.Open(fi))
            {
                var reader = archive.ExtractAllEntries();
                reader.WriteAllToDirectory(@"/fx-files/output");
            }
            logger.LogInformation($"ProcessFileShare Ended");
        }
    }
}
