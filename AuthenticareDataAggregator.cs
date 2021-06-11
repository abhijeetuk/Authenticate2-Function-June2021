using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using Xenhey.BPM.Core;
using Xenhey.BPM.Core.Implementation;


namespace Authenticare.Function
{
    public class AuthenticareDataAggregator
    {
        private NameValueCollection nvc = new NameValueCollection();
        [FunctionName("DataAggregator")]
        public void DataAggregator([TimerTrigger("%TimerInterval%")] TimerInfo timerInfo, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            nvc.Add("filename", "43EFE991E8614CFB9EDECF1B0FDED37B");
            string requestBody = "{\"ProcessStarted\" : \"Yes\" }";
            var results = orchrestatorService.Run(requestBody);
            log.LogInformation(results);
        }
        private IOrchrestatorService orchrestatorService
        {
            get
            {
                return new ManagedOrchestratorService(nvc);
            }
        }
    }

}

