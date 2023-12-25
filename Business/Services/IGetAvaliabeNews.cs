using CMS.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLayer.Services
{
    public interface IGetAvaliabeNews
    {
        public  Task<List<CryptoData>>  Getdata();
    }
}
