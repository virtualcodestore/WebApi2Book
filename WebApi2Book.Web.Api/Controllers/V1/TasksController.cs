﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2Book.Web.Api.Models;
using WebApi2Book.Web.Common;
using WebApi2Book.Web.Common.Routing;
using WebApi2Book.Web.Api.MaintenanceProcessing;
 


namespace WebApi2Book.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {

        private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;

        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
        }
        
        [Route("", Name = "AddTaskRoute")] 
        [HttpPost] public Task AddTask( HttpRequestMessage requestMessage, NewTask newTask) 
        {
            var task = _addTaskMaintenanceProcessor.AddTask(newTask);
            return  task ;
        //{ 
        //    Subject = "In v1, newTask.Subject = " + newTask.Subject 
        //}; 
        }


    }
}
