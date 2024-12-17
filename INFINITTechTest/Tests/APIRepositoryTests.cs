using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using INFINITTechTest.Factories;
using INFINITTechTest.Repositories;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace INFINITTechTest.Tests
{
    [TestFixture]
    internal class APIRepositoryTests
    {
        private ApiReaderRepository _repository;

        [SetUp]
        public void SetUp()
        {
            HttpClientFactory factory = new HttpClientFactory();
            this._repository = new ApiReaderRepository(factory);
        }

        [Test]
        public void TestConnection()
        {
            try
            {
                var tree = _repository.GetRepoFiles();
                Assert.That(tree, Is.Not.EqualTo(null));
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TestNonDefaultRepo()
        {
            try
            {
                var tree = _repository.GetRepoFiles("/microsoft/markitdown", "");
                Assert.That(tree, Is.Not.EqualTo(null));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TestBadRepo()
        {
            try
            {
                var tree = _repository.GetRepoFiles("BadBadNoGoodRepo", "");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Pass();
            }
        }
    }
}
