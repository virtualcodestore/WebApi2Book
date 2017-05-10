using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper; 
using WebApi2Book.Common.TypeMapping; 
using WebApi2Book.Web.Api.Models;


namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
    public class UserToUserEntityAutoMapperTypeConfigurator :IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            var config = new MapperConfiguration(cfg =>
               {
                   cfg.CreateMap<User, Data.Entities.User>()
                      .ForMember(opt => opt.Version, x => x.Ignore());
                      
               });
        }
    }
}