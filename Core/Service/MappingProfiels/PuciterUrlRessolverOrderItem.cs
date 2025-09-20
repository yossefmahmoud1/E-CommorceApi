using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain_Layer.Models.Order;
using Microsoft.Extensions.Configuration;
using Shared.OrderDtos;

namespace Services.MappingProfiles
{
    public class OrderItemPictureUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration configuration;

        public OrderItemPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Product.PuctireUrl))
            {
                return string.Empty;
            }

            var Url = $"{configuration.GetSection("Urls")["BaseUrl"]}{source.Product.PuctireUrl}";
            return Url;
        }
    }
}
