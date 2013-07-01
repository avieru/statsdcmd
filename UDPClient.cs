using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineStatsClient
{
  internal static class UDPClient
  {
    public static void SendRaw(string host, int port, string data)
    {
      var ipv4Address = Dns.GetHostAddresses(host).First(p => p.AddressFamily == AddressFamily.InterNetwork);
      var udpClient = new UdpClient();
      udpClient.Connect(ipv4Address, port);
      byte[] payload = Encoding.UTF8.GetBytes(data);
      udpClient.Send(payload, payload.Length);
    }
  }
}
