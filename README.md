#statsdcmd
A lightweight command line client for statsd.net and statsd. Useful for:
* Logging stats on batch jobs
* Integrating with scripted workflows like source code builds, to measure frequency and latency
* Integrating with Powershell

## Download
[statsdcmd.exe](https://github.com/lukevenediger/statsdcmd/blob/master/downloads/statsdcmd.exe?raw=true) - 67kb

## Usage
Logging a count to a host called statsdnet on port 12000
```
statsdcmd.exe -h statsdnet -p 12000 -c -n build.filesCopied -v 1230
```

## Command line options
* -h | --host - the target collector's host machine (default: localhost)
* -p | --port - the target collector's listening port (default: 12000)
* -c | --count - log a count
* -t | --timing - log a timing in milliseconds
* -g | --gauge - log a gauge
* -n | --name - the namespace of the metric
* -v | --value - the value of the metric (default: 1)

## See Also
* [statsd.net](https://github.com/lukevenediger/statsd.net)
* [statsd](https://github.com/etsy/statsd/)
