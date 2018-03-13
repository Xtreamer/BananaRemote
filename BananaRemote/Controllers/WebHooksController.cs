using System;
using System.Collections.Generic;
using System.Linq;
using Commands;
using Microsoft.AspNetCore.Mvc;
using OnkyoPlugin;

namespace BananaRemote.Controllers
{
    [Route("api/[controller]")]
    public class WebHooksController : Controller
    {
        private ISender onkyoSender;

        public WebHooksController(ISender onkyoSender)
        {
            this.onkyoSender = onkyoSender;
        }

        [HttpPost("[action]")]
        public void TryPostOn()
        {
            onkyoSender.Send("system-power:on");
        }        

        [HttpPost("[action]")]
        public void TryPostOff()
        {
            onkyoSender.Send("system-power:standby");
        }

        [HttpPost("[action]")]
        public void SendCommand([FromBody] Command command)
        {
            onkyoSender.Send(command.Text);
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
