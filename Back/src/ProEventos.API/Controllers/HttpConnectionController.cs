using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpConnectionController: ControllerBase
	{

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string localIP = "";
            try
            {
                IPHostEntry host;
                host = Dns.GetHostEntry(Dns.GetHostName());
                var addressList = host.AddressList;
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        if (ip.ToString() != "::1" && ip.ToString() != "127.0.0.1")
                        localIP = ip.ToString();
                    }
                }
                return Ok(localIP);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar conexão: {ex.Message}");
            }
        }
    }
}

