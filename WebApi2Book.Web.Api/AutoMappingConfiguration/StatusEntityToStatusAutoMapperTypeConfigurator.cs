using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Book.Common.TypeMapping;
using AutoMapper;
using WebApi2Book.Data.Entities;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
    public class StatusEntityToStatusAutoMapperTypeConfigurator :IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Status, Models.Status>();
                   
            });
        }
    }
}