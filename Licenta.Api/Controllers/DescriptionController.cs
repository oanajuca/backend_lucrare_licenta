using Licenta.Interfaces;
using Licenta.Models.Dto;
using Licenta.Models.Entities;
using Licenta.Infrastructure.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Licenta.Api.Controllers
{
    [AllowCrossSiteJson]
    [RoutePrefix("api/description")]
    public class DescriptionController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public DescriptionController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAllDescriptions()
        {
            var description = _repository.GetDescription();

            return Request.CreateResponse(HttpStatusCode.OK, description);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("trail/{descriptionId}")]
        public HttpResponseMessage GetTrailDescription(int descriptionId)
        {
            var description = _repository.GetTrailDescription(descriptionId);

            return Request.CreateResponse(HttpStatusCode.OK, description);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("save/{id}")]
        public HttpResponseMessage SaveOverview(int id, [FromBody] TrailOverviewModel trailOverviewEntity)
        {
            var desc= _repository.SaveOverview(id, trailOverviewEntity);

            return Request.CreateResponse(HttpStatusCode.OK, desc);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("adddescription")]
        public HttpResponseMessage NewDescription(string steps, string indications, string equipment, string observations, int trailid, string shortdescription)
        {
            var response = _repository.CreateTrailDescription( steps, indications, equipment, observations, trailid,shortdescription);

            if (response.Category == Constants.Info)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden, response);
        }

    }
}
