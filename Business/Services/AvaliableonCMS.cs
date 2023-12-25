using Business.Models;
using CMS.BusinessLayer.Models;
using Microsoft.Extensions.Configuration;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Business.Services
{
    public class AvaliableonCMS:IAvaliableonCMS

    {
        private string apilink;
        private string token;
        private string userid;
        public IConfiguration Configuration;
        public AvaliableonCMS(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.apilink = this.Configuration["Wordpress:getlink"];
            this.token = this.Configuration["Wordpress:password"];
            this.userid = this.Configuration["Wordpress:username"];
        }

        public async Task<List<WordpressData>> Getdata()

        {
            List<WordpressData> wordpress = new List<WordpressData>();
            var options = new RestClientOptions();

            options.Authenticator = new HttpBasicAuthenticator("humansofcrypto", "08Zy XcZz lzpV iXzj 4PWR qPEc");

            var clientwordpress = new RestClient(options);

            var requestwordpress = new RestRequest("https://humansofcrypto.co/wp-json/wp/v2/posts", Method.Get);

            var responsewordpress =await clientwordpress.ExecuteAsync(requestwordpress);

            var convert = JsonSerializer.Deserialize<List<WordPressPost>>(responsewordpress.Content);

            foreach(var item in convert) {
                var data = new WordpressData
                {
                    title = item.title.rendered,
                    status = item.status,
                    publishedDate = item.date

                };
                wordpress.Add(data);
            }


            return wordpress;


        }
    }
}
