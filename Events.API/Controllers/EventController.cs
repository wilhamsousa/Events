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
        /// <param name="payload"></param>
        [Route("[action]")]
        [HttpPost]
        public ActionResult Create(EventPayload payload)
        {
            try
            {
                var data = eventApplication.Create(payload);
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
        /// Listar eventos
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public ActionResult List()
        {
            try
            {
                var data = eventApplication.List();
                var result = new ResponseAPI<IEnumerable<EventViewModel>>(data);
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

        /// <summary>
        /// Painel geral
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public ActionResult Dashboard()
        {
            try
            {
                var data = eventApplication.Dashboard();
                var result = new ResponseAPI<IEnumerable<DashboardViewModel>>(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<DashboardViewModel>(null, false, e.Message));
            }
        }
    }
}
