using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace ZlowZebra.Servers
{
    public class HttpServer
    {
        private readonly Uri url;
        private readonly List<IPAddress> ipAddresses;

        public HttpServer(string url)
        {
            this.url = toUri(url);

            try
            {
                var hostEntry = Dns.GetHostEntry(this.url.Host);
                ipAddresses = new List<IPAddress>();
                ipAddresses.AddRange(hostEntry.AddressList);
            }
            catch (Exception)
            {
                ipAddresses = new List<IPAddress>();
            }
        }

        public Uri Url
        {
            get { return url; }
        }

        public IEnumerable<IPAddress> IpAddresses
        {
            get { return ipAddresses; }
        }

        public bool Ping()
        {
            var pingCommand = new Ping();
            
            if (ipAddresses.Count == 0)
            {
                return false;
            }

            var reply = pingCommand.Send(ipAddresses[0]);

            return reply.Status == IPStatus.Success;
        }

        private Uri toUri(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException("uri", "Argument is empty or null.");
            }

            Uri absoluteUri;

            uri = FormatUri(uri);

            if (!uri.Contains("http"))
            {
                uri = string.Format("{0}://{1}", "http", uri);
            }

            if (Uri.TryCreate(uri, UriKind.Absolute, out absoluteUri))
            {
                return absoluteUri;
            }

            throw new NotImplementedException();
        }

        private string FormatUri(string uri)
        {
            uri = uri.Trim();
            uri = uri.Replace(',', '.');
            
            return uri;
        }
    }
}