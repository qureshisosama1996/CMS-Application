using Business.Services;
using CMS.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMSTool.Controllers
{
    [Route("api/[controller]")]

    public class WordpressController :ControllerBase
    {
        private IAvaliableonCMS avaliableonCMS;
        public WordpressController(IAvaliableonCMS avaliableonCMS)
        {
            this.avaliableonCMS = avaliableonCMS;
        }


        [HttpGet("GetWordpressNews")]
        public async Task<ActionResult> GetNews()
        {

            var response = await this.avaliableonCMS.Getdata();
            return Ok(response);


        }
    }
}
