using System.IO;
using FluentAssertions;
using NUnit.Framework;
using TaxReturn.Repository;

namespace TaxReturn.ApplicationServices.Tests
{
    [TestFixture]
    public class UploadFileContentServiceTests
    {
        private UploadFileContentService _fileUploadService;
        [TestFixtureSetUp]
        public void SetUp()
        {
            _fileUploadService = new UploadFileContentService(new RepositoryFactory());
        }

        [Test]
        public void WhenFileIsNotEmpty_UploadContents()
        {
            var stream = File.Open(@".\test_data\validContent.csv", FileMode.Open);
          
            var result = _fileUploadService.UploadFile(stream);

            result.NumberOfLinesIgnored.ShouldBeEquivalentTo(0);
            result.NumberOfLinesUploaded.ShouldBeEquivalentTo(4);
        }

        [Test]
        public void WhenFileContentIsInvalid_ShouldFailValidation()
        {
            var stream = File.Open(@".\test_data\invalidContent.csv", FileMode.Open);
          
            var result = _fileUploadService.UploadFile(stream);

            result.Valid.ShouldBeEquivalentTo(false);
        }
    }
}
