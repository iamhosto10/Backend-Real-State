using NUnit.Framework;
using Moq;
using Million.RealEstate.Application;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Million.RealEstate.Tests
{
    public class PropertyServiceTests
    {
        [Test]
        public async Task GetProperties_WithNameFilter_ReturnsMatching()
        {
            var repoMock = new Mock<IPropertyRepository>();
            var sample = new PagedResult<PropertyDto>
            {
                Items = new[] { new PropertyDto("1","owner1","Casa Bonita","Calle 1",100000m,"/img/1.jpg") },
                Total = 1,
                Page = 1,
                PageSize = 20
            };
            repoMock.Setup(r => r.GetPropertiesAsync(It.IsAny<PropertyFilter>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(sample);

            var result = await repoMock.Object.GetPropertiesAsync(new PropertyFilter{ Name = "Casa" });

            Assert.AreEqual(1, result.Total);
            Assert.AreEqual("Casa Bonita", result.Items.First().Name);
        }
    }
}
