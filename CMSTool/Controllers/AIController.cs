using Business.Services;
using CMS.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMSTool.Controllers
{

    [Route("api/[controller]")]

    public class AIController : ControllerBase
    {
        private IProcessAI processAI;
        public AIController(IProcessAI processAI)
        {
            this.processAI = processAI;
        }


        [HttpPost("processAI")]
        public async Task<ActionResult> processnews([FromBody] List<CryptoData> cryptodata)
        {

            var response = await this.processAI.ProcessAIRequest(cryptodata );
            return Ok(response);


        }

        [HttpGet("processAIdata")]

        public async Task<ActionResult> getdata()
        {
            var response = await this.processAI.Getprocesseddata();
            return Ok(response);

        }


    }
}
