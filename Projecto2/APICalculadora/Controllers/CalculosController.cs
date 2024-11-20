using APICalculadora.Models;
using APICalculadora.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APICalculadora.Controllers
{
    [RoutePrefix("api/calculos")]
    public class CalculosController : ApiController
    {
        private CalculoRepository _calculoRepository = new CalculoRepository();

        public CalculosController()
        {
        }

        [HttpGet]
        public IHttpActionResult GetAllCalculos()
        {
            try
            {
                var calculos = _calculoRepository.GetAllCalculos();
                return Ok(calculos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{tipo}")]
        public IHttpActionResult GetCalculosByTipo(string tipo)
        {
            try
            {
                var calculos = _calculoRepository.GetCalculosByTipo(tipo);
                if (calculos.Count == 0)
                {
                    return NotFound();
                }
                return Ok(calculos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddCalculo([FromBody] CalculoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var nuevoCalculo = _calculoRepository.AddCalculo(request);
                if (nuevoCalculo == null)
                {
                    return InternalServerError();
                }
                return CreatedAtRoute("DefaultApi", new { id = nuevoCalculo.Id }, nuevoCalculo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}