using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;
using WebApi2Book.Web.Common;
using User = WebApi2Book.Web.Api.Models.User;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{

    public class TaskAssigneesResolver : IValueResolver<Task, List<User>, List<User>>
    {
        public IAutoMapper AutoMapper
        {
            get
            {
                return WebContainerManager.Get<IAutoMapper>();
            }
        }

        //protected override List<User> ResolveCore(Task source)
        //{
        //    return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        //}

    

        protected List<User> Resolve(Task source)
        {
            return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        }

        public List<User> Resolve(Task source, List<User> destination, List<User> destMember, ResolutionContext context)
        {
         
            return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        }
    }

  
        public class CurrentValueResolver : IValueResolver<Task, Models.Task,  List<User>>
        {
            public IAutoMapper AutoMapper
            {
                get
                {
                    return WebContainerManager.Get<IAutoMapper>();
                }
            }



            public List<User> Resolve(Task source, Models.Task destination, List<User> member,
                ResolutionContext context)
            {
                return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
            }
        }

}