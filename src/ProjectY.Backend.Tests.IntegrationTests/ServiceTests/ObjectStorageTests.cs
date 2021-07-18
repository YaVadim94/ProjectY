using System.Threading.Tasks;
using Amazon.S3;
using AutoFixture;
using Moq;
using ProjectY.Backend.Application.AmazonS3.Interfaces;
using ProjectY.Backend.Application.AmazonS3.Services;
using ProjectY.Backend.Tests.IntegrationTests.DiTestBase;
using Xunit;

namespace ProjectY.Backend.Tests.IntegrationTests.ServiceTests
{
    public class ObjectStorageTests : TestGenericBase<IObjectStorageService, ObjectStorageService>
    {
        public ObjectStorageTests()
        {
            RegisterFixture<IAmazonS3>(mock =>
            {
                mock.Setup(x => x.DoesS3BucketExistAsync(It.IsAny<string>()))
                    .Returns(Task.FromResult(false));
            });

            CompleteSetting();
        }


        [Fact]
        public async Task Should_ensure_bucket_exists()
        {
            // Arrange
            var bucketName = Fixture.Create<string>();
            var registeredMock = Fixture.Create<Mock<IAmazonS3>>();

            // Act
            await Sut.CreateBucketIfNotExists(bucketName);

            // Assert
            registeredMock.Verify(x => x.EnsureBucketExistsAsync(bucketName), Times.Once);
        }
    }
}
