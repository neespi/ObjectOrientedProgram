using Bridges.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Bridges.ApplicationServices.GetBridgesPointListUseCase;
using System.Linq.Expressions;
using Bridges.ApplicationServices.Ports;
using Bridges.DomainObjects.Ports;
using Bridges.ApplicationServices.Repositories;

namespace Bridges.WebService.Core.Tests
{
    public class GetBridgesPointListUseCaseTest
    {
        private InMemoryBridgesPointRepository CreateBridgesPointtRepository()
        {
            var repo = new InMemoryBridgesPointRepository(new List<BridgesPoint> {
                new BridgesPoint { Id = 1, CrossRiver = "пруд в парке стадиона Красная Пресня", Name = "Мост пешеходный «1905 года»"},
                new BridgesPoint { Id = 2, CrossRiver = "река Москва", Name = "Мост пешеходный «Андреевский»"},
                new BridgesPoint { Id = 3, CrossRiver = "река Сетунь", Name = "Мост пешеходный «Балочный»"},
                new BridgesPoint { Id = 4, CrossRiver = "пруд Серебряно-Виноградный", Name = "Мост пешеходный «Бауманский-1»"},
            });
            return repo;
        }
        [Fact]
        public void TestGetAllBridgesPoints()
        {
            var useCase = new GetBridgesPointListUseCase(CreateBridgesPointtRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetBridgesPointListUseCaseRequest.CreateAllBridgesPointsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.BridgesPoints.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.BridgesPoints.Select(mp => mp.Id));
        }

        [Fact]
        public void TestGetAllBridgesPointsFromEmptyRepository()
        {
            var useCase = new GetBridgesPointListUseCase(new InMemoryBridgesPointRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetBridgesPointListUseCaseRequest.CreateAllBridgesPointsRequest(), outputPort).Result);
            Assert.Empty(outputPort.BridgesPoints);
        }

        [Fact]
        public void TestGetBridgesPoint()
        {
            var useCase = new GetBridgesPointListUseCase(CreateBridgesPointtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetBridgesPointListUseCaseRequest.CreateBridgesPointRequest(2), outputPort).Result);
            Assert.Single(outputPort.BridgesPoints, mp => 2 == mp.Id);
        }

        [Fact]
        public void TestTryGetNotExistingBridgesPoint()
        {
            var useCase = new GetBridgesPointListUseCase(CreateBridgesPointtRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetBridgesPointListUseCaseRequest.CreateBridgesPointRequest(999), outputPort).Result);
            Assert.Empty(outputPort.BridgesPoints);
        }
      
    }

    class OutputPort : IOutputPort<GetBridgesPointListUseCaseResponse>
    {
        public IEnumerable<BridgesPoint> BridgesPoints { get; private set; }

        public void Handle(GetBridgesPointListUseCaseResponse response)
        {
            BridgesPoints = response.BridgesPoints;
        }
    }
}
