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
        [Route("getlocalip")]
        public  IActionResult GetLocalIp()
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

        [HttpGet]
        [Route("getexternalip")]
        public  IActionResult GetExternalIp()
        {
            string externalIP = "";
            try
            {
                IPHostEntry host;
                host = Dns.GetHostEntry(Dns.GetHostName());
                var addressList = host.AddressList;
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetworkV4")
                    {
                        if (ip.ToString() != "::1" && ip.ToString() != "127.0.0.1")
                            externalIP = ip.ToString();
                    }
                }
                return Ok(externalIP);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar conexão: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("getlocalhost")]
        public IActionResult GetLocalHost()
        {
            string hostName = "";
            try
            {
                IPHostEntry host;
                host = Dns.GetHostEntry(Dns.GetHostName());

                hostName = host.HostName;

                var addressList = host.AddressList;

                return Ok(hostName);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar host: {ex.Message}");
            }
        }


    }
}

