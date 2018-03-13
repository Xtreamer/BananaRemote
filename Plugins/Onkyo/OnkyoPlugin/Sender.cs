using Eiscp.Core;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace OnkyoPlugin
{
    public interface ISender
    {
        void Send(string command);
    }

    public class Sender : ISender
    {
        string host = "192.168.1.110";
        int port = 60128;
        IReceiver receiver;
        IPAddress address;

        public Sender()
        {
            address = IPAddress.Parse(host);
            receiver = new Receiver(address, port);
        }

        public void Send(string command)
        {
            using (receiver)
            {
                string iscpCommand = null;
                bool rawResponse = false;

                if (command.All(ch => char.IsUpper(ch) || char.IsDigit(ch)))
                {
                    iscpCommand = command;
                    rawResponse = true;
                }
                else
                {
                    try
                    {
                        iscpCommand = Utils.CommandToIscp(command);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    rawResponse = false;
                }

                var responseBytes = new byte[0];
                try
                {
                    responseBytes = receiver.Raw(iscpCommand);
                }
                catch (Exception ex)
                {
                }
                
                var response = Encoding.ASCII.GetString(responseBytes);
            }
        }
    }
}
