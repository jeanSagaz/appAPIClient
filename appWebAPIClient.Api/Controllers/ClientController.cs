using appWebAPIClient.Domain.Models;
using appWebAPIClient.Service.Log;
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
    [RoutePrefix("api/clients")]
    public class ClientController : ApiController
    {
        private readonly CreateLogFiles _log;
        private readonly IClientAppService _service;

        public ClientController(IClientAppService service)
        {
            this._service = service;
            this._log = new CreateLogFiles();
        }

        [Route("getClients")]
        public Task<HttpResponseMessage> GetClients()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var clients = Mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_service.GetAll());
                response = Request.CreateResponse(HttpStatusCode.OK, clients);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Route("getClientById/{clientId}")]
        public Task<HttpResponseMessage> GetClientById(int clientId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var clientViewModel = Mapper.Map<Client, ClientViewModel>(_service.GetById(clientId));
                if(clientViewModel != null)
                    response = Request.CreateResponse(HttpStatusCode.OK, clientViewModel);
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Cliente não encontrado.");
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }            

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [Route("getClientByIdPhotos/{clientId}")]
        public Task<HttpResponseMessage> GetClientByIdPhotos(int clientId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                //var clientViewModel = Mapper.Map<Client, ClientViewModel>(_service.GetDataByIdPhones(clientId));
                var clientViewModel = _service.GetDataByIdPhones(clientId);
                if (clientViewModel != null)
                    response = Request.CreateResponse(HttpStatusCode.OK, clientViewModel);
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Cliente não encontrado.");
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
        public Task<HttpResponseMessage> Register(ClientViewModel client)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if (client != null)
                {
                    var clientDomain = Mapper.Map<ClientViewModel, Client>(client);
                    _service.Register(clientDomain);

                    response = Request.CreateResponse(HttpStatusCode.OK, "Cliente salvo com sucesso.");
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Cliente não cadastrado.");
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
        [Route("putClient")]
        public Task<HttpResponseMessage> PutClient(ClientViewModel clientViewModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {                
                _log.Log("Método \"PutClient\"", clientViewModel);

                var client = Mapper.Map<ClientViewModel, Client>(clientViewModel);
                _service.UpdateClient(client);

                response = Request.CreateResponse(HttpStatusCode.OK, "Cliente alterado com sucesso.");
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpDelete]
        [Route("deleteClient")]
        public Task<HttpResponseMessage> DeleteClient(int clientId)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {                                
                var client = _service.GetById(clientId);
                if(client != null)
                {
                    _service.Remove(client);

                    response = Request.CreateResponse(HttpStatusCode.OK, "Cliente excluído.");
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Cliente não encontrado.");

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir cliente. Erro: " + ex.ToString());
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