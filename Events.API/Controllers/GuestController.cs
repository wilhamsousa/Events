using Application;
using Application.Interface;
using Domain.Model.Payload;
using Domain.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guests.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GuestController : Controller
    {
        private readonly IGuestApplication GuestApplication;

        public GuestController(IGuestApplication application, IServiceProvider serviceProvider)
        {
            GuestApplication = application;
        }

        /// <summary>
        /// Criar convidado
        /// </summary>
        /// <param name="payload"></param>
        [Route("[action]")]
        [HttpPost]
        public ActionResult Create(GuestPayload payload)
        {
            try
            {
                var data = GuestApplication.Create(payload);
                var result = new ResponseAPI<GuestViewModel>(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<GuestViewModel>(null, false, e.Message));
            }
        }

        /// <summary>
        /// Consultar convidado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:guid}/[action]")]
        [HttpGet]
        public ActionResult Read(Guid id)
        {
            try
            {
                var data = GuestApplication.Read(id);
                var result = new ResponseAPI<GuestViewModel>(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<GuestViewModel>(null, false, e.Message));
            }
        }

        /// <summary>
        /// Listar convidados
        /// </summary>
        /// <returns></returns>
        [Route("[action]")]
        [HttpGet]
        public ActionResult List()
        {
            try
            {
                var data = GuestApplication.List();
                var result = new ResponseAPI<IEnumerable<GuestViewModel>>(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<GuestViewModel>(null, false, e.Message));
            }
        }

        /// <summary>
        /// Editar convidado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        [Route("{id:guid}/[action]")]
        [HttpPut]
        public ActionResult Update(Guid id, GuestPayload payload)
        {
            try
            {
                GuestApplication.Update(id, payload);
                var result = new ResponseAPI<GuestViewModel>(null);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<GuestViewModel>(null, false, e.Message));
            }
        }

        /// <summary>
        /// Excluir convidado
        /// </summary>
        /// <param name="id"></param>
        [Route("{id:guid}/[action]")]
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            try
            {
                GuestApplication.Delete(id);
                var result = new ResponseAPI<GuestViewModel>(null);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(new ResponseAPI<GuestViewModel>(null, false, e.Message));
            }
        }


    }
}
