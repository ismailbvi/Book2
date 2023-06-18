using Gaming_Store_Data.Data;
using GamingStore.DL.InerFaces;
using AutoMapper;
using Gaming_Store_Data.GameDto;
using GamingStore.BL.InerFaces;


namespace GamingStore.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public OrderDto GetOrderById(int id)
        {
            Order order = _orderRepository.GetById(id);
            return _mapper.Map<OrderDto>(order);
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            IEnumerable<Order> orders = _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public void AddOrder(CreateOrderDto orderDto)
        {
            Order order = _mapper.Map<Order>(orderDto);
            _orderRepository.Add(order);
        }

        public void UpdateOrder(UpdateOrderDto orderDto)
        {
            Order existingOrder = _orderRepository.GetById(orderDto.Id);
            if (existingOrder == null)
            {
                return;
            }

            Order updatedOrder = _mapper.Map(orderDto, existingOrder);
            _orderRepository.Update(updatedOrder);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }
    }
}
