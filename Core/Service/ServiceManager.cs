using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Contracts;
using Domain_Layer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ServiceAbstraction;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IBasketRepository basketRepository , UserManager<ApplicationUser> userManager, IConfiguration configuration) 
    {
        private readonly Lazy<IProductService> lazyProductService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));

        private readonly Lazy<IOrderService> lazyOrderService = new Lazy<IOrderService>(() => new OrderService(mapper, basketRepository, unitOfWork));


        public IProductService productService => lazyProductService.Value;




        private readonly Lazy<IBasketServices> _LazyBasketService= new Lazy<IBasketServices>(() => new BasketServices(basketRepository , mapper));



        public IBasketServices BasketServices => _LazyBasketService.Value;
        private readonly Lazy<IAuthentacationService> _LazyAuthentcationService = new Lazy<IAuthentacationService>(() => new AuthentcationService(userManager , configuration,mapper));


        public IAuthentacationService AuthentacationService => _LazyAuthentcationService.Value;

        public IOrderService OrderService => lazyOrderService.Value;
    }
}
    