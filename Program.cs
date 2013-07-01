using CommandLine;
using StatsdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineStatsClient
{
  class Program
  {
    /*
     * Usage: statsd -c foo.bar.baz.zom 
    */
    static void Main(string[] args)
    {
      var options = new Options();
      if (Parser.Default.ParseArgumentsStrict(args, options))
      {
        var client = new Statsd(options.Host, options.Port, rethrowOnError : true);
        if ((options.Count || options.Gauge || options.Timing)
          && String.IsNullOrEmpty(options.RawData))
        {
          Console.WriteLine("Cannot send raw data and specify a metric type in the same command. See statsdcmd --help.");
        } 
        if (!String.IsNullOrEmpty(options.RawData))
        {
          UDPClient.SendRaw(options.Host, options.Port, options.RawData);
          return;
        }
        if (options.Count)
        {
          client.LogCount(options.Name, options.Value);
        }
        else if (options.Timing)
        {
          client.LogTiming(options.Name, options.Value);
        }
        else if (options.Gauge)
        {
          client.LogGauge(options.Name, options.Value);
        }
        else
        {
          Console.WriteLine("No metric type specified.");
        }
      }
    }
  }
}
