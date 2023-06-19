using Gaming_Store_Data.Data;
using GamingStore.DL.InerFaces;
using AutoMapper;
using GamingStore.BL.InerFaces;
using Microsoft.Extensions.Logging;
using Gaming_Store_Data.Request;

namespace GamingStore.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;
        private readonly IGameService _gameService;

        public OrderService(IOrderRepository orderRepository,
            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;

        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var result =
                 await _orderRepository.GetAll();

            return (IEnumerable<Game>)result;

        }

        public async Task<Order?> GetById(Guid id)
        {
            var game = await _orderRepository.GetById(id);

            if (game == null)
            {
                _logger.LogError($"GetById:{id} returns null!");
                return null;
            }

            return game;
        }

        public async Task<Order?> Add(Order order)
        {
            order.Id = Guid.NewGuid();

            var game =
                await _gameService.GetById(order.GameId);

            if (game == null) return null;

            var gameOrders =
                await _orderRepository
                    .GetAllByGameId(order.GameId);

            var titleForGameExist =
                gameOrders.Any(b => b.Name == order.Name);

            if (titleForGameExist) return null;

            await _orderRepository.Add(order);

            return order;
        }

        public async Task Delete(Guid id)
        {
            await _orderRepository.Delete(id);
        }

        Task<IEnumerable<Order>> IOrderService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
