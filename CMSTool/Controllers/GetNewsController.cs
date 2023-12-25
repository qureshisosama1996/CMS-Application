using CMS.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMSApplication.Server.Controllers
{

    [Route("api/[controller]")]
    public class GetNewsController : ControllerBase
    {
        private IGetAvaliabeNews getAvaliabeNews;       
        public GetNewsController(IGetAvaliabeNews getAvaliabeNews) {
            this.getAvaliabeNews = getAvaliabeNews;
        }


        [HttpGet("GetCryptoNews")]
        public async Task<ActionResult> GetNews() {

            var response = await this.getAvaliabeNews.Getdata();
            return Ok(response);


        } 

    }
}
