﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
    public class NewTaskToTaskEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {

        public void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewTask, Data.Entities.Task>()
                    .ForMember(opt => opt.Version, x => x.Ignore())
                    .ForMember(opt => opt.CreatedBy, x => x.Ignore())
                    .ForMember(opt => opt.TaskId, x => x.Ignore())
                    .ForMember(opt => opt.CreatedDate, x => x.Ignore())
                    .ForMember(opt => opt.CompletedDate, x => x.Ignore())
                    .ForMember(opt => opt.Status, x => x.Ignore())
                    .ForMember(opt => opt.Users, x => x.Ignore());
            });
 
        }

        //Usage
        // IMapper mapper = config.CreateMapper();
        // var source = new Source();
        // var dest = mapper.Map<Source, Dest>(source);
    }
}