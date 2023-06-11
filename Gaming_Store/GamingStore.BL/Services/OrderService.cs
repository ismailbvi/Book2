using AutoMapper;
using Gaming_Store_Data.Data;
using GamingStore.BL.Interfaces;
using GamingStore.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGameService _gameService;

        public OrderService(
            IOrderRepository orderRepository,
            IGameService gameService)
        {
            _orderRepository = orderRepository;
            _gameService = gameService;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order?> GetById(Guid id)
        {
            var result = await _orderRepository.GetById(id);

            if (result != null)
            {
                result.OrderName = $"!{result.OrderName}";
            }

            return result;
        }

        public async Task<Order?> AddOrder(Order order)
        {
            order.Id = Guid.NewGuid();

            var game =
                await _gameService.GetById(order.GameId);

            if (game == null) return null;

            var     gameOrders =
                await _orderRepository
                    .GetAllByGameId(order.GameId);

            var titleForGameExist =
                gameOrders.Any(b => b.OrderName == order.OrderName);

            if (titleForGameExist) return null;

            await _orderRepository.AddOrder(order);

            return order;
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.DeleteOrder(id);
        }

        public async Task UpdateOrder(Order order)
        {   
            await _orderRepository.UpdateOrder(order);
        }
    }
}
