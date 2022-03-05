using DbEntity;
using Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Quartz;
using Services;
using Services.Interface;
using System.IO;
using System.Net;
using System.Threading.Tasks;

[DisallowConcurrentExecution]
public class ExchangeRateJob : IJob
{
    private readonly ILogger<ExchangeRateJob> _logger;

    private ICurrencyService _currencyService;

    public ExchangeRateJob(ILogger<ExchangeRateJob> logger,
     DbContextEntity dbContextEntity)
    {
        _logger = logger;
        _currencyService = new CurrencyService(dbContextEntity);
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("get exchange rate");
        var currencies = GetCurrency();
        TransferRate(currencies);
        _logger.LogInformation("success");

        return Task.CompletedTask;
    }

    private JObject GetCurrency()
    {
        var requestURL = "https://api.exchangerate.host/latest";
        var httpRequest = (HttpWebRequest)WebRequest.Create(requestURL);

        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        var streamReader = new StreamReader(httpResponse.GetResponseStream());
        var result = streamReader.ReadToEnd();

        var jObject = JObject.Parse(result);
        return JObject.Parse(jObject["rates"].ToString());
    }

    private void TransferRate(JObject exchangeRates)
    {
        foreach (var exchangeRate in exchangeRates)
        {
            if (exchangeRate.Key != "TWD")
            {
                TransferTWDToRate(exchangeRate.Key);
            }
        }
    }

    private void TransferTWDToRate(string exchangeRate)
    {
        var requestURL = "https://api.exchangerate.host/convert?from=TWD&to=" + exchangeRate;
        var httpRequest = (HttpWebRequest)WebRequest.Create(requestURL);

        var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        var streamReader = new StreamReader(httpResponse.GetResponseStream());
        var result = streamReader.ReadToEnd();

        var jObject = JObject.Parse(result);
        SaveRate(exchangeRate, float.Parse(jObject["result"].ToString()));
    }

    private void SaveRate(string exchangeRate, float rate)
    {
        var currency = _currencyService.GetByCurrencyName(exchangeRate);
        _logger.LogInformation("save {0}", exchangeRate);

        if (currency == null)
        {
            _currencyService.Insert(
            new Currency()
            {
                Name = exchangeRate,
                ExchangeRate = rate
            });
        }
        else
        {
            currency.Result.ExchangeRate = rate;
            _currencyService.Update(currency.Result);
        }
    }
}