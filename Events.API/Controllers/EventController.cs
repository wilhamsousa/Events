﻿using Application;
using Application.Interface;
using Domain.Model.Payload;
using Domain.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventApplication eventApplication;

        public EventController(IEventApplication application, IServiceProvider serviceProvider)
        {
            eventApplication = application;
        }

        /// <summary>
        /// Criar evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        [Route("{id:guid}/[action]")]
        [HttpPost]
        public ActionResult Create(Guid id, EventPayload payload)
        {
            try
            {
                var data = eventApplication.Create(id, payload);
                var result = new ResponseAPI<EventViewModel>(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<EventViewModel>(null, false, e.Message));
            }
        }

        /// <summary>
        /// Consultar evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:guid}/[action]")]
        [HttpGet]
        public ActionResult Read(Guid id)
        {
            try
            {
                var data = eventApplication.Read(id);
                var result = new ResponseAPI<EventViewModel>(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<EventViewModel>(null, false, e.Message));
            }
        }

        /// <summary>
        /// Editar evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        [Route("{id:guid}/[action]")]
        [HttpPut]
        public ActionResult Update(Guid id, EventPayload payload)
        {
            try
            {
                eventApplication.Update(id, payload);
                var result = new ResponseAPI<EventViewModel>(null);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<EventViewModel>(null, false, e.Message));
            }
        }

        /// <summary>
        /// Excluir evento
        /// </summary>
        /// <param name="id"></param>
        [Route("{id:guid}/[action]")]
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            try
            {
                eventApplication.Delete(id);
                var result = new ResponseAPI<EventViewModel>(null);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<EventViewModel>(null, false, e.Message));
            }
        }
    }
}
