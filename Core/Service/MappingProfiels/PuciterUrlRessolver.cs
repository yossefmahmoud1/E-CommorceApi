﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Execution;
using Domain_Layer.Models.Producr;
using Microsoft.Extensions.Configuration;
using Shared.DaraTransferObject;

namespace Service.MappingProfiels
{
     class PuciterUrlRessolver(IConfiguration _configuration) :IValueResolver<Product ,ProductDto,string>
    {

     
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
            {
                return string.Empty;
            }
            else
            {

                var Url = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";

                return Url;

            }
        }



    }
}
