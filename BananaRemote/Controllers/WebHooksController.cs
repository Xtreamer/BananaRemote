using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnkyoPlugin;

namespace BananaRemote.Controllers
{
    [Route("api/[controller]")]
    public class WebHooksController : Controller
    {
        private Sender onkyoSender;

        [HttpPost("[action]")]
        public void TryPostOn()
        {
            CreateSender();
            onkyoSender.PowerOn();
        }        

        [HttpPost("[action]")]
        public void TryPostOff()
        {
            CreateSender();
            onkyoSender.PowerOff();
        }

        private void CreateSender()
        {
            if (onkyoSender == null)
            {
                onkyoSender = new Sender();
            }
        }
    }
}
