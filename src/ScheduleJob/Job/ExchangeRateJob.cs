using Microsoft.Extensions.Logging;
using Quartz;
using System.IO;
using System.Net;
using System.Threading.Tasks;

[DisallowConcurrentExecution]
public class ExchangeRateJob : IJob
{
    private readonly ILogger<ExchangeRateJob> _logger;
    public ExchangeRateJob(ILogger<ExchangeRateJob> logger)
    {
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("get exchange rate");
        var requestURL = "https://api.exchangerate.host/latest";
        var httpRequest = (HttpWebRequest)WebRequest.Create(requestURL);

        httpRequest.Accept = "application/xml";


        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        var streamReader = new StreamReader(httpResponse.GetResponseStream());
        var result = streamReader.ReadToEnd();

        // Console.WriteLine(httpResponse.StatusCode);
        _logger.LogInformation(result);
        // var request = new XMLHttpRequest();
        // request.open('GET', requestURL);
        // request.responseType = 'json';
        // request.send();

        // request.onload = function() {
        //     var response = request.response;
        //     console.log(response);
        // }

        return Task.CompletedTask;
    }
}