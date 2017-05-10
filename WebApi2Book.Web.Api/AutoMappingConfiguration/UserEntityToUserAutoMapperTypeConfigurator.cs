using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
    public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator

    {
        public void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, Models.User>()
                   .ForMember(opt => opt.Links, x => x.Ignore());

            });
        }

    }
}