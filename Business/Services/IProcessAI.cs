using Business.Models;
using CMS.BusinessLayer.Models;
using CMStool.data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProcessAI
    {
        public Task<AImodel> processdata(CryptoData cryptodata);

        public Task<string> ProcessAIRequest(List<CryptoData> cryptodata);

        public  Task<List<AI_Data>> Getprocesseddata()



    }
}
