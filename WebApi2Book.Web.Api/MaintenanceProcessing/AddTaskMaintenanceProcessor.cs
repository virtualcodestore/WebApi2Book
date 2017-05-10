using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Book.Web.Api.Models;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.QueryProcessors;

namespace WebApi2Book.Web.Api.MaintenanceProcessing
{
    public class AddTaskMaintenanceProcessor :IAddTaskMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddTaskQueryProcessor _queryProcessor;
        
         public AddTaskMaintenanceProcessor(IAddTaskQueryProcessor queryProcessor,IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }



        public Models.Task AddTask(Models.NewTask newTask)
        {
            var taskEntity = _autoMapper.Map<Data.Entities.Task>(newTask);
            _queryProcessor.AddTask(taskEntity);
            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }
    }
}