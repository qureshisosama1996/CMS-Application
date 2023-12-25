using CMS.BusinessLayer.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CMS.BusinessLayer.Services
{
    public class GetAvaliabeNews:IGetAvaliabeNews
    {

        private string apilink;

        public IConfiguration Configuration;
        public GetAvaliabeNews(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.apilink = this.Configuration["GetData:getdatalink"];
        }

        public async Task<List<CryptoData>> Getdata()
        {

                List<CryptoNews> cryptoNews = new List<CryptoNews>();
                List<CryptoData> cryptoData = new List<CryptoData>();
                var client = new RestClient();
                string nextUrl = apilink;

                while (!string.IsNullOrEmpty(nextUrl))
                {
                    var request = new RestRequest(nextUrl, Method.Get);
                    RestResponse response = await client.ExecuteAsync(request);
                var convert =  JsonSerializer.Deserialize<CryptoNewsResponse>(response.Content);

                    cryptoNews.AddRange(convert.Results);
                    nextUrl = convert.Next;
                }

                foreach (var item in cryptoNews)
                {
                    var data = new CryptoData
                    {
                        Headline = item.title,
                        Source = item.domain,
                        NewsType = item.kind,
                        PublishedDate = item.published_at

                    };
                    cryptoData.Add(data);

                }
                return cryptoData;

            

        }
    }
}
