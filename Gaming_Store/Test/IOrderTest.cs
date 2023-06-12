using Gaming_Store_Data.Data;
using GamingStore.BL.Interfaces;
using GamingStore.BL.Services;
using GamingStore.DL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class IOrderTest
    {
        private Mock<IOrderRepository> _orderRepository;
        private Mock<IGameService> _gameService;

        private IList<Order> Orders = new List<Order>()
        {
            new Order()
            {
                Id = new Guid("148b5b1b-ee03-4470-bbc4-0e688556e6b5"),
                GameId = new Guid("59bb9fd0-7709-4735-b676-0190edd33fb9"),
                OrderName = "Book1"
            },
            new Order()
            {
                Id = new Guid("148b5b1b-ee03-4470-bbc4-0e688556e6b5"),
                GameId = new Guid("59bb9fd0-7709-4735-b676-0190edd33fb9"),
                OrderName = "Book2"
            }
        };

        private IList<Game> Games = new List<Game>()
        {
            new Game()
            {
                Id = new Guid("3e604453-99ca-4e70-b2c2-bbe1730dcab5s"),
                Name = "Author Name",
                Developer = "Author Bio"
            },
        };

        public IOrderTest()
        {
            _orderRepository = new Mock<IOrderRepository>();
            _gameService = new Mock<IGameService>();
        }

        [Fact]
        public async Task Book_GetAll_Count()
        {
            //setup
            var expectedCount = 2;

            _orderRepository.Setup(
                    x => x.GetAll())
                .Returns(async () =>
                    Orders.AsEnumerable());
            //inject
            var service = new OrderService(
                _orderRepository.Object, _gameService.Object);

            //Act
            var result = await service.GetAll();

            //Assert
            var orders = result.ToList();
            Assert.NotNull(orders);
            Assert.Equal(expectedCount, orders.Count());
            Assert.Equal(Orders, orders);
        }


        [Fact]
        public async Task Order_GetById_Ok()
        {
            //setup
            var orderId = new Guid("148b5b1b-ee03-4470-bbc4-0e688556e6b5");
            var expectedOrder =
                Orders.First(x => x.Id == orderId);
            var expectedOrderName = $"!{expectedOrder.OrderName}";

            _orderRepository.Setup(
                    x => x.GetById(orderId))
                .Returns(async () =>
                    Orders.FirstOrDefault(x => x.Id == orderId));
            //inject
            var service = new OrderService(_orderRepository.Object, _gameService.Object);

            //Act
            var result = await service.GetById(orderId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrder, result);
            Assert.Equal(expectedOrderName, result?.OrderName);
        }

        [Fact]
        public async Task Order_GetById_Not_Found()
        {
            //setup
            var orderId = new Guid("15fac422-c06b-48e8-a737-5b49fc241268");


            _orderRepository.Setup(
                    x => x.GetById(orderId))
                .Returns(async () =>
                    Orders.FirstOrDefault(x => x.Id == orderId));
            //inject
            var service = new OrderService(_orderRepository.Object, _gameService.Object);

            //Act
            var result = await service.GetById(orderId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Order_Add_Ok()
        {
            //setup
            var orderToAdd = new Order()
            {
                Id = new Guid("148b5b1b-ee03-4470-bbc4-0e688556e6b5"),
                OrderName = "New Title",
                GameId = new Guid("59bb9fd0-7709-4735-b676-0190edd33fb9"),
            };
            var expectedOrderCount = 3;

            _gameService.Setup(a =>
                a.GetById(orderToAdd.GameId)).Returns(() => Task.FromResult(Games.FirstOrDefault()));

            _orderRepository.Setup(
                    x =>
                        x.GetAllByGameId(orderToAdd.GameId))
                    .Returns(() =>
                        Task.FromResult(Orders.Where(x => x.GameId == orderToAdd.GameId)));

            _orderRepository.Setup(x =>
                x.AddOrder(It.IsAny<Order>()))
                .Callback(() =>
                {
                    Orders.Add(orderToAdd);
                }).Returns(Task.CompletedTask);

            //inject
            var service = new OrderService(_orderRepository.Object, _gameService.Object);

            //Act
            await service.AddOrder(orderToAdd);

            //Assert
            Assert.Equal(expectedOrderCount, Orders.Count);
            Assert.Equal(orderToAdd, Orders.LastOrDefault());
        }

        [Fact]
        public async Task Order_Add_Game_Not_Found()
        {
            //setup
            var orderToAdd = new Order()
            {
                Id = new Guid("15fac422-c06b-48e8-a737-5b49fc241268"),
                OrderName = "New Title",
                GameId = new Guid("59bb9fd0-7709-4735-b676-0190edd33fb9"),
            };
            var expectedBookCount = 2;

            _gameService.Setup(a =>
                a.GetById(orderToAdd.GameId)).Returns(() =>
                Task.FromResult(Games.FirstOrDefault(x => x.Id == orderToAdd.GameId)));

            _orderRepository.Setup(
                    x =>
                        x.GetAllByGameId(orderToAdd.GameId))
                .Returns(() =>
                    Task.FromResult(Orders.Where(x => x.GameId == orderToAdd.GameId)));

            _orderRepository.Setup(x =>
                x.AddOrder(It.IsAny<Order>()));

            //inject
            var service = new OrderService(_orderRepository.Object, _gameService.Object);

            //Act
            var result = await service.AddOrder(orderToAdd);

            //Assert
            Assert.Equal(expectedBookCount, Orders.Count);
            Assert.Null(result);
        }
    }
}
