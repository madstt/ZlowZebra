using System.Net.NetworkInformation;
using NUnit.Framework;
using ZlowZebra.Exceptions;
using ZlowZebra.Servers;

namespace ZlowZebra.Tests.Integration
{
    public class HttpServerTests
    {
        [SetUp]
        public void TestSetup()
        {
        }

        [Test]
        public void ContructorWithWellformedUrlTest()
        {
            // Arrange
            var server = new HttpServer("madstt.dk");

            //Act
            var url = server.Url;

            //Assert
            Assert.IsTrue(url.IsAbsoluteUri);
        }

        [Test]
        public void ConstructorWithMalformedUrlTest()
        {
            //Arrange
            var server = new HttpServer("madstt,dk");

            //Act
            var url = server.Url;

            //Assert
            Assert.IsTrue(url.IsAbsoluteUri);
        }

        [Test]
        public void ConstructorWithAbsoluteUrlTest()
        {
            //Arrange
            var server = new HttpServer("http://www.madstt.dk");

            //Act
            var res = server.Url;

            //Assert        
            Assert.IsTrue(res.IsAbsoluteUri);
        }

        [Test]
        public void ConstructorWithHttpsUrl()
        {
            //Arrange
            var server = new HttpServer("https://madstt.dk");

            //Act
            var url = server.Url;

            //Assert
            Assert.IsTrue(url.IsAbsoluteUri);
        }

        [Test]
        public void PingSuccessTest()
        {
            //Arrange
            var server = new HttpServer("madstt.dk");

            //Act
            var reply = server.Ping();

            //Assert
            Assert.True(reply.Status == IPStatus.Success);
        }

        [Test]
        public void PingCorrectIpAddress()
        {
            //Arrange
            var server = new HttpServer("madstt.dk");

            //Act
            var reply = server.Ping();

            //Assert
            Assert.IsTrue(reply.Address.ToString() == "94.231.106.54");
        }

        [Test]
        public void PingFailureTest()
        {
            //Arrange
            var server = new HttpServer("foo.bar");

            //Act
            //Assert
            Assert.Throws<InvalidUrlException>(() => server.Ping());
        }
    }
}