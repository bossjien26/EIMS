using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
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

        var currencies = GetCurrency();

        _logger.LogInformation("success");

        return Task.CompletedTask;
    }

    private JObject GetCurrency()
    {
        var requestURL = "https://api.exchangerate.host/latest";
        var httpRequest = (HttpWebRequest)WebRequest.Create(requestURL);

        // httpRequest.Accept = "application/xml";


        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        var streamReader = new StreamReader(httpResponse.GetResponseStream());
        var result = streamReader.ReadToEnd();

        var jObject = JObject.Parse(result);
        return JObject.Parse(jObject["rates"].ToString());

        // foreach (var item in exchangeRate)
        // {
        //     Console.WriteLine("currency : {0} , rate : {1}", item.Key, item.Value);
        // }
    }
}