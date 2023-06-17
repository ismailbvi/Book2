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

        public OrderDto GetById(int id)
        {
            var order = _orderRepository.GetById(id);
            return _mapper.Map<OrderDto>(order);
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var orders = _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public void CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            // Perform any additional logic or validation
            _orderRepository.Add(order);
        }

        public void UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                throw new NotFoundException("Order not found.");
            }

            _mapper.Map(updateOrderDto, order);
            // Perform any additional logic or validation
            _orderRepository.Update(order);
        }

        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                throw new NotFoundException("Order not found.");
            }

            // Perform any additional logic or validation
            _orderRepository.Delete(id);
        }
    }

}
