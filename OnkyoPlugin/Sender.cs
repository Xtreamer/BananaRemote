using System;
using System.Net.NetworkInformation;
using System.Threading;
using OnkyoISCPlib;
using OnkyoISCPlib.Commands;

namespace OnkyoPlugin
{
    public class Sender
    {
        public Sender()
        {
            var discovery = ISCPDeviceDiscovery.DiscoverDevice(60128);
            var deviceIp = discovery.IP;

            var p = new Ping();
            PingReply rep = p.Send(deviceIp, 3000);
            while (rep != null && rep.Status != IPStatus.Success)
            {
                Thread.Sleep(30000);
                p.Send(deviceIp, 3000);
            }
            
            ISCPSocket.DeviceIp = discovery.IP;
            ISCPSocket.DevicePort = discovery.Port;
            ISCPSocket.OnPacketRecieved += ISCPSocket_OnPacketRecieved;
            try
            {
                ISCPSocket.StartListener();
            }
            catch (Exception x)
            {
            }
        }

        private void ISCPSocket_OnPacketRecieved(string str)
        {
        }

        public void PowerOn()
        {
            ISCPSocket.SendPacket(Power.On);
        }

        public void PowerOff()
        {
            ISCPSocket.SendPacket(Power.Off);
        }
    }
}
