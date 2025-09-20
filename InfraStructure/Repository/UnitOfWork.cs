using Domain_Layer.Contracts;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public IGenericRepository<T, TId> GetRepositery<T, TId>() where T : BaseEntity<TId>
        {
            return new GenericRepository<T, TId>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

    public class OrderSpecifications : BaseSpecifications<Order, Guid>
    {
        public OrderSpecifications(string email) : base(x => x.BuyerEmail == email)
        {
            AddInclude(x => x.DeliveryMethod);
            AddInclude(x => x.OrderItems);
        }

        public OrderSpecifications(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.DeliveryMethod);
            AddInclude(x => x.OrderItems);
        }
    }
}

// Example of simplified null check
var basket = await basketRepository.GetCustomerBasketasync(orderDto.BasketId) 
    ?? throw new BasketNotFoundEx(orderDto.BasketId);