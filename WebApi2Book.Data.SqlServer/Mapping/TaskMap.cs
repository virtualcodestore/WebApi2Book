﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebApi2Book.Data.Entities;
using FluentNHibernate.Mapping;

namespace WebApi2Book.Data.SqlServer.Mapping
{
    public class TaskMap : VersionedClassMap<Task>
    {
        public TaskMap()
        {
            Id(x => x.TaskId);
            Map(x => x.Subject).Not.Nullable();
            Map(x => x.StartDate).Nullable();
            Map(x => x.DueDate).Nullable();
            Map(x => x.CompletedDate).Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
            References(x => x.Status, "StatusId");
            References(x => x.CreatedBy, "CreatedUserId");
            HasManyToMany(x => x.Users)
                .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
                .Table("TaskUser")
                .ParentKeyColumn("TaskId")
                .ChildKeyColumn(" UserId");
        }
    }


}
