using Business.Models;
using CMS.BusinessLayer.Models;
using CMStool.data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProcessAI : IProcessAI
    {
        public IConfiguration configuration;
        private readonly string api;
        private readonly string token;
        private CMSDbContext db;
        public ProcessAI(IConfiguration configuration, CMSDbContext db)
        {
            this.configuration = configuration;
            this.api = this.configuration["GetOpenAPI:api"];
            this.token = this.configuration["GetOpenAPI:token"];
            this.db = db;
        }


        public async Task<AImodel> processdata(CryptoData cryptodata)
        {
            string assistantResponse = @"
{
    ""source"": ""https://www.coindesk.com/markets/2023/12/18/bitwise-spot-bitcoin-btc-etf-ad-launches/"",
    ""headline"": ""Bitwise Leads the Charge in Bitcoin ETF Advertisement Campaign"",
    ""content"": ""Bitwise Asset Management, a prominent player in the cryptocurrency index fund space, has launched a new commercial as part of its ongoing efforts to secure regulatory approval for a spot Bitcoin exchange-traded fund (ETF) in the United States. The commercial, which features an older, gray-haired actor known for his role in Dos Equis beer ads, underscores Bitcoin's growing appeal and aims to bridge the gap between traditional finance and the innovative world of cryptocurrencies.\\n\\nThe 15-second advertisement, which has a retro aesthetic, suggests Bitwise's strategy to target older demographics, conveying the legitimacy and potential of cryptocurrency investments. The ad's simple yet impactful message, 'Look for Bitwise, my friends,' delivered while the actor enjoys a glass of whiskey, resonates with the notion of Bitcoin being an interesting and viable investment option today.\\n\\nBitwise, alongside over a dozen other applicants, is eagerly awaiting the U.S. Securities and Exchange Commission's (SEC) approval for the first spot Bitcoin ETF in the country. Despite facing challenges such as the SEC's concerns over crypto volatility and potential market manipulation, Bitwise remains optimistic. The firm has previously filed amended applications for a Bitcoin ETF, demonstrating its commitment to complying with regulatory standards and addressing the SEC's concerns.\\n\\nAs the race for SEC approval heats up, Bitwise stands out not only for its proactive advertising approach but also for its existing crypto ETF products. These include the Bitwise Bitcoin and Ether Equal Weight Strategy ETF (BTOP) and the Bitwise Bitcoin Strategy Optimum Roll ETF (BITC), both futures-based products. This advertising initiative marks a significant step in Bitwise's quest to launch a spot Bitcoin ETF, offering mainstream investors direct exposure to Bitcoin. The firm's efforts highlight the growing interest and potential for cryptocurrency investments among both retail and institutional investors.""
}";
            var client = new RestClient();
            var request = new RestRequest(api, Method.Post);

            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");

            var requestData = new
            {
                messages = new object[]
    {
        new
        {
            role = "system",
            content = "The News JSON Formatter is tailored to reformat user-provided headlines into news content(use browser search) in a specific JSON structure, using its browser capability to source relevant articles it also rewrites headline based on the content and try to make it catchy and give back as output in json headline property(dont give  input headline). Upon finding an article, it rewrites the content for accuracy and professionalism,include every data that is date and numbers(crypto change) then structures it into JSON. This JSON format includes \"source\" (the article's URL ), \"headline\" (the revised headline), and \"content\". The \"content\" field is meticulously prepared, structure its paragraphs properly. A new specification is that the \"content\" must have a minimum of 350 words(compulsary) and not exceed 400 words, ensuring a detailed yet concise representation of the original article's essential information, particularly dates, in the desired JSON format.The source property in json will be the headline provided that needs to be searched to get the data ,you can use and read upto three website and combine the content after doing your search "
        },
        new
        {
            role = "user",
            content = cryptodata.Headline,
        },
        new
        {
            role = "assistant",
            content = assistantResponse
        },

    },
                model = "gpt-3.5-turbo",
                max_tokens = 900
            };

            request.AddJsonBody(requestData);

            RestResponse response = await client.ExecuteAsync(request);
            var jsonResponse = JObject.Parse(response.Content);
            var content = jsonResponse["choices"][0]["message"]["content"].ToString();
            var convert = JsonSerializer.Deserialize<AImodel>(content);
            return convert;

        }

        public async Task<string> ProcessAIRequest(List<CryptoData> cryptodata)
        {
            try
            {
                foreach (var item in cryptodata)
                {
                    var result = await processdata(item);
                    var data = new AI_Data
                    {
                        Content = result.content,
                        Title = result.headline,
                    };

                    await this.db.AIData_table.AddAsync(data);

                }
                this.db.SaveChanges();
                return "passed";
            }
            catch (Exception ex) {
                return ex.ToString();   
            }
        }

        public async Task<List<AI_Data>> Getprocesseddata()
        {
            List<AI_Data> getdata =await this.db.AIData_table.ToListAsync();
            return getdata;

        }

    }

  
}