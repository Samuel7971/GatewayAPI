using Microsoft.AspNetCore.Mvc;
using System;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        [HttpGet]
        public string BuscarHora()
        {
            var datahora = DateTime.UtcNow.ToString("G");
            return datahora;
        }
    }
}
