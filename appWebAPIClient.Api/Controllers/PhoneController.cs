using appWebAPIClient.Domain.Models;
using appWebAPIClient.Service.Services.Interfaces;
using appWebAPIClient.Service.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace appWebAPIClient.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/phones")]
    public class PhoneController : ApiController
    {
        private IPhoneAppService _service;
        public PhoneController(IPhoneAppService service)
        {
            this._service = service;
        }

        [Route("getAll")]
        public Task<HttpResponseMessage> GetAll()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var phones = Mapper.Map<IEnumerable<Phone>, IEnumerable<PhoneViewModel>>(_service.GetAll());
                if (phones != null)
                    response = Request.CreateResponse(HttpStatusCode.OK, phones);
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não há telefone(s) cadastrado.");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Route("getAllbyClient/{clientId}")]
        public Task<HttpResponseMessage> GetAllbyClient(int clientId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var phones = _service.GetAllbyClient(clientId);
                if (phones != null)
                    response = Request.CreateResponse(HttpStatusCode.OK, phones);
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não há telefone(s) cadastrado para o cliente.");
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Route("getPhoneById/{phoneId}")]
        public Task<HttpResponseMessage> GetPhoneById(int phoneId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var PhoneViewModel = Mapper.Map<Phone, PhoneViewModel>(_service.GetById(phoneId));
                if (PhoneViewModel != null)
                    response = Request.CreateResponse(HttpStatusCode.OK, PhoneViewModel);
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Telefone não encontrado.");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("register")]
        public Task<HttpResponseMessage> Register(PhoneViewModel phone)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if (phone != null)
                {
                    var phoneDomain = Mapper.Map<PhoneViewModel, Phone>(phone);
                    _service.Add(phoneDomain);                    

                    response = Request.CreateResponse(HttpStatusCode.OK, "Telefone salvo com sucesso.");
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Telefone não cadastrado.");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPut]
        [Route("putPhone")]
        public Task<HttpResponseMessage> PutPhone(PhoneViewModel phoneViewModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var phone = Mapper.Map<PhoneViewModel, Phone>(phoneViewModel);
                _service.Update(phone);

                response = Request.CreateResponse(HttpStatusCode.OK, "Telefone alterado com sucesso.");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpDelete]
        [Route("deletePhone")]
        public Task<HttpResponseMessage> DeletePhone(int phoneId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var phone = _service.GetById(phoneId);
                if (phone != null)
                {
                    _service.Remove(phone);

                    response = Request.CreateResponse(HttpStatusCode.OK, "Telefone excluído.");
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Telefone não encontrado.");

            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir telefone.");
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
    }
}